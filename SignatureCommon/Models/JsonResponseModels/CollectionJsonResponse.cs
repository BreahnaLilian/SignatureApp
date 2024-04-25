namespace SignatureCommon.Models.JsonResponseModels
{
    public class CollectionJsonResponse<TRecord> : BaseJsonResponse where TRecord : class
    {
        public IEnumerable<TRecord> Items { get; set; }
    }
}
