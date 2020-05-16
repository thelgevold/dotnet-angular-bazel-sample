using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RequestHelper {
  static readonly HttpClient client = new HttpClient ();

  public async Task<T> Get<T> (string url) {
    var content = await client.GetStringAsync (url);
    return JsonSerializer.Deserialize<T> (content);
  }
}