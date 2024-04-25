namespace SignatureCommon.Models.JsonResponseModels
{
    public class SingleJsonResponse<TRecord> : BaseJsonResponse where TRecord : class
    {
        public TRecord Item { get; set; }
    }
}
