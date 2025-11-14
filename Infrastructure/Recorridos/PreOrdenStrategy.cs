using SPHC.Domain.Entities;
using SPHC.Domain.Interfaces;

namespace SPHC.Infrastructure.Recorridos
{
    /// <summary>
    /// Estrategia de recorrido Pre-orden (Raíz, Izquierda, Derecha)
    /// </summary>
    public class PreOrdenStrategy : IRecorridoStrategy
    {
        public IEnumerable<HistorialClinico> Recorrer(Nodo? raiz)
        {
            if (raiz == null)
                yield break;

            yield return raiz.Historial;

            foreach (var historial in Recorrer(raiz.Izquierdo))
                yield return historial;

            foreach (var historial in Recorrer(raiz.Derecho))
                yield return historial;
        }
    }
}

