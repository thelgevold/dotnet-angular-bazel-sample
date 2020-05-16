using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Xunit;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IntegrationTests
{
  public class CarApiTests
  {
    [Fact]
    public async Task Car_Api_Returns_List_Of_Cars()
    {
      HttpClient client = new HttpClient ();

      var content = await client.GetStringAsync ("http://localhost:5002/api/car");
      
      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };

      var car =  JsonSerializer.Deserialize<Car> (content, options);

      Assert.Equal("350 km/h", car.TopSpeed);
      Assert.Equal("Lamborghini Aventador", car.Name);
    }
  }
}