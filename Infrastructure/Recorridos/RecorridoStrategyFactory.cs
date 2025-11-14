using SPHC.Domain.Enums;
using SPHC.Domain.Interfaces;

namespace SPHC.Infrastructure.Recorridos
{
    /// <summary>
    /// Factory concreta para crear estrategias de recorrido
    /// </summary>
    public class RecorridoStrategyFactory : IRecorridoStrategyFactory
    {
        public IRecorridoStrategy CrearEstrategia(TipoRecorrido tipoRecorrido)
        {
            return tipoRecorrido switch
            {
                TipoRecorrido.PreOrden => new PreOrdenStrategy(),
                TipoRecorrido.InOrden => new InOrdenStrategy(),
                TipoRecorrido.PostOrden => new PostOrdenStrategy(),
                TipoRecorrido.PorNivel => new PorNivelStrategy(),
                _ => throw new ArgumentException($"Tipo de recorrido no soportado: {tipoRecorrido}", nameof(tipoRecorrido))
            };
        }
    }
}

