using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net.Http;

namespace Api
{
  [Route("api/[controller]")]
  public class CarController : Controller
  {
    private readonly IHttpClientFactory clientFactory;

    public CarController(IHttpClientFactory clientFactory)
    {
      this.clientFactory = clientFactory;
    }

    [Route("")]
    public async Task<Car> Get()
    {
      await Task.Delay(2000);
      var client = clientFactory.CreateClient();
      var topSpeed = await client.GetStringAsync ("http://localhost:5004/api/speed");
     
      var car = new Car() { Name = "Lamborghini Aventador", TopSpeed = $"{topSpeed} km/h" };

      return car;
    }
  }
}