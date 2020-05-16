using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api
{
  [Route("api/[controller]")]
  public class SpeedController : Controller
  {
    [Route("")]
    public async Task<int> Get()
    {
      await Task.Delay(2000);
      return 350;
    }

    [Route("version")]
    public int Version()
    {
      return 2;
    }
  }
}