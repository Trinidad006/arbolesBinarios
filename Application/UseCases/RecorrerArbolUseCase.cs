using SPHC.Domain.Entities;
using SPHC.Domain.Enums;
using SPHC.Domain.Interfaces;

namespace SPHC.Application.UseCases
{
    /// <summary>
    /// Caso de uso para recorrer el árbol según el tipo de recorrido especificado
    /// </summary>
    public class RecorrerArbolUseCase
    {
        private readonly IArbolBinarioBusqueda _arbol;
        private readonly IRecorridoStrategyFactory _factory;

        public RecorrerArbolUseCase(
            IArbolBinarioBusqueda arbol,
            IRecorridoStrategyFactory factory)
        {
            _arbol = arbol ?? throw new ArgumentNullException(nameof(arbol));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IEnumerable<HistorialClinico> Ejecutar(TipoRecorrido tipoRecorrido)
        {
            if (_arbol.EstaVacio())
                return Enumerable.Empty<HistorialClinico>();

            var estrategia = _factory.CrearEstrategia(tipoRecorrido);
            return estrategia.Recorrer(_arbol.Raiz);
        }
    }
}

