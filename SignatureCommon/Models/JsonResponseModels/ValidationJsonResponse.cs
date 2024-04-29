namespace SignatureCommon.Models.JsonResponseModels
{
    public class ValidationJsonResponse : BaseJsonResponse
    {
        public Dictionary<string, string> Errors { get; set; }
    }
}
