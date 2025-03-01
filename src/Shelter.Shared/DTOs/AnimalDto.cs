public class AnimalDto
    {
        public string? Nombre { get; set; }
        public string? Especie { get; set; }
        public int Edad { get; set; }
        public string? EstadoSalud { get; set; }
        public DateTime FechaAdmision { get; set; }
        public string? Estado { get; set; }
        public List<string> Fotos { get; set; } = [];
        
    }