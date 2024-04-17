namespace SignatureDomain.Entities
{
    public class SignatureFilesToUsers
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}
