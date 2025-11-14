using System.Collections.Generic;
using SPHC.Domain.Entities;
using SPHC.Domain.Interfaces;

namespace SPHC.Infrastructure.Recorridos
{
    /// <summary>
    /// Estrategia de recorrido Por Nivel (BFS - Breadth First Search)
    /// Muestra las solicitudes por antigüedad de inserción relativa
    /// </summary>
    public class PorNivelStrategy : IRecorridoStrategy
    {
        public IEnumerable<HistorialClinico> Recorrer(Nodo? raiz)
        {
            if (raiz == null)
                yield break;

            Queue<Nodo> cola = new Queue<Nodo>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                Nodo nodoActual = cola.Dequeue();
                yield return nodoActual.Historial;

                if (nodoActual.Izquierdo != null)
                    cola.Enqueue(nodoActual.Izquierdo);

                if (nodoActual.Derecho != null)
                    cola.Enqueue(nodoActual.Derecho);
            }
        }
    }
}

