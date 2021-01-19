namespace BE.Domain.Dtos.Auth
{
    public class UsuarioRepostaLoginDto
    {
        public string AccessToken { get; set; }
        public double ExpireIn { get; set; }
        public UsuarioTokenDto UsuarioToken { get; set; }
    }
}