using SPHC.Application.UseCases;
using SPHC.Domain.Interfaces;
using SPHC.Infrastructure.ArbolBinarioBusqueda;
using SPHC.Infrastructure.Recorridos;
using SPHC.Presentation.WindowsForms;

namespace SPHC.Presentation
{
    /// <summary>
    /// Punto de entrada de la aplicación
    /// Configuración de dependencias e inicio del sistema
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Para habilitar estilos visuales de Windows Forms
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.SetHighDpiMode(System.Windows.Forms.HighDpiMode.SystemAware);

            // Configuración de dependencias (Dependency Injection manual)
            IArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
            IRecorridoStrategyFactory factory = new RecorridoStrategyFactory();

            // Inicialización de casos de uso
            var insertarUseCase = new InsertarHistorialUseCase(arbol);
            var recorrerUseCase = new RecorrerArbolUseCase(arbol, factory);
            var obtenerEstructuraUseCase = new ObtenerEstructuraArbolUseCase(arbol);
            var obtenerEstructuraVisualUseCase = new ObtenerEstructuraVisualUseCase(arbol);
            var limpiarArbolUseCase = new LimpiarArbolUseCase(arbol);

            // Inicialización y ejecución de la aplicación Windows Forms
            System.Windows.Forms.Application.Run(new MainForm(insertarUseCase, recorrerUseCase, obtenerEstructuraUseCase, obtenerEstructuraVisualUseCase, limpiarArbolUseCase));
        }
    }
}

