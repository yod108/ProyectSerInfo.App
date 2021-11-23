namespace ProyectSerInfo.Dominio
{
    public class Persona
    {
        //identificador único de cada persona
        public int Id{get; set;}

        public string Nombre{get; set;}

        public string Apellido{get; set;}

        public string Celular{get; set;}
        
        //Genero de la persona
        public Genero Genero {get; set;}
    }
}