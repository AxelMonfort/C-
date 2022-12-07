using IniciarSesion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Licenses;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Code_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BarContext _context;
        public UserController(BarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Register> Registers = await _context.Registers.ToListAsync();
                return Ok(Registers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{name} , {password}")]
        public ActionResult Enter(string name,string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Name == name);
            var pass = _context.Users.FirstOrDefault(x => x.Password == password);

            if (user == null)
                return Ok(false);
            else
            {
                if (pass == null)
                    return Ok(false);
                else
                    return Ok(true);
            }
            
        }
    }
}
