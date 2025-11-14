using SPHC.Domain.Enums;

namespace SPHC.Domain.Entities
{
    /// <summary>
    /// Entidad del dominio que representa un Historial Clínico Digital (HCD)
    /// </summary>
    public class HistorialClinico
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        public TipoConsulta TipoConsulta { get; private set; }
        public int Prioridad => (int)TipoConsulta;

        public HistorialClinico(int id, string descripcion, TipoConsulta tipoConsulta)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(descripcion));

            Id = id;
            Descripcion = descripcion;
            TipoConsulta = tipoConsulta;
        }

        public override string ToString()
        {
            return $"[ID:{Id} | {TipoConsulta} | {Descripcion}]";
        }
    }
}


