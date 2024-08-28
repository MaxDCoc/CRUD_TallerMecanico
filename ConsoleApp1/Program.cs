// See https://aka.ms/new-console-template for more information
//using TallerModel;

//UsuarioServices usuarioServices = new UsuarioServices();

//CREAR USUARIOS

/* for (int i = 1; i <= 9; i++)
{
Usuario usuarioaCrear = new Usuario();
    usuarioaCrear.Nombre = $"Martin{i}";
    usuarioaCrear.Apellido = $"LOPEZ SOTO{i}";
    usuarioaCrear.dni = $"45.022.00{i}";
    usuarioaCrear.cuil = $"20-4502200{i}";
    usuarioaCrear.telefono = $"3777-00000{i}";
    usuarioaCrear.Puesto = Rango.Mecanico;

    Usuario usuarioCreado = usuarioServices.Create(usuarioaCrear);
    Console.WriteLine($"Id: {usuarioCreado.UsuarioId} Desc: {usuarioCreado.Nombre} {usuarioCreado.Apellido} {usuarioCreado.dni} {usuarioCreado.cuil} {usuarioCreado.telefono} {usuarioCreado.Puesto} ");
}
*/

//OBTENER LISTA DE USUARIOS
/*
IEnumerable<Usuario> listaUsuarios = usuarioServices.GetAll();
Console.WriteLine("All Usuarios in database:");
foreach (Usuario usuariosEncontrado in listaUsuarios)
{
Console.WriteLine($"Id: {usuariosEncontrado.UsuarioId} Nom: {usuariosEncontrado.Nombre} Apell: {usuariosEncontrado.Apellido} Puesto: {usuariosEncontrado.Puesto}");
}
*/

//BUSQUEDA DE USUARIO POR ID

/*
Console.WriteLine("Usuarios que coinciden con id 92");

Usuario? usuarioBuscadoID = usuarioServices.GetById(92);
Console.WriteLine($"Id: {usuarioBuscadoID.UsuarioId} Nom: {usuarioBuscadoID.Nombre} Apell: {usuarioBuscadoID.Apellido} Puesto: {usuarioBuscadoID.Puesto}");
*/

//BUSQUEDA DE USUARIO POR NOMBRE Y AP
/*

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
Usuario? userAModificar = usuarioServices.GetById(92);
Console.WriteLine("Usuario a Modificar");
Console.WriteLine($"Id: {userAModificar.UsuarioId} Nom: {userAModificar.Nombre} Apell: {userAModificar.Apellido} Puesto: {userAModificar.Puesto}");

userAModificar.Nombre = "Martin Alejandro";
userAModificar.Apellido = "Lopez Soto";
userAModificar.Puesto = Rango.Gerente;


Usuario userModificado = usuarioServices.Update(userAModificar);

Console.WriteLine("Usuario Modificado");
Console.WriteLine($"Id: {userModificado.UsuarioId} Nom: {userModificado.Nombre} Apell: {userModificado.Apellido} Puesto: {userModificado.Puesto}");
*/

//ELIMINAR ID 
/*
Usuario? userABorrar = usuarioServices.GetById(92);

int? userBorrado = usuarioServices.Delete(92);

Console.WriteLine("Se elimino el usuario", $"Id: {userBorrado}");
*/

//CREATE USUARIO VACIO

/* try
{
    Usuario usuarioaCrear = new Usuario
    {
        Nombre = " ",
        Apellido = " ",
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
*/