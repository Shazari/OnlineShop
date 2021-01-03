using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParsMarketCoreAPI
{
    [ApiController]
    [Route("[controller]")]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class BaseApiController : ControllerBase
    {

    }
}
