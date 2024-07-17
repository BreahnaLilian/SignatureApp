namespace SignatureCommon.Models.JsonResponseModels;

public class ValidationJsonResponse : BaseJsonResponse
{
    public A[] Errors { get; set; }
}

public class A
{
    public string Name { get; set; }
    public string Message { get; set; }
}