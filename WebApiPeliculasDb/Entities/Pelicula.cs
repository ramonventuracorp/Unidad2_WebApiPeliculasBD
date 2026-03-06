namespace WebApiPeliculasDb.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string? Sinopsis { get; set; }
        public DateTime FechaEstreno { get; set; }
        public int Puntuacion { get; set; }
        public int CategoriaId { get; set; }
    }
}
