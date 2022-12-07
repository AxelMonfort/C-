using System.ComponentModel.DataAnnotations;


namespace IniciarSesion
{
    public class Register
    {
        public long Id { get; set; }
        [MaxLength(200)]
        public string NameId { get; set; }
        [MaxLength(100)]
        public string UserNameId { get; set; }
    }
}