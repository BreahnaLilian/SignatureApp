using static SignatureCommon.Enums;

namespace SignatureApplication.Organizations.ViewModels
{
    public class DetailsOrganizationViewModel
    {
        public Guid Id { get; set; }
        public string IDNO { get; set; }
        public string CommercialName { get; set; }
        public string JuridicalName { get; set; }
        public string JuridicalAddress { get; set; }
        public OrganizationStatus Status { get; set; }
        public string PhoneNumber { get; set; }
    }
}
