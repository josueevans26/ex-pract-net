namespace Ex1.Models
{
    public class Encuestas
    {
        public int Id { get; set; }
        public string? Respuesta1 { get; set; }
        public string? Respuesta2 { get; set; }
        public string? Respuesta3 { get; set; }
        public string? Respuesta4 { get; set; }
        public string? Respuesta5 { get; set; }

        public string? Respuesta5_1 { get; set; } // Se almacenarán como una cadena separada por comas
        public string? Respuesta5_2 { get; set; } // Se almacenarán como una cadena separada por comas

        public string? Respuesta6 { get; set; }
        public string? Respuesta7 { get; set; }
        public string? Respuesta8 { get; set; }
    }
}