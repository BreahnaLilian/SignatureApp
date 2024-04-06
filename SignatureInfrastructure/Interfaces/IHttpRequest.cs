using SignatureInfrastructure.BasicModels;

namespace SignatureInfrastructure.Interfaces
{
    public interface IHttpRequest
    {
        public string Get(QueryData queryData);
        public string Post(QueryDataJsonBody queryDataJsonBody);
        public string Put(QueryDataJsonBody queryDataJsonBody);
        public string Delete(QueryData queryData);
    }
}
