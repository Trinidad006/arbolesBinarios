using SPHC.Domain.Entities;
using SPHC.Domain.Interfaces;

namespace SPHC.Application.UseCases
{
    /// <summary>
    /// Caso de uso para obtener la representación visual de la estructura del árbol
    /// </summary>
    public class ObtenerEstructuraArbolUseCase
    {
        private readonly IArbolBinarioBusqueda _arbol;

        public ObtenerEstructuraArbolUseCase(IArbolBinarioBusqueda arbol)
        {
            _arbol = arbol ?? throw new ArgumentNullException(nameof(arbol));
        }

        public string Ejecutar()
        {
            if (_arbol.EstaVacio())
                return "(El árbol está vacío)";

            return ObtenerEstructuraRecursivo(_arbol.Raiz, "", true);
        }

        private string ObtenerEstructuraRecursivo(Nodo? nodo, string prefijo, bool esUltimo)
        {
            if (nodo == null)
                return "";

            string resultado = "";
            string conector = esUltimo ? "└── " : "├── ";
            resultado += prefijo + conector + nodo.Historial.ToString() + "\n";

            string nuevoPrefijo = prefijo + (esUltimo ? "    " : "│   ");

            // Procesar hijos
            bool tieneIzquierdo = nodo.Izquierdo != null;
            bool tieneDerecho = nodo.Derecho != null;

            if (tieneIzquierdo && tieneDerecho)
            {
                resultado += ObtenerEstructuraRecursivo(nodo.Izquierdo, nuevoPrefijo, false);
                resultado += ObtenerEstructuraRecursivo(nodo.Derecho, nuevoPrefijo, true);
            }
            else if (tieneIzquierdo)
            {
                resultado += ObtenerEstructuraRecursivo(nodo.Izquierdo, nuevoPrefijo, true);
            }
            else if (tieneDerecho)
            {
                resultado += ObtenerEstructuraRecursivo(nodo.Derecho, nuevoPrefijo, true);
            }

            return resultado;
        }
    }
}

