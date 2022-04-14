using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PenalCodeAPI.DTO;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace PenalCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(UserDTO userDTO)
        {
            CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                UserName = userDTO.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();


            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO userDTO)
        {
            var users = await _context.User.ToListAsync();
            var userFound = false;

            foreach(var user in users)
            {
                if (userDTO.UserName == user.UserName)
                {
                    if (VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        return Ok("Logado com sucesso!");
                    }
                }
            }

            return NotFound("Usuario nao encontrado ou senha digitada errada!");

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordSalt);
            }
        }

        private string createToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
