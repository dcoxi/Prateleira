using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pratelerira.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prateleira.Api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {




        public CategoriaController()
        {
            
        }

        [HttpGet("todas")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok("YO yooo!");
        }

    }
}
