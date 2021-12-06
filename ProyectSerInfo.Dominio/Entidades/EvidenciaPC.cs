using System;

namespace ProyectSerInfo.Dominio
{
    public class EvidenciaPc
    {
        public int Id{get; set;}

        public DateTime FechaInicio{get; set;}

        public FallasPc Fallas{get; set;}

        public Cliente Cliente{get; set;}

    }
}