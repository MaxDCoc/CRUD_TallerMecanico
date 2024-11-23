using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using TallerModel;
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
        public string? Nombre { get; set; } 
        public string? Apellido { get; set; } 
        public string? Contraseña { get; set; }
        public string? Email { get; set; }
        public string? Dni { get; set; }
        public string? Cuil { get; set;} 
        public string? Telefono { get; set; }
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
    public class Vehiculo
    {
        public required string Patente { get; set; }
        public required string Marca { get; set; }
        public required string Modelo { get; set; }
        public required string Tipo { get; set; } // "electrico", "hibrido", o "naftero"
        public required string Chasis { get; set; }
        public required string Motor { get; set; }
        public int DniApoderado { get; set; }
        public required string NombreApoderado { get; set; }
    }
}

public class Turno
{
    public int TurnoId { get; set; }
    public DateTime FechaHora { get; set; }
    public string Vehiculo { get; set; } // Podrías relacionarlo con la clase Vehiculo si lo necesitas
    public string Cliente { get; set; }
    public int? MecanicoId { get; set; } // Puede ser null si no hay mecánico asignado
    public Usuario? Mecanico { get; set; }
}

public class TallerContext : DbContext
{
    public DbSet<Turno> Turnos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; } // Ya existente

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("TallerMecanicoDB");
    }
}

public class TurnoServices
{
    private readonly TallerContext _context;

    public TurnoServices()
    {
        _context = new TallerContext();
    }

    public IEnumerable<Turno> GetTurnosSinMecanico()
    {
        return _context.Turnos.Where(t => t.MecanicoId == null).ToList();
    }

    public Turno AsignarMecanico(int turnoId, int mecanicoId)
    {
        var turno = _context.Turnos.SingleOrDefault(t => t.TurnoId == turnoId);
        if (turno == null) throw new Exception("Turno no encontrado");

        turno.MecanicoId = mecanicoId;
        _context.SaveChanges();

        return turno;
    }
}
