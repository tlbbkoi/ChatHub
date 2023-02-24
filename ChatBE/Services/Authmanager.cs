using AutoMapper;
using ChatBE.Data;
using ChatBE.Model;
using ChatBE.Properties;
using ChatBE.Reponsitory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatBE.Services
{
    public interface IAumanager
    {
        Task<string> CreateToken();
        Task<bool> Register(UserDTO user);
        Task<string> Login(LoginUserDTO loginUserDTO);
        Task<string> Logout();
    }
    public class Authmanager : IAumanager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private User _user;


        public Authmanager(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config,
                            UserManager<User> userManager , IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);
            var nToken = new JwtSecurityTokenHandler().WriteToken(token);
            IsValidToken(nToken);
            return nToken;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _config.GetSection("Jwt");
            var key = jwtSettings.GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            return claims;

        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(
                    int.Parse(jwtSettings.GetSection("lifetime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                audience: jwtSettings.GetSection("Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
                );
            return token;
        }

        private bool IsValidToken(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtSettings = _config.GetSection("Jwt");
            try
            {
                jwtSecurityTokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("Key").Value)),

                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,

                    ValidateAudience = true,
                    ValidAudience = jwtSettings.GetSection("Audience").Value,

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out var _);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public async Task<bool> Register(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.UserName = userDTO.Email;
            var result = await _userManager.CreateAsync(user, userDTO.PassWord);
            if (!result.Succeeded) {
                List<string> error = new List<string>();
                foreach (var err in result.Errors)
                {
                    error.Add(err.Description);
                }

                throw new BusinessException(error[0]);
            }
            await _userManager.AddToRolesAsync(user, userDTO.Roles);
            return true;
        }

        public async Task<string> Login(LoginUserDTO loginUserDTO)
        {
            _user = await _userManager.FindByNameAsync(loginUserDTO.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, loginUserDTO.PassWord));
            if(_user!= null && result) {
                return await CreateToken();
            }
            throw new BusinessException(Resource.LOGIN_ERR);
        }

        public async Task<string> Logout()
        {
            var identity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            //Gets list of claims.
            IEnumerable<Claim> claims = identity.Claims;

            var usernameClaim = claims
                .Where(x => x.Type == ClaimTypes.Name)
                .FirstOrDefault();

            var user = await _userManager.FindByNameAsync(usernameClaim.Value);
            var result = await _userManager.RemoveAuthenticationTokenAsync(user, "Web", "Access");
            if (result.Succeeded)
            {
                return Resource.LOGOUT_SUCCESS;
            }
            throw new BusinessException(Resource.LOGOUT_FAIL);
        }
    }
}
