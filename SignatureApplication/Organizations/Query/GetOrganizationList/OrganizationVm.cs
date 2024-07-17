using static SignatureCommon.Enums;

namespace SignatureApplication.Organizations.Query.GetOrganizationList
{
    public class OrganizationVm
    {
        public Guid Id { get; set; }
        public string IDNO { get; set; }
        public string JuridicalName { get; set; }
        public OrganizationStatus Status { get; set; }
    }
}
