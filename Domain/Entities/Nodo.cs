namespace SPHC.Domain.Entities
{
    /// <summary>
    /// Nodo del árbol binario que contiene un Historial Clínico
    /// </summary>
    public class Nodo
    {
        public HistorialClinico Historial { get; set; }
        public Nodo? Izquierdo { get; set; }
        public Nodo? Derecho { get; set; }

        public Nodo(HistorialClinico historial)
        {
            Historial = historial ?? throw new ArgumentNullException(nameof(historial));
            Izquierdo = null;
            Derecho = null;
        }

        public bool EsHoja => Izquierdo == null && Derecho == null;

        public override string ToString()
        {
            return Historial.ToString();
        }
    }
}

