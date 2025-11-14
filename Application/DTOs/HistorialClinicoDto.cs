namespace SPHC.Application.DTOs
{
    /// <summary>
    /// DTO para transferir datos de Historial Clínico entre capas
    /// </summary>
    public class HistorialClinicoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public HistorialClinicoDto(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}

