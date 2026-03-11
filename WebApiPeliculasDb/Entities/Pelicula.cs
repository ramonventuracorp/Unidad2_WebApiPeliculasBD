namespace WebApiPeliculasDb.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Sinopsis { get; set; }
        public DateTime FechaEstreno { get; set; }
        public int Puntuacion { get; set; }
        public int CategoriaId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAgrega { get; set; }
    }
}
