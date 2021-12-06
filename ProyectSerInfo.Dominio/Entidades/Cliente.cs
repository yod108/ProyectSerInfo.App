using System;
using System.Collections.Generic;

namespace ProyectSerInfo.Dominio
{
    public class Cliente : Persona
    {
        public string Direccion {get; set;}

        public string Ciudad {get; set;}

        public DateTime FechaIngreso {get; set;}

        public Tecnico Tecnico {get; set;}

        public string Marca {get; set;}

        public List<EvidenciaPc> EvidenciaPcs {get; set;}        
    }
}