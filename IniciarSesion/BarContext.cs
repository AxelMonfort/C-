using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IniciarSesion
{
    public class BarContext : DbContext
    {
        private static string _path = @"C:\Users\axele\Desktop\usuarios.json";
        private static string _path1 = @"C:\Users\axele\Desktop\registers.json";
        public BarContext()
        {        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LAPTOP-PG1MN4UF\SERVIDORAXEL;Database=DB;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public BarContext(DbContextOptions<BarContext> opciones) : base(opciones)
        {
            var db = new BarContext();
            //var usuario = GetUser();
            //var register = GetRegisters();
            //SerializeJsonFileUser(usuario);
            //SerializeJsonFileRegister(register);
            //var usuarios = ObtenerUsuariosJson();
            //var registers = ObtenerRegistersJson();
            //DeserializeJsonFile(usuarios,registers);
        }
       



        #region "Creacion de JSON"
        public static void SerializeJsonFileUser(List<User> users)
        {
            string usersJson = JsonConvert.SerializeObject(users.ToArray(),Formatting.Indented);
            File.WriteAllText(_path,usersJson);
        }

        public static void SerializeJsonFileRegister(List<Register> registers)
        {
            string registersJson = JsonConvert.SerializeObject(registers.ToArray(), Formatting.Indented);
            File.WriteAllText(_path1, registersJson);
        }

        public static List<User> GetUser()
        {
            List<User> users = new List<User>() 
            {
                new User { Name = "Axel",  UserName = "Monfort", Password = "123"},
                new User { Name = "Paula", UserName = "Aguero",  Password = "222" },
                new User { Name = "Nayla", UserName = "Monfort", Password = "345" },
                new User { Name = "Ruben", UserName = "Gaset",   Password = "546" },
                new User { Name = "Roxana",UserName = "Zamorano",Password = "ab546" },
            };
           return users;
        }
        public static List<Register> GetRegisters()
        {
            List<Register> registers = new List<Register>()
            {
                new Register { NameId = "Axel",  UserNameId = "Monfort"},
                new Register { NameId = "Paula", UserNameId = "Aguero"},
                new Register { NameId = "Nayla", UserNameId = "Monfort"},
                new Register { NameId = "Ruben", UserNameId = "Gaset"},
                new Register { NameId = "Roxana",UserNameId = "Zamorano"},
            };
            return registers;
        }
        #endregion
        #region "Leer JSON"
        public static string ObtenerUsuariosJson()
        {
            string usuariosJson;
            using (var reader = new StreamReader("usuarios.json"))  //o puedo poner tambien _path en ves de usuarios.json
            {
                usuariosJson = reader.ReadToEnd();
            }
            return usuariosJson;
        }

        public static string ObtenerRegistersJson()
        {
            Console.WriteLine("registros---------------");
            string registerJson;
            using (var reader = new StreamReader(_path1))
            {
                registerJson = reader.ReadToEnd();
            }
            return registerJson;
        }

        public static void DeserializeJsonFile(string usuariosJson,string registersJson)
        {
            Console.WriteLine("Desearalize1-----------------");
            var usuarios = JsonConvert.DeserializeObject<List<User>>(usuariosJson);
            var registrados = JsonConvert.DeserializeObject<List<Register>>(registersJson);
            //Si quisiera mostrar un dato.
            //Console.WriteLine(string.Format("Axel {0}", usuarios[0].UserName));
            //for (int i = 0; i < usuarios.Count; i++)
            //{
            //    Console.WriteLine("Name {0} , UserName {1} ", usuarios[i].Name, usuarios[i].UserName);

            //}
            //List<String> registradosList = new List<String>();
            //for (int i = 0; i < registrados.Count; i++)
            //{
            //    registradosList.Add(registrados[i].NameRegister);
            //    registradosList.Add(registrados[i].UserNameRegister);

            //}
            //List<Register> registro = new List<Register>();
            //for (int i = 0; i < registradosList.Count; i++)
            //{
            //    registro.Add(registro[i]);
            //}
            var db = new BarContext();
            db.Users.AddRange(usuarios);
            db.Registers.AddRange(registrados);
            db.SaveChanges();
            Console.WriteLine("se cargo exitosamente.");
            
        }
        #endregion
        #region "Creacion de tablas en DB"
        public DbSet<User> Users { get; set; }  //La clase que va a salir en la base de datos.
        public DbSet<Register> Registers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Register>().ToTable("Register");

        }
        #endregion


    }
}