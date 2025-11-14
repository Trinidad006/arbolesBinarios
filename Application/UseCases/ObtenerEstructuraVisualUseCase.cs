using SPHC.Domain.Entities;
using SPHC.Domain.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace SPHC.Application.UseCases
{
    /// <summary>
    /// Caso de uso para obtener una representación visual mejorada de la estructura del árbol
    /// </summary>
    public class ObtenerEstructuraVisualUseCase
    {
        private readonly IArbolBinarioBusqueda _arbol;

        public ObtenerEstructuraVisualUseCase(IArbolBinarioBusqueda arbol)
        {
            _arbol = arbol ?? throw new ArgumentNullException(nameof(arbol));
        }

        public string Ejecutar()
        {
            if (_arbol.EstaVacio())
                return "(El árbol está vacío)";

            var sb = new StringBuilder();
            sb.AppendLine("ESTRUCTURA DEL ÁRBOL (Vista por Niveles):\n");
            
            // Mostrar por niveles usando BFS
            MostrarPorNiveles(_arbol.Raiz, sb);
            
            sb.AppendLine("\n───────────────────────────────────────────────────────────");
            sb.AppendLine("💡 NOTA: Los nodos están organizados por ID (menor ID = mayor prioridad)");
            sb.AppendLine("📊 Usa 'In-orden' para ver las prioridades en orden correcto.");
            
            return sb.ToString();
        }

        private void MostrarPorNiveles(Nodo? raiz, StringBuilder sb)
        {
            if (raiz == null)
                return;

            Queue<(Nodo nodo, int nivel)> cola = new Queue<(Nodo, int)>();
            cola.Enqueue((raiz, 0));

            int nivelActual = -1;

            while (cola.Count > 0)
            {
                var (nodo, nivel) = cola.Dequeue();

                // Mostrar encabezado de nivel solo una vez
                if (nivel != nivelActual)
                {
                    nivelActual = nivel;
                    if (nivel == 0)
                        sb.AppendLine($"📌 NIVEL {nivel} (RAÍZ):");
                    else
                        sb.AppendLine($"\n📌 NIVEL {nivel}:");
                }

                // Mostrar el nodo con indentación
                string indentacion = new string(' ', nivel * 4);
                sb.AppendLine($"{indentacion}• {nodo.Historial}");

                // Encolar hijos
                if (nodo.Izquierdo != null)
                    cola.Enqueue((nodo.Izquierdo, nivel + 1));

                if (nodo.Derecho != null)
                    cola.Enqueue((nodo.Derecho, nivel + 1));
            }
        }
    }
}

