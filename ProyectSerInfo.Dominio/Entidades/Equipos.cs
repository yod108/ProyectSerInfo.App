using System;
using System.Collections.Generic;

namespace ProyectSerInfo.Dominio
{
    public class Equipos : Persona
    {
        public string Direccion {get; set;}

        public string Ciudad {get; set;}

        public string Datetime FechaIngreso {get; set;}
    }
}