using LinqToDB.Mapping;
using SignatureDomain.Common;
using static SignatureCommon.Enums;

namespace SignatureDomain.Entities
{
    [Table("Users")]
    public class User : AuditableEntity
    {
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Column("IDNP")]
        public string IDNP { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Column("Gender")]
        public Gender Gender { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("Status")]
        public UserStatus Status { get; set; }
        [Column("Role")]
        public UserRole Role { get; set; }

        [Column("OrganizationId")]
        public Guid OrganizationId { get; set; }
        [Association(ThisKey = "OrganizationId", OtherKey = "Id", CanBeNull = false)]
        public Organization Organization { get; set; }
        public ICollection<SignatureFilesToUsers> SignatureFilesToUsers { get; set; } = new HashSet<SignatureFilesToUsers>();
    }
}
