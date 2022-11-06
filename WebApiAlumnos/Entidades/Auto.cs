namespace WebApiAlumnos.Entidades
{
    public class Auto
    {

        public int Id { get; set; }
        public string Modelo { get; set; }

        public List<Agencia> Agencias { get; set; }
    }
}
