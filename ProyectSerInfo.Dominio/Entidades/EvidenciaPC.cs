using System;

namespace ProyectSerInfo.Dominio.Entidades
{
    public class EvidenciaPC
    {
        public int Id{get; set;}

        public Datetime FechaInicio {get; set;}

        public FallasPc Fallas {get; set;}

        public Equipos Equipos {get; set;}

    }
}