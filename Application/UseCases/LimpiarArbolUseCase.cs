using SPHC.Domain.Interfaces;

namespace SPHC.Application.UseCases
{
    /// <summary>
    /// Caso de uso para limpiar todos los datos del árbol
    /// </summary>
    public class LimpiarArbolUseCase
    {
        private readonly IArbolBinarioBusqueda _arbol;

        public LimpiarArbolUseCase(IArbolBinarioBusqueda arbol)
        {
            _arbol = arbol ?? throw new ArgumentNullException(nameof(arbol));
        }

        public void Ejecutar()
        {
            _arbol.Limpiar();
        }
    }
}

