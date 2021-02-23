using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using VehicleRentalSystem.DTOs;
using VehicleRentalSystem.Models;
using VehicleRentalSystem.ViewModels;

namespace VehicleRentalSystem.Controllers
{
    public class CustomersController : Controller
    {
        [Route("Customers")]
        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (id == 0)
                {
                    var viewModel = new CustomerViewModel
                    {
                        Branches = db.Branches.OrderBy(b => b.Name).ToList(),
                    };
                    return View(viewModel);

                }
                else
                {
                    // Build PhoneNumberViewModels for customer
                    int person = db.Customers.Find(id).PersonId;
                    List<PersonPhone> personPhones = db.PeoplePhones.Where(b => b.BusinessEntityId == person).ToList();
                    List<PhoneNumberType> phoneTypes = db.PhoneNumberTypes.OrderBy(p => p.Name).ToList();
                    List<PhoneNumberViewModel> phoneModels = new List<PhoneNumberViewModel>();

                    foreach (var p in personPhones)
                    {
                        PhoneNumberViewModel phoneViewModel = new PhoneNumberViewModel
                        {
                            Phone = p,
                            PhoneNumberTypes = phoneTypes
                        };

                        phoneModels.Add(phoneViewModel);
                    }

                    // Build AddressViewModels for customer
                    List<BusinessEntityAddress> addresses = db.BusinessEntityAddresses.Include("Address").Where(b => b.BusinessEntityId == person).ToList();
                    List<AddressType> addressTypes = db.AddressesTypes.OrderBy(p => p.Name).ToList();
                    List<AddressViewModel> addressModels = new List<AddressViewModel>();

                    foreach (var a in addresses)
                    {
                        AddressViewModel addressViewModel = new AddressViewModel
                        {
                            BEAddress = a,
                            AddressTypes = addressTypes
                        };

                        addressModels.Add(addressViewModel);
                    }

                    // Build EmailViewModel for customer
                    List<EmailAddress> emailAddresses = db.EmailAddresses.Where(b => b.BusinessEntityId == person).ToList();
                    List<EmailViewModel> emailModels = new List<EmailViewModel>();

                    foreach (var a in emailAddresses)
                    {
                        EmailViewModel emailViewModel = new EmailViewModel
                        {
                            EmailAdd = a
                        };

                        emailModels.Add(emailViewModel);
                    }


                    CustomerViewModel viewModel = new CustomerViewModel
                    {
                        Customer = db.Customers.Include("Person").SingleOrDefault(c => c.PersonId == person),
                        Addresses = addressModels,
                        EmailAddresses = emailModels,
                        PhoneNumbers = phoneModels,
                        Branches = db.Branches.OrderBy(b => b.Name).ToList(),
                    };

                    db.SaveChanges();

                    return View(viewModel);
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(CustomerViewModel newCustomer)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                // Update customer information
                if (db.Customers.Any(x => x.CustomerId == newCustomer.Customer.CustomerId))
                {

                    System.Diagnostics.Debug.WriteLine(newCustomer.Customer.CustomerId);
                    db.People.Attach(newCustomer.Customer.Person);
                    db.Entry(newCustomer.Customer.Person).State = EntityState.Modified;

                    db.Customers.Attach(newCustomer.Customer);
                    db.Entry(newCustomer.Customer).State = EntityState.Modified;

                    if (newCustomer.PhoneNumbers != null)
                    {
                        foreach (var a in newCustomer.PhoneNumbers)
                        {
                            a.Phone.BusinessEntityId = newCustomer.Customer.Person.BusinessEntityId;
                            if (db.PeoplePhones.Any(p => p.BusinessEntityId == a.Phone.BusinessEntityId && p.PhoneNumberTypeId == a.Phone.PhoneNumberTypeId))
                            {
                                db.PeoplePhones.Attach(a.Phone);
                                db.Entry(a.Phone).State = EntityState.Modified;
                            }
                            else
                            {
                                db.PeoplePhones.Add(a.Phone);
                            }
                        }
                    }

                    if (newCustomer.Addresses != null)
                    {

                        foreach (var a in newCustomer.Addresses)
                        {


                            a.BEAddress.BusinessEntityId = newCustomer.Customer.Person.BusinessEntityId;
                            a.BEAddress.Address.AddressId = a.BEAddress.AddressId;
                            if (db.BusinessEntityAddresses.Any(p => p.BusinessEntityId == a.BEAddress.BusinessEntityId && p.AddressTypeId == a.BEAddress.AddressTypeId && p.AddressId == a.BEAddress.Address.AddressId))
                            {
                                db.BusinessEntityAddresses.Attach(a.BEAddress);
                                db.Entry(a.BEAddress).State = EntityState.Modified;


                                db.Addresses.Attach(a.BEAddress.Address);
                                db.Entry(a.BEAddress.Address).State = EntityState.Modified;
                            }
                            else
                            {
                                db.BusinessEntityAddresses.Add(a.BEAddress);
                            }
                        }
                    }

                    if (newCustomer.EmailAddresses != null)
                    {
                        foreach (var a in newCustomer.EmailAddresses)
                        {
                            a.EmailAdd.BusinessEntityId = newCustomer.Customer.Person.BusinessEntityId;
                            if (db.EmailAddresses.Any(p => p.BusinessEntityId == a.EmailAdd.BusinessEntityId && p.EmailAddressId == a.EmailAdd.EmailAddressId))
                            {
                                db.EmailAddresses.Attach(a.EmailAdd);
                                db.Entry(a.EmailAdd).State = EntityState.Modified;
                            }
                            else
                            {
                                db.EmailAddresses.Add(a.EmailAdd);
                            }
                        }
                    }

                    db.SaveChanges();

                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);

                }
                else
                {

                    // Add new customer
                    const string PERSON_TYPE = "Customer";

                    BusinessEntity be = new BusinessEntity();
                    db.BusinessEntities.Add(be);

                    newCustomer.Customer.Person.BusinessEntity = be;
                    newCustomer.Customer.Person.PersonType = PERSON_TYPE;
                    db.People.Add(newCustomer.Customer.Person);

                    Branch branch = db.Branches.Find(newCustomer.Customer.Branch);
                    newCustomer.Customer.Branch = branch;


                    foreach (var a in newCustomer.Addresses)
                    {
                        a.BEAddress.BusinessEntity = be;
                        db.BusinessEntityAddresses.Add(a.BEAddress);
                    }

                    foreach (var a in newCustomer.PhoneNumbers)
                    {
                        a.Phone.BusinessEntity = be;
                        db.PeoplePhones.Add(a.Phone);
                    }

                    foreach (var a in newCustomer.EmailAddresses)
                    {
                        a.EmailAdd.BusinessEntity = be;
                        db.EmailAddresses.Add(a.EmailAdd);
                    }

                    db.Customers.Add(newCustomer.Customer);

                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [HttpGet]
        public ActionResult GetData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Query customer data for CustomerDTO list to display on customer data table   
                var query =
                        (
                            from customer in db.Customers
                            join person in db.People on customer.PersonId equals person.BusinessEntityId
                            join phone in db.PeoplePhones on person.BusinessEntityId equals phone.BusinessEntityId into phoneNumbers
                            join email in db.EmailAddresses on person.BusinessEntityId equals email.BusinessEntityId into emailAddresses
                            group new { customer, person, phoneNumbers, emailAddresses } by customer.CustomerId into gs
                            from g in gs.Take(1)
                            from pn in g.phoneNumbers.DefaultIfEmpty().Take(1)
                            from e in g.emailAddresses.DefaultIfEmpty().Take(1)
                            select new CustomerDTO
                            {
                                Id = g.customer.CustomerId,
                                Title = g.person.Title,
                                FirstName = g.person.FirstName,
                                LastName = g.person.LastName,
                                PhoneNumber = pn.PhoneNumber,
                                EmailAddress = e.Email,
                                Branch = g.customer.Branch.Name
                            }
                        ).ToList();


                return Json(new { data = query }, JsonRequestBehavior.AllowGet); // sent json of rentals to page
            }
        }


        public ActionResult Details(int? id)
        {
            // Get customer data for display in customer details view    
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                int person = db.Customers.Find(id).PersonId;
                List<PersonPhone> personPhones = db.PeoplePhones.Where(b => b.BusinessEntityId == person).ToList();
                List<PhoneNumberType> phoneTypes = db.PhoneNumberTypes.OrderBy(p => p.Name).ToList();
                List<PhoneNumberViewModel> phoneModels = new List<PhoneNumberViewModel>();

                foreach (var p in personPhones)
                {
                    PhoneNumberViewModel phoneViewModel = new PhoneNumberViewModel
                    {
                        Phone = p,
                        PhoneNumberTypes = phoneTypes
                    };

                    phoneModels.Add(phoneViewModel);
                }

                List<BusinessEntityAddress> addresses = db.BusinessEntityAddresses.Include("Address").Where(b => b.BusinessEntityId == person).ToList();
                List<AddressType> addressTypes = db.AddressesTypes.OrderBy(p => p.Name).ToList();
                List<AddressViewModel> addressModels = new List<AddressViewModel>();

                foreach (var a in addresses)
                {
                    AddressViewModel addressViewModel = new AddressViewModel
                    {
                        BEAddress = a,
                        AddressTypes = addressTypes
                    };

                    addressModels.Add(addressViewModel);
                }

                List<EmailAddress> emailAddresses = db.EmailAddresses.Where(b => b.BusinessEntityId == person).ToList();
                List<EmailViewModel> emailModels = new List<EmailViewModel>();

                foreach (var a in emailAddresses)
                {
                    EmailViewModel emailViewModel = new EmailViewModel
                    {
                        EmailAdd = a
                    };

                    emailModels.Add(emailViewModel);
                }
                CustomerViewModel viewModel = new CustomerViewModel
                {
                    Customer = db.Customers.Include("Person").SingleOrDefault(c => c.PersonId == person),
                    Addresses = addressModels,
                    EmailAddresses = emailModels,
                    PhoneNumbers = phoneModels,
                    Branches = db.Branches.OrderBy(b => b.Name).ToList(),
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                BusinessEntity businessEntity = db.Customers.Where(c => c.CustomerId == id).Select(c => c.Person.BusinessEntity).Single();
                var addresses = db.BusinessEntityAddresses.Where(b => b.BusinessEntityId == businessEntity.BusinessEntityId).Select(b => b.Address);

                db.People.Remove(db.People.Where(p => p.BusinessEntityId == businessEntity.BusinessEntityId).Single());
                db.BusinessEntities.Remove(businessEntity);
                db.Addresses.RemoveRange(addresses);

                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Populates data required to add new phone number
        public ActionResult AddNewPhoneNumber()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                PhoneNumberViewModel viewModel = new PhoneNumberViewModel
                {
                    Phone = new PersonPhone(),
                    PhoneNumberTypes = db.PhoneNumberTypes.OrderBy(p => p.Name).ToList()
                };

                return PartialView("~/Views/Shared/EditorTemplates/_PhoneNumber_New.cshtml", viewModel);
            }

        }

        // Populates data required to add new Address
        public ActionResult AddNewAddress()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                AddressViewModel viewModel = new AddressViewModel
                {
                    BEAddress = new BusinessEntityAddress(),
                    AddressTypes = db.AddressesTypes.OrderBy(p => p.Name).ToList()
                };

                return PartialView("~/Views/Shared/EditorTemplates/_Address_New.cshtml", viewModel);
            }

        }

        // Populates data required to add new email
        public ActionResult AddNewEmailAddress()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                EmailViewModel viewModel = new EmailViewModel
                {
                    EmailAdd = new EmailAddress()
                };

                return PartialView("~/Views/Shared/EditorTemplates/_EmailAddress_New.cshtml", viewModel);
            }

        }


        [HttpPost]
        public ActionResult DeleteAddress(int businessEntityId, int addressId, int addressTypeId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.BusinessEntityAddresses.Remove(db.BusinessEntityAddresses.Find(businessEntityId, addressId, addressTypeId));
                db.Addresses.Remove(db.Addresses.Find(addressId));

                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);


            }
        }


        [HttpPost]
        public ActionResult DeletePhoneNumber(int businessEntityId, int phoneNumberTypeId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.PeoplePhones.Remove(db.PeoplePhones.Find(businessEntityId, phoneNumberTypeId));

                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);


            }
        }

        [HttpPost]
        public ActionResult DeleteEmailAddress(int businessEntityId, int emailId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.EmailAddresses.Remove(db.EmailAddresses.Find(businessEntityId, emailId));

                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}