using Newtonsoft.Json;

public class Request
{
    public string begin { get; set; }
    public string end { get; set; }
    public string[] currency_names { get; set; }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}