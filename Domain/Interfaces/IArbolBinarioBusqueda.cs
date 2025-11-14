using SPHC.Domain.Entities;

namespace SPHC.Domain.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones del Árbol Binario de Búsqueda
    /// </summary>
    public interface IArbolBinarioBusqueda
    {
        Nodo? Raiz { get; }
        void Insertar(HistorialClinico historial);
        bool EstaVacio();
        bool ExisteId(int id);
        void Limpiar();
    }
}

