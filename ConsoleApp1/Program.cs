// See https://aka.ms/new-console-template for more information
using TallerModel;
UsuarioServices usuarioServices = new UsuarioServices();

//CREAR USUARIOS

/*
for (int i = 1; i <= 20; i++)
{
Usuario usuarioaCrear = new Usuario();
usuarioaCrear.Nombre = $"Martin{i}";
usuarioaCrear.Apellido = $"LOPEZ SOTO{i}";
usuarioaCrear.Puesto = Rango.Mecanico;

Usuario usuario1 = usuarioServices.Create(usuarioaCrear);
//Console.WriteLine($"Id: {usuario1.UsuarioId} Desc: {usuario1.Nombre} {usuario1.Apellido} ");
}
*/

//OBTENER LISTA DE USUARIOS
/*

IEnumerable<Usuario> listaUsuarios = usuarioServices.GetAll();
Console.WriteLine("All Usuarios in database:");
foreach (Usuario usuariosEncontrados in listaUsuarios)
{
Console.WriteLine($"Id: {usuariosEncontrados.UsuarioId} Nom: {usuariosEncontrados.Nombre} Apell: {usuariosEncontrados.Apellido} Puesto: {usuariosEncontrados.Puesto}");
}
*/

//BUSQUEDA DE USUARIO POR ID
/*
Console.WriteLine("Usuarios que coinciden con id 5");

Usuario? usuarioBuscadoID = usuarioServices.GetById(5);
Console.WriteLine($"Id: {usuarioBuscadoID.UsuarioId} Nom: {usuarioBuscadoID.Nombre} Apell: {usuarioBuscadoID.Apellido} Puesto: {usuarioBuscadoID.Puesto}");

Console.WriteLine("Usuarios que coinciden con nombre Martin10");

IEnumerable <Usuario>? usuarioBuscandoNombreyAp = usuarioServices.GetByNombreyAp("Martin10");

foreach (Usuario usuarioEncontrado in usuarioBuscandoNombreyAp)
{
Console.WriteLine($"Id: {usuarioEncontrado.UsuarioId} Nom: {usuarioEncontrado.Nombre} Apell: {usuarioEncontrado.Apellido} Puesto: {usuarioEncontrado.Puesto}");
}

Console.WriteLine();
*/
//MODIFICAR USUARIO
/*
Usuario? userAModificar = usuarioServices.GetById(2);
userAModificar.Nombre = "Martin Alejandro";

Usuario userModificado = usuarioServices.Update(userAModificar);

Console.WriteLine($"Id: {userModificado.UsuarioId} Nom: {userModificado.Nombre} Apell: {userModificado.Apellido} Puesto: {userModificado.Puesto}");
*/

//ELIMINAR ID 
/*
Usuario? userABorrar = usuarioServices.GetById(5);

int? userBorrado = usuarioServices.Delete(5);

Console.WriteLine(("Se elimino el usuario", $"Id: {userBorrado}"));
*/

//CREATE USUARIO VACIO

try
{
    Usuario usuarioaCrear = new Usuario
    {
        Nombre = " ",
        Apellido = "",
        //puesto vacio
    };

    Usuario usuario1 = usuarioServices.Create(usuarioaCrear);
    Console.WriteLine("Usuario creado con éxito.");
}
catch (ArgumentException error)
{
    Console.WriteLine($"Error al crear usuario:"); 
    Console.WriteLine($"{error.Message}");
}


