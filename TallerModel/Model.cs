using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
//using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TallerModel
{

    public class TallerContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("TallerMecanicoDB");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Taller;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=LS_SERVERPR\SQLEXPRESS;Database=PruebaCarrito2;user=sa;password=VALE3618");
            //optionsBuilder.UseSqlite("Data Source=CarritosCompraStandardLite.db");
            //optionsBuilder.UseNpgsql("Host=localhost;Database=PruebaCarrito2;Username=postgres;Password=postgres");
            //optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        }

    }

    public enum Rango
        {
        Gerente,
        Administrativo,
        DT,
        Mecanico
        }


    public class Usuario
    {
        public int UsuarioId { get; set; }

        //[Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; } = string.Empty;

        //[Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        //[Required(ErrorMessage = "El puesto es obligatorio.")]
        public Rango? Puesto { get; set; }
    }

    public class UsuarioServices
    {
        private TallerContext _context;

        public UsuarioServices()
        {
            _context = new TallerContext();
        }

        public Usuario Create(Usuario usuario)
        {
          /*  var errores = new List<string>();
            
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                errores.Add("El nombre es obligatorio y no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                errores.Add("El apellido es obligatorio y no puede estar vacío.");
            }

            if (usuario.Puesto == null)
            {
                errores.Add("El puesto es obligatorio.");
            }

            if (errores.Count > 0)
            {
                // Concatena todos los mensajes de error y lanza una sola excepción
                throw new ArgumentException(string.Join("\n", errores));
            }
          */
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return (usuario);
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = _context.Usuarios.ToList();
            return usuarios;
        }

        public Usuario? GetById(int id)
        {
            {
                var usuario = _context.Usuarios.SingleOrDefault(u => u.UsuarioId == id);

                if (usuario == null)
                {
                    return null;
                }

                return (usuario);
            }
        }

        public IEnumerable<Usuario>? GetByNombreyAp(string aBuscar)
        {
            var usuarios = _context.Usuarios.Where(u => u.Nombre.Contains(aBuscar) || u.Apellido.Contains(aBuscar)).ToList();
            
            if (usuarios == null)
            {
                return null;
            }

            return usuarios;
        }

        public IEnumerable<Usuario>? GetByPuesto(Rango puestoABuscar)
        {
            var usuarios = _context.Usuarios.Where(u => u.Puesto == puestoABuscar).ToList();

            if (usuarios == null)
            {
                return null;
            }

            return usuarios;
        }

        public Usuario Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return (usuario);
        }

        public int? Delete(int id)
        {
            var usuario = _context.Usuarios.Single(u => u.UsuarioId == id);
            
            if (usuario == null)
            {
                return null;
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return (id);
        }
    }

}
