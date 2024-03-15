namespace ProyectoEstetica.Models
{
    public class Publicacion
    {
        public int Id { get; set; } 
        public string Titulo { get; set; } = string.Empty;
        public string Subtitulo { get; set; } = string.Empty;

        public string Cuerpo { get; set; } = string.Empty;
        public string Cuerpo1 { get; set; } = string.Empty;
        public string Cuerpo2 { get; set; } = string.Empty;
        public DateTime Creacion { get; set; } = DateTime.Now;
        public string Imagen1 { get; set; } = string.Empty;
        public string Imagen2 { get; set; } = string.Empty;

        public string Imagen3 { get; set; } = string.Empty;
        public string Imagen4 { get; set; } = string.Empty;
        public string Imagen5 { get; set; } = string.Empty;
    }
}
