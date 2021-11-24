using System;

namespace ProyectSerInfo.Dominio
{
    public class EvidenciaPC
    {
        public int Id{get; set;}

        public DateTime FechaInicio{get; set;}

        public FallasPc Fallas{get; set;}

        public Equipos Equipos{get; set;}

    }
}