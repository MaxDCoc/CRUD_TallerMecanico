using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
namespace TallerModel
{

    public class TallerContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TallerMecanicoDB");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Taller;Trusted_Connection=True;");
        }

    }

    public class Usuario
    {
        public int UsuarioId { get; set; }


        public string Apellido { get; set; } = string.Empty;

        
        public string Nombre { get; set; } = string.Empty;

        public Rango? Puesto { get; set; }
    }

    public enum Rango
    {
        Gerente,
        Administrativo,
        DT,
        Mecanico
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
