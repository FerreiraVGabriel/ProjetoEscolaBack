using Infra.Entities;


namespace Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario user);
    }
}
