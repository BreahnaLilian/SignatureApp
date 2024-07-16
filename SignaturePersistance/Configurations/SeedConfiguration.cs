using SignatureApplication.Common;
using SignatureDomain.Entities;
using static SignatureCommon.Enums;

namespace SignaturePersistance.Configurations
{
    public class SeedConfiguration
    {
        #region Organizations
        public static readonly Organization Organization1 = new Organization()
        {
            Id = new Guid("9EE896EE-CB8A-4DF4-949B-B6FCC81D76F2"),
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
            Id = new Guid("E631E603-266C-462A-87D3-F606C8111559"),
            FirstName = "First",
            LastName = "User",
            Email = "admin@lvbgroup.com",
            PhoneNumber = "69000001",
            IDNP = "0000000000001",
            Password = Hash.GetHashSHA256("Admin"),
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
            Id = new Guid("61D001AB-1553-4B8A-AF2A-379D1540ED5A"),
            FirstName = "Second",
            LastName = "User",
            Email = "user@lvbgroup.com",
            PhoneNumber = "69000002",
            IDNP = "0000000000002",
            Password = Hash.GetHashSHA256("User"),
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
            Id = new Guid("1F7BDDDE-FE95-4F29-878D-8E6EFCA243F1"),
            FirstName = "Third",
            LastName = "User",
            Email = "user@lvbgroup.com",
            PhoneNumber = "69000003",
            IDNP = "0000000000003",
            Password = Hash.GetHashSHA256("User"),
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
