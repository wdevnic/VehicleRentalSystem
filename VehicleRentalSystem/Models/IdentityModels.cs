using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VehicleRentalSystem.EntityConfiguration;

namespace VehicleRentalSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
           
        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FirstName", FirstName));
            userIdentity.AddClaim(new Claim("LastName", LastName));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressesTypes { get; set; }
        public virtual DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public virtual DbSet<PersonPhone> PeoplePhones { get; set; }
        public virtual DbSet<EmailAddress> EmailAddresses { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<VehicleManufacturer> VehicleManufacturers { get; set; }
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Return> Returns { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BusinessEntityConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new AddressTypeConfiguration());
            modelBuilder.Configurations.Add(new BusinessEntityAddressConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new PhoneNumberTypeConfiguration());
            modelBuilder.Configurations.Add(new PersonPhoneConfiguration());
            modelBuilder.Configurations.Add(new EmailAddressConfiguration());
            modelBuilder.Configurations.Add(new BranchConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new VehicleTypeConfiguration());
            modelBuilder.Configurations.Add(new ReservationConfiguration());
            modelBuilder.Configurations.Add(new VehicleManufacturerConfiguration());
            modelBuilder.Configurations.Add(new VehicleModelConfiguration());
            modelBuilder.Configurations.Add(new VehicleConfiguration());
            modelBuilder.Configurations.Add(new RentalConfiguration());
            modelBuilder.Configurations.Add(new ReturnConfiguration());
        }
    }
}