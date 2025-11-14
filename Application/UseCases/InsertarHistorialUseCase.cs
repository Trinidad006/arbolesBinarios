using SPHC.Domain.Entities;
using SPHC.Domain.Enums;
using SPHC.Domain.Interfaces;
using System.Collections.Generic;

namespace SPHC.Application.UseCases
{
    /// <summary>
    /// Caso de uso para insertar un nuevo historial clínico en el árbol
    /// </summary>
    public class InsertarHistorialUseCase
    {
        private readonly IArbolBinarioBusqueda _arbol;
        private static Dictionary<TipoConsulta, int> _contadoresPorTipo = new Dictionary<TipoConsulta, int>();

        public InsertarHistorialUseCase(IArbolBinarioBusqueda arbol)
        {
            _arbol = arbol ?? throw new ArgumentNullException(nameof(arbol));
        }

        public void Ejecutar(TipoConsulta tipoConsulta, string descripcion)
        {
            // Sistema de ID automático:
            // ID = (Prioridad * 1,000,000) + ContadorSecuencialPorTipo
            // Esto asegura:
            // - Reanimación (1): IDs 1000001, 1000002, 1000003...
            // - UCI (2): IDs 2000001, 2000002, 2000003...
            // - Emergencia (3): IDs 3000001, 3000002, 3000003...
            // - etc.
            
            int prioridad = (int)tipoConsulta;
            int idBase = prioridad * 1_000_000;
            
            // Obtener o inicializar el contador para este tipo de consulta
            if (!_contadoresPorTipo.ContainsKey(tipoConsulta))
            {
                _contadoresPorTipo[tipoConsulta] = 0;
            }
            
            // Incrementar el contador para este tipo
            _contadoresPorTipo[tipoConsulta]++;
            int idAutomatico = idBase + _contadoresPorTipo[tipoConsulta];

            // Si el ID ya existe (colisión), incrementar +1 hasta encontrar uno disponible
            // Esto asegura que si hay múltiples consultas del mismo tipo, se les asignen IDs consecutivos
            // Ejemplo: Si 1000001 existe, intentar 1000002, luego 1000003, etc.
            while (_arbol.ExisteId(idAutomatico))
            {
                _contadoresPorTipo[tipoConsulta]++;
                idAutomatico = idBase + _contadoresPorTipo[tipoConsulta];
                
                // Protección: evitar bucle infinito (máximo 999,999 IDs por tipo)
                if (_contadoresPorTipo[tipoConsulta] > 999_999)
                {
                    // Si se excede el rango, usar timestamp para garantizar unicidad
                    idAutomatico = idBase + (int)(DateTime.Now.Ticks % 999_999) + 1;
                    if (!_arbol.ExisteId(idAutomatico))
                        break;
                    // Si aún existe, agregar un pequeño delay y reintentar
                    System.Threading.Thread.Sleep(1);
                    idAutomatico = idBase + (int)(DateTime.Now.Ticks % 999_999) + 1;
                    break;
                }
            }

            var historial = new HistorialClinico(idAutomatico, descripcion, tipoConsulta);
            _arbol.Insertar(historial);
        }
    }
}


