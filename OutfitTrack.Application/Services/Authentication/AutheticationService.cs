using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using OutfitTrack.Application.Interfaces;
using OutfitTrack.Application.Security;
using OutfitTrack.Arguments;
using OutfitTrack.Domain.Entities;
using OutfitTrack.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OutfitTrack.Application.Services;

public class AuthenticationService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext, IUserRepository userRepository) : BaseService_0(unitOfWork), IAuthenticationService
{
    private readonly HttpContext _httpContext = httpContext.HttpContext;
    private readonly IUserRepository _userRepository = userRepository;

    public OutputAuthentication? Authenticate(InputAuthentication inputAuthentication)
    {
        User? user = _userRepository.GetByIdentifier(new InputIdentifierUser(inputAuthentication.Email));

        if (user is not null)
        {
            if (inputAuthentication.Password == user.Password)
            {
                var token = GenerateJwtToken(user.Id.ToString()!, user.Email!);
                
                user.SetProperty(nameof(User.TokenExpirationDate), DateTime.UtcNow.AddDays(7));

                _userRepository!.Update(user);
                _unitOfWork!.Commit();

                return new OutputAuthentication(token, DateTime.UtcNow.AddDays(7));
            }
            else
                throw new InvalidOperationException($"Usuário não autorizado. Senha incorreta.");
        }
        else
            throw new InvalidOperationException($"Usuário não existe. Cadastre seu usuário no endpoint aberto POST '/api/User'");
    }

    private string GenerateJwtToken(string userId, string userName)
    {
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Iss, _httpContext.Request.Host.Value),
            new(JwtRegisteredClaimNames.Sub, userName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(SecurityKeyJwt.Key));
        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);
        var expireDate = DateTime.UtcNow.AddDays(7);

        JwtSecurityToken token = new(
            _httpContext.Request.Host.Value,
            userId,
            claims,
            expires: expireDate,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}