using SPHC.Domain.Entities;
using SPHC.Domain.Interfaces;

namespace SPHC.Infrastructure.Recorridos
{
    /// <summary>
    /// Estrategia de recorrido Post-orden (Izquierda, Derecha, Raíz)
    /// Útil para eliminación segura de nodos
    /// </summary>
    public class PostOrdenStrategy : IRecorridoStrategy
    {
        public IEnumerable<HistorialClinico> Recorrer(Nodo? raiz)
        {
            if (raiz == null)
                yield break;

            foreach (var historial in Recorrer(raiz.Izquierdo))
                yield return historial;

            foreach (var historial in Recorrer(raiz.Derecho))
                yield return historial;

            yield return raiz.Historial;
        }
    }
}

