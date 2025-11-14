using SPHC.Domain.Entities;

namespace SPHC.Domain.Interfaces
{
    /// <summary>
    /// Interfaz para la estrategia de recorrido del árbol
    /// </summary>
    public interface IRecorridoStrategy
    {
        IEnumerable<HistorialClinico> Recorrer(Nodo? raiz);
    }
}

