using SignatureApplication.Common;
using SignatureDomain.Entities;
using static SignatureCommon.Enums;

namespace SignaturePersistance.Configurations
{
    public class SeedConfiguration
    {
        private static readonly Hash hash = new Hash();

        #region Organizations
        public static readonly Organization Organization1 = new Organization()
        {
            Id = Guid.NewGuid(),
            CommercialName="LVBGroup",
            JuridicalName="LVBGroup",
            IDNO = "0000000000001",
            JuridicalAddress="Address1 Ap.1",
            PhoneNumber = null,
            Status = OrganizationStatus.Active,
            CreateDate= DateTime.Now,
            LastModified = null,
        };
        #endregion

        #region Users
        public static readonly User User1 = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = "First",
            LastName = "User",
            Email = "admin@lvbgroup.com",
            PhoneNumber = "69000001",
            IDNP = "0000000000001",
            Password = hash.GetHashSHA256("Admin"),
            DateOfBirth = DateTime.Now,
            CreateDate = DateTime.Now,
            Address = "Planet Earth",
            Gender = Gender._,
            LastModified = DateTime.Now,
            Status = UserStatus.Active,
            OrganizationId = Organization1.Id
        };
        
        public static readonly User User2 = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = "Second",
            LastName = "User",
            Email = "user@lvbgroup.com",
            PhoneNumber = "69000002",
            IDNP = "0000000000002",
            Password = hash.GetHashSHA256("User"),
            DateOfBirth = DateTime.Now,
            CreateDate = DateTime.Now,
            Address = "Planet Earth",
            Gender = Gender._,
            LastModified = DateTime.Now,
            Status = UserStatus.Active,
            OrganizationId = Organization1.Id
        };
        
        public static readonly User User3 = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = "Third",
            LastName = "User",
            Email = "user@lvbgroup.com",
            PhoneNumber = "69000003",
            IDNP = "0000000000003",
            Password = hash.GetHashSHA256("User"),
            DateOfBirth = DateTime.Now,
            CreateDate = DateTime.Now,
            Address = "Planet Earth",
            Gender = Gender._,
            LastModified = DateTime.Now,
            Status = UserStatus.Active,
            OrganizationId = Organization1.Id
        };
        #endregion
        #region Files
        #endregion
    }
}
