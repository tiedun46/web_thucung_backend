using Backend.ThuCung.API.DTO;
using Backend.ThuCung.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.ThuCung.API.Controllers
{
    [Route("api/ClientEndpoint")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ThuCungDbContext _context;

        public ClientController(ThuCungDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "SendMail")]
        public async Task<ActionResult<Tuser>> LoginAPI(LoginDTO model)
        {
            if (_context.Tusers == null)
            {
                return Problem("Entity set 'VanPhongPhamDbContext.Tusers'  is null.");
            }
            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Email))
            {
                return Problem("Email or Password  is null.");
            }
            var user = await _context.Tusers.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                return BadRequest("Tài khoản hoặc mật khẩu không đúng!");
            }
            else
            {
                return user;
            }
        }

        [HttpPost(Name = "RegisterAPI")]
        public async Task<ActionResult> RegisterAPI(LoginDTO model)
        {
            if (_context.Tusers == null)
            {
                return Problem("Entity set 'VanPhongPhamDbContext.Tusers'  is null.");
            }
            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Email))
            {
                return Problem("Email or Password  is null.");
            }
            var user = await _context.Tusers.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                return BadRequest("Tài khoản hoặc mật khẩu không đúng!");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
