using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Sessao
    {
        public int Id { get; set; }

        public string IdUsuario { get; set; }
        
        public DateTime DataCriacao { get; set; }
        
        public DateTime DataExpiracao { get; set; }
        
        public string AccessToken { get; set; }
        
        public string RefreshToken { get; set; }
    }
}
