using System.ComponentModel.DataAnnotations;

namespace IniciarSesion
{
   
    public class User
    {
        public long UserId { get; set; }
        [MaxLength(200)]
        public string  Name { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }

    }
}
