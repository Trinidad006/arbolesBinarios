using SPHC.Domain.Entities;
using SPHC.Domain.Interfaces;

namespace SPHC.Infrastructure.Recorridos
{
    /// <summary>
    /// Estrategia de recorrido In-orden (Izquierda, Raíz, Derecha)
    /// Genera el reporte oficial de prioridades en orden ascendente
    /// </summary>
    public class InOrdenStrategy : IRecorridoStrategy
    {
        public IEnumerable<HistorialClinico> Recorrer(Nodo? raiz)
        {
            if (raiz == null)
                yield break;

            foreach (var historial in Recorrer(raiz.Izquierdo))
                yield return historial;

            yield return raiz.Historial;

            foreach (var historial in Recorrer(raiz.Derecho))
                yield return historial;
        }
    }
}

