using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecksController : ControllerBase
    {
        [HttpGet("throw")]
        public int ThrowException()
        {
            var b = 10;
            var c = 0;
            var a = 0;
            try
            {
                a = b / c;
            }
            catch (Exception ex)
            {
                throw new Exception("This is test exception");

            }
            return a;
        }
    }
}
