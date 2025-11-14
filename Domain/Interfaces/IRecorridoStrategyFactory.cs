using SPHC.Domain.Enums;

namespace SPHC.Domain.Interfaces
{
    /// <summary>
    /// Factory para crear estrategias de recorrido
    /// </summary>
    public interface IRecorridoStrategyFactory
    {
        IRecorridoStrategy CrearEstrategia(TipoRecorrido tipoRecorrido);
    }
}

