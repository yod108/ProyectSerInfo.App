TUTORIAL INICIAL asp.net core 5.0
Creación proyecto ProyectoSerInfo

    dotnet run: Ejecutar el programa
    dotnet build: Para compilar y revisar errores
    dotnet --version: para revisar la version del sdk de .net

    1)  Descargar e instalar .net core 5.0 https://dotnet.microsoft.com/download

    2)  Instalar Visual Studio Code
           2.1) Instalar extensiones:
                    a) C# For Microsft
                    b) C# Extensions jchannon
                    c) C# Extension JosKreativ

    3) Se debe instalar el Framework Entity de forma global.
           a) dotnet tool install --global dotnet-ef (instalacion del entity Framework)
           b) dotnet tool update --global dotnet-ef (actualizacion del entity Framework)

    4) Instalar la solucion de Entity Framework (el programa que se va a construir)
            (MiprimeraApp es el nombre del programa a   construir)
            dotnet new sln -o MiprimeraApp

    5) Instalar las librerias para generar la conexion con la base de datos e implementar las entidades del programa.
        a) dotnet new classlib -o MipriemraApp.Persistencia
        b) dotnet new classlib -o MipriemraApp.Dominio

    6) Instalar la aplicacion web para crear el frontend del programa
        a) dotnet new webapp -o MiprimeraApp.frontend

    7) Instalar la libreria de consola para realizar pruebas del programa.
        a) dotnet new console -o MiprimeraApp.Consola

    8) Instalacion de paquetes:
                --version 5.0.9 (opción para instalar una version especifica)
        dotnet add package Microsoft.EntityFrameworkCore --version 5.0.10
        dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.10
        dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.10
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.10
    
        a) Carpeta Consola
            dotnet add package Microsoft.EntityFrameworkCore.Design 

        b) Carpeta Frontend

            dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.10

        c) Carpeta Persistencia
            dotnet add package Microsoft.EntityFrameworkCore --version 5.0.10
            dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.10
            dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.10
            dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.10
    
    9) Crear las referencias a las carpetas de persistencia y dominio; siempre y cuando analicemos que uniones debemos realizar dentro de los .csproj

        dotnet add reference ..\MiprimeraApp.Dominio
            a) Carpeta Consola referencia a Persistencia y Dominio
            b) Carpeta Persistencia referencia a Dominio

    10) Crear las entidades en la carpeta Dominio

    11) Crear el AppContext para realizar el mapeo de las entidades para crear la migracion y crear la conexion con la base de datos (SQL Server)

    12) Crear la migracion a la base de datos
        12.1) Si no se tiene migraciones.
            a) dotnet ef migrations add Inicial --startup-project ..\SerInfoConsola.Consola\

        12.2) Si ya existe migraciones
            a) dotnet ef database update --startup-project ..\SerInfoConsola.Consola

    \\Métodos restantes
    Agregar las referencias en Frontend de: Persistencia y Dominio

    dotnet add reference ..\MiprimeraApp.Dominio
    dotnet add reference ..\MiprimeraApp.Persistencia

    Crear nueva pagina Razor:

    dotnet new page -n “Create1”-na SerInfoFrontend.Frontend.Pages -o .\Pages\Clientes

    Metodos IRepositorioPaciente Paciente UpdatePaciente(Paciente paciente); void DeletePaciente(int idPaciente);
    Paciente GetPaciente(int idPaciente);

    DeletePaciente

    public void DeletePaciente(int idPaciente) { var pacienteEncontrado = _appContext.Pacientes.Find(idPaciente); if (pacienteEncontrado == null) return; _appContext.Pacientes.Remove(pacienteEncontrado); _appContext.SaveChanges(); }

    GetPaciente

    public Paciente GetPaciente(int idPaciente) { //return _appContext.Pacientes.Find(idPaciente);

        var paciente = _appContext.Pacientes
                .Where(p => p.Id == idPaciente)
                .Include(p => p.Medico)
                .Include(p=> p.SignosVitales)
                .FirstOrDefault();
        return paciente;
    }

    UpdatePaciente

    public Paciente UpdatePaciente(Paciente paciente)
    {
        var pacienteEncontrado = _appContext.Pacientes.Find(paciente.Id);
        if (pacienteEncontrado != null)
        {
            pacienteEncontrado.Nombre = paciente.Nombre;
            pacienteEncontrado.Apellidos = paciente.Apellidos;
            pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
            pacienteEncontrado.Genero = paciente.Genero;
            pacienteEncontrado.Direccion = paciente.Direccion;
            pacienteEncontrado.Latitud = paciente.Latitud;
            pacienteEncontrado.Longitud = paciente.Longitud;
            pacienteEncontrado.Ciudad = paciente.Ciudad;
            pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
            _appContext.SaveChanges();
        }
        return pacienteEncontrado;
    }