using SPHC.Domain.Entities;
using SPHC.Domain.Interfaces;

namespace SPHC.Infrastructure.ArbolBinarioBusqueda
{
    /// <summary>
    /// Implementación concreta del Árbol Binario de Búsqueda
    /// </summary>
    public class ArbolBinarioBusqueda : IArbolBinarioBusqueda
    {
        public Nodo? Raiz { get; private set; }

        public ArbolBinarioBusqueda()
        {
            Raiz = null;
        }

        public void Insertar(HistorialClinico historial)
        {
            if (historial == null)
                throw new ArgumentNullException(nameof(historial));

            Raiz = InsertarRecursivo(Raiz, historial);
        }

        public bool EstaVacio()
        {
            return Raiz == null;
        }

        public bool ExisteId(int id)
        {
            return BuscarIdRecursivo(Raiz, id);
        }

        public void Limpiar()
        {
            Raiz = null;
        }

        private bool BuscarIdRecursivo(Nodo? raiz, int id)
        {
            if (raiz == null)
                return false;

            if (raiz.Historial.Id == id)
                return true;

            if (id < raiz.Historial.Id)
                return BuscarIdRecursivo(raiz.Izquierdo, id);
            else
                return BuscarIdRecursivo(raiz.Derecho, id);
        }

        private Nodo? InsertarRecursivo(Nodo? raiz, HistorialClinico historial)
        {
            if (raiz == null)
            {
                return new Nodo(historial);
            }

            if (historial.Id < raiz.Historial.Id)
            {
                raiz.Izquierdo = InsertarRecursivo(raiz.Izquierdo, historial);
            }
            else if (historial.Id > raiz.Historial.Id)
            {
                raiz.Derecho = InsertarRecursivo(raiz.Derecho, historial);
            }
            // Si el ID es igual, no se inserta (no se permiten IDs duplicados)

            return raiz;
        }
    }
}

