namespace ConceptArchitect.ApiKeyService;



public class ApiKey
{
   public string Key { get; set; }
   public int Quota { get; set; }
   public DateTime? QuotaStart { get; set; }

   public int Usage { get; set; }
}

public interface IApiKeyService
{
    Task Validate(string key);
     
}


public class ApiKeyException: Exception
{
    public string Key { get; set; }
    public ApiKeyException(string key, string message): base(message)
    {
        Key=key;
    }
}


public class DummyApiKeyService : IApiKeyService
{
    Dictionary<string, ApiKey> db = new Dictionary<string, ApiKey>();

    public DummyApiKeyService()
    {
        for(var i=1;i<10;i++)
        {
            var key = $"APIKEY00{i}";
            var info = new ApiKey()
            {
                Key=key,
                Quota=5,
                QuotaStart=null,
                Usage=0
            };
            db[key]=info;
        }
    }

    public async Task Validate(string key)
    {
        if(! db.ContainsKey(key))
            throw new ApiKeyException(key,"Key Not Found");
        
        var info = db[key];

        if(info.QuotaStart==null)
            info.QuotaStart=DateTime.Now;

        var currentTime = DateTime.Now;
        var gap = currentTime-info.QuotaStart.Value;
        if (gap.TotalMinutes > 1)
        {
            info.QuotaStart=DateTime.Now;
            info.Usage=0;
            return;
        } else if (info.Usage< info.Quota)
        {
            info.Usage++;
            return;
        }
        else
            throw new ApiKeyException(key,"Key Quota Exceeded");
    }

  

}