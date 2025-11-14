namespace SPHC.Domain.Enums
{
    /// <summary>
    /// Tipos de consulta con sus prioridades predefinidas
    /// Menor número = Mayor prioridad
    /// </summary>
    public enum TipoConsulta
    {
        Reanimacion = 1,        // Máxima prioridad
        UCI = 2,
        Emergencia = 3,
        ConsultaUrgente = 4,
        Radiografia = 5,
        Fisioterapia = 6,
        ConsultaRutina = 7,
        AltaMedica = 8          // Menor prioridad
    }
}

