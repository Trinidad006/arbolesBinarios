using System.Windows.Forms;
using SPHC.Application.UseCases;
using SPHC.Domain.Enums;

namespace SPHC.Presentation.WindowsForms
{
    /// <summary>
    /// Formulario principal de la aplicación Windows Forms
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly InsertarHistorialUseCase _insertarUseCase;
        private readonly RecorrerArbolUseCase _recorrerUseCase;
        private readonly ObtenerEstructuraArbolUseCase _obtenerEstructuraUseCase;
        private readonly ObtenerEstructuraVisualUseCase _obtenerEstructuraVisualUseCase;
        private readonly LimpiarArbolUseCase _limpiarArbolUseCase;

        private ComboBox cmbTipoConsulta = null!;
        private TextBox txtDescripcion = null!;
        private Button btnInsertar = null!;
        private Button btnCargarDatosPrueba = null!;
        private RichTextBox txtResultado = null!;
        private ComboBox cmbTipoRecorrido = null!;
        private Button btnRecorrer = null!;
        private Button btnVerEstructura = null!;
        private Button btnVerEstructuraVisual = null!;
        private Button btnLimpiar = null!;
        private Label lblTitulo = null!;
        private GroupBox grpInsertar = null!;
        private GroupBox grpRecorridos = null!;

        public MainForm(
            InsertarHistorialUseCase insertarUseCase,
            RecorrerArbolUseCase recorrerUseCase,
            ObtenerEstructuraArbolUseCase obtenerEstructuraUseCase,
            ObtenerEstructuraVisualUseCase obtenerEstructuraVisualUseCase,
            LimpiarArbolUseCase limpiarArbolUseCase)
        {
            _insertarUseCase = insertarUseCase ?? throw new ArgumentNullException(nameof(insertarUseCase));
            _recorrerUseCase = recorrerUseCase ?? throw new ArgumentNullException(nameof(recorrerUseCase));
            _obtenerEstructuraUseCase = obtenerEstructuraUseCase ?? throw new ArgumentNullException(nameof(obtenerEstructuraUseCase));
            _obtenerEstructuraVisualUseCase = obtenerEstructuraVisualUseCase ?? throw new ArgumentNullException(nameof(obtenerEstructuraVisualUseCase));
            _limpiarArbolUseCase = limpiarArbolUseCase ?? throw new ArgumentNullException(nameof(limpiarArbolUseCase));

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configuración del formulario
            this.Text = "Sistema de Priorización de Historiales Clínicos (SPHC)";
            this.Size = new Size(1060, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(255, 245, 250); // Fondo rosa muy claro

            // Título
            lblTitulo = new Label
            {
                Text = "Sistema de Priorización de Historiales Clínicos (SPHC) 💕",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20),
                ForeColor = Color.FromArgb(219, 112, 147) // Rosa oscuro
            };

            // Grupo: Insertar Historial
            grpInsertar = new GroupBox
            {
                Text = "Insertar Historial Clínico 💗",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 70),
                Size = new Size(1020, 120),
                ForeColor = Color.FromArgb(219, 112, 147), // Rosa oscuro
                BackColor = Color.FromArgb(255, 240, 245) // Rosa muy claro
            };

            Label lblTipoConsulta = new Label
            {
                Text = "Tipo de Consulta (Prioridad automática):",
                Location = new Point(20, 30),
                AutoSize = true,
                ForeColor = Color.FromArgb(199, 21, 133) // Rosa magenta
            };

            cmbTipoConsulta = new ComboBox
            {
                Location = new Point(20, 55),
                Size = new Size(280, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(199, 21, 133)
            };
            cmbTipoConsulta.Items.AddRange(new string[]
            {
                "1. Reanimación (Máxima Prioridad)",
                "2. UCI",
                "3. Emergencia",
                "4. Consulta Urgente",
                "5. Radiografía",
                "6. Fisioterapia",
                "7. Consulta Rutina",
                "8. Alta Médica (Menor Prioridad)"
            });
            cmbTipoConsulta.SelectedIndex = 0;

            Label lblDescripcion = new Label
            {
                Text = "Descripción:",
                Location = new Point(320, 30),
                AutoSize = true,
                ForeColor = Color.FromArgb(199, 21, 133) // Rosa magenta
            };

            txtDescripcion = new TextBox
            {
                Location = new Point(320, 55),
                Size = new Size(400, 25),
                Font = new Font("Segoe UI", 9),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(199, 21, 133)
            };
            txtDescripcion.TextChanged += TxtDescripcion_TextChanged;
            txtDescripcion.Enter += TxtDescripcion_Enter;

            btnInsertar = new Button
            {
                Text = "Insertar 💕",
                Location = new Point(740, 50),
                Size = new Size(120, 35),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 182, 193), // Rosa claro
                ForeColor = Color.FromArgb(199, 21, 133), // Rosa magenta
                FlatStyle = FlatStyle.Flat
            };
            btnInsertar.Click += BtnInsertar_Click;

            btnCargarDatosPrueba = new Button
            {
                Text = "Cargar Datos de Prueba 🌸",
                Location = new Point(870, 50),
                Size = new Size(140, 35),
                Font = new Font("Segoe UI", 9),
                BackColor = Color.FromArgb(255, 192, 203), // Rosa
                ForeColor = Color.FromArgb(199, 21, 133), // Rosa magenta
                FlatStyle = FlatStyle.Flat
            };
            btnCargarDatosPrueba.Click += BtnCargarDatosPrueba_Click;

            grpInsertar.Controls.AddRange(new Control[] { lblTipoConsulta, cmbTipoConsulta, lblDescripcion, txtDescripcion, btnInsertar, btnCargarDatosPrueba });

            // Grupo: Recorridos
            grpRecorridos = new GroupBox
            {
                Text = "Recorridos del Árbol 🌺",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 210),
                Size = new Size(1020, 110),
                ForeColor = Color.FromArgb(219, 112, 147), // Rosa oscuro
                BackColor = Color.FromArgb(255, 240, 245) // Rosa muy claro
            };

            Label lblTipoRecorrido = new Label
            {
                Text = "Tipo de Recorrido:",
                Location = new Point(20, 30),
                AutoSize = true,
                ForeColor = Color.FromArgb(199, 21, 133) // Rosa magenta
            };

            cmbTipoRecorrido = new ComboBox
            {
                Location = new Point(20, 55),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(199, 21, 133)
            };
            cmbTipoRecorrido.Items.AddRange(new string[]
            {
                "In-orden (Reporte Oficial de Prioridades)",
                "Pre-orden (Vista de Respaldo)",
                "Post-orden (Eliminación Segura)",
                "Por Nivel (BFS - Amplitud)"
            });
            cmbTipoRecorrido.SelectedIndex = 0;

            btnRecorrer = new Button
            {
                Text = "Ejecutar Recorrido 💖",
                Location = new Point(340, 50),
                Size = new Size(130, 35),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 182, 193), // Rosa claro
                ForeColor = Color.FromArgb(199, 21, 133), // Rosa magenta
                FlatStyle = FlatStyle.Flat
            };
            btnRecorrer.Click += BtnRecorrer_Click;

            btnVerEstructura = new Button
            {
                Text = "Ver Estructura (Árbol) 🌸",
                Location = new Point(480, 30),
                Size = new Size(160, 30),
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 192, 203), // Rosa
                ForeColor = Color.FromArgb(199, 21, 133), // Rosa magenta
                FlatStyle = FlatStyle.Flat
            };
            btnVerEstructura.Click += BtnVerEstructura_Click;

            btnVerEstructuraVisual = new Button
            {
                Text = "Ver Estructura (Niveles) 🌺",
                Location = new Point(480, 65),
                Size = new Size(160, 30),
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                BackColor = Color.FromArgb(255, 182, 193), // Rosa claro
                ForeColor = Color.FromArgb(199, 21, 133), // Rosa magenta
                FlatStyle = FlatStyle.Flat
            };
            btnVerEstructuraVisual.Click += BtnVerEstructuraVisual_Click;

            btnLimpiar = new Button
            {
                Text = "Limpiar 🌺",
                Location = new Point(650, 50),
                Size = new Size(100, 35),
                Font = new Font("Segoe UI", 9),
                BackColor = Color.FromArgb(255, 105, 180), // Rosa hot pink
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLimpiar.Click += BtnLimpiar_Click;

            grpRecorridos.Controls.AddRange(new Control[] { lblTipoRecorrido, cmbTipoRecorrido, btnRecorrer, btnVerEstructura, btnVerEstructuraVisual, btnLimpiar });

            // Área de resultados
            Label lblResultado = new Label
            {
                Text = "Resultados: 💕",
                Location = new Point(20, 330),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(219, 112, 147) // Rosa oscuro
            };

            txtResultado = new RichTextBox
            {
                Location = new Point(20, 360),
                Size = new Size(1020, 280),
                Font = new Font("Consolas", 10),
                ReadOnly = true,
                BackColor = Color.FromArgb(255, 250, 250), // Fondo casi blanco con tinte rosa
                ForeColor = Color.FromArgb(199, 21, 133), // Rosa magenta
                BorderStyle = BorderStyle.FixedSingle
            };

            // Agregar controles al formulario
            this.Controls.AddRange(new Control[]
            {
                lblTitulo,
                grpInsertar,
                grpRecorridos,
                lblResultado,
                txtResultado
            });

            this.ResumeLayout(false);
        }

        private void BtnInsertar_Click(object? sender, EventArgs e)
        {
            // Validar que se haya seleccionado un tipo de consulta
            if (cmbTipoConsulta.SelectedIndex < 0)
            {
                MessageBox.Show("⚠️ ERROR: Debe seleccionar un tipo de consulta.\n\nPor favor, seleccione un tipo de la lista.", 
                    "Tipo de Consulta Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoConsulta.Focus();
                return;
            }

            // Validar que el campo Descripción no esté vacío
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("⚠️ ERROR: El campo Descripción es obligatorio.\n\nPor favor, ingrese una descripción antes de continuar.", 
                    "Campo Obligatorio - Descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.BackColor = Color.FromArgb(255, 182, 193); // Rosa claro para error
                txtDescripcion.Focus();
                return;
            }

            // Restaurar color normal del campo
            txtDescripcion.BackColor = SystemColors.Window;

            try
            {
                // Obtener el tipo de consulta seleccionado (el índice + 1 corresponde al enum)
                TipoConsulta tipoConsulta = (TipoConsulta)(cmbTipoConsulta.SelectedIndex + 1);
                string descripcion = txtDescripcion.Text.Trim();
                
                // Insertar (el ID se asigna automáticamente)
                _insertarUseCase.Ejecutar(tipoConsulta, descripcion);
                
                // Limpiar campo después de insertar exitosamente
                txtDescripcion.Clear();
                txtDescripcion.Focus();

                MessageBox.Show($"✓ Historial clínico agregado correctamente.\n\nTipo: {tipoConsulta}\nDescripción: {descripcion}\n\n(El ID se asignó automáticamente según la prioridad)", 
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"❌ ERROR: {ex.Message}\n\nPor favor, verifique los datos e intente nuevamente.", 
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ ERROR INESPERADO: {ex.Message}\n\nPor favor, contacte al administrador del sistema.", 
                    "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCargarDatosPrueba_Click(object? sender, EventArgs e)
        {
            try
            {
                // Cargar datos de prueba con diferentes tipos de consulta y descripciones
                _insertarUseCase.Ejecutar(TipoConsulta.Reanimacion, "Paciente inconsciente en sala de emergencias");
                _insertarUseCase.Ejecutar(TipoConsulta.Emergencia, "Paciente con síntomas graves de infarto");
                _insertarUseCase.Ejecutar(TipoConsulta.ConsultaUrgente, "Consulta médica urgente - fiebre alta");
                _insertarUseCase.Ejecutar(TipoConsulta.ConsultaRutina, "Control médico de rutina - paciente estable");
                _insertarUseCase.Ejecutar(TipoConsulta.Radiografia, "Solicitud de radiografía de tórax");

                MessageBox.Show("Datos de prueba cargados correctamente 💕\n\n" +
                    "5 historiales clínicos han sido agregados al árbol.\n\n" +
                    "Los IDs se asignaron automáticamente según el tipo de consulta.", 
                    "Datos Cargados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRecorrer_Click(object? sender, EventArgs e)
        {
            try
            {
                TipoRecorrido tipoRecorrido = cmbTipoRecorrido.SelectedIndex switch
                {
                    0 => TipoRecorrido.InOrden,
                    1 => TipoRecorrido.PreOrden,
                    2 => TipoRecorrido.PostOrden,
                    3 => TipoRecorrido.PorNivel,
                    _ => TipoRecorrido.InOrden
                };

                var historiales = _recorrerUseCase.Ejecutar(tipoRecorrido);
                var listaHistoriales = historiales.ToList();

                txtResultado.Clear();
                txtResultado.AppendText($"═══════════════════════════════════════════════════════════\n");
                txtResultado.AppendText($"Tipo de Recorrido: {cmbTipoRecorrido.Text}\n");
                txtResultado.AppendText($"═══════════════════════════════════════════════════════════\n\n");

                if (listaHistoriales.Count == 0)
                {
                    txtResultado.AppendText("(El árbol está vacío)\n");
                    txtResultado.AppendText("\nPor favor, inserte historiales clínicos primero.\n");
                }
                else
                {
                    txtResultado.AppendText($"Total de historiales: {listaHistoriales.Count}\n\n");
                    txtResultado.AppendText("Resultado del recorrido:\n");
                    txtResultado.AppendText("───────────────────────────────────────────────────────────\n");

                    foreach (var historial in listaHistoriales)
                    {
                        txtResultado.AppendText($"{historial} ");
                    }

                    txtResultado.AppendText("\n\n───────────────────────────────────────────────────────────\n");

                    if (tipoRecorrido == TipoRecorrido.InOrden)
                    {
                        txtResultado.AppendText($"\n📊 Prioridad: ID {listaHistoriales.First().Id} (Máxima) → ID {listaHistoriales.Last().Id} (Mínima)\n");
                    }
                    else if (tipoRecorrido == TipoRecorrido.PorNivel)
                    {
                        txtResultado.AppendText("\n📊 Las solicitudes de un mismo nivel son procesadas juntas.\n");
                    }
                }

                txtResultado.AppendText($"\n═══════════════════════════════════════════════════════════\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar recorrido: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerEstructura_Click(object? sender, EventArgs e)
        {
            try
            {
                string estructura = _obtenerEstructuraUseCase.Ejecutar();

                txtResultado.Clear();
                txtResultado.AppendText("═══════════════════════════════════════════════════════════\n");
                txtResultado.AppendText("ESTRUCTURA DEL ÁRBOL (Formato Árbol) 🌳\n");
                txtResultado.AppendText("═══════════════════════════════════════════════════════════\n\n");
                txtResultado.AppendText("Leyenda:\n");
                txtResultado.AppendText("  ├── Nodo con hermano siguiente\n");
                txtResultado.AppendText("  └── Último nodo del nivel\n");
                txtResultado.AppendText("  │   Conexión vertical\n\n");
                txtResultado.AppendText("Estructura:\n");
                txtResultado.AppendText("───────────────────────────────────────────────────────────\n");
                txtResultado.AppendText(estructura);
                txtResultado.AppendText("───────────────────────────────────────────────────────────\n");
                txtResultado.AppendText("\n💡 TIP: Usa 'Ver Estructura (Niveles)' para una vista más clara por niveles.\n");
                txtResultado.AppendText("\n═══════════════════════════════════════════════════════════\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener estructura: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerEstructuraVisual_Click(object? sender, EventArgs e)
        {
            try
            {
                string estructura = _obtenerEstructuraVisualUseCase.Ejecutar();

                txtResultado.Clear();
                txtResultado.AppendText("═══════════════════════════════════════════════════════════\n");
                txtResultado.AppendText("ESTRUCTURA DEL ÁRBOL (Vista por Niveles) 📊\n");
                txtResultado.AppendText("═══════════════════════════════════════════════════════════\n\n");
                txtResultado.AppendText(estructura);
                txtResultado.AppendText("\n═══════════════════════════════════════════════════════════\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener estructura visual: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtDescripcion_TextChanged(object? sender, EventArgs e)
        {
            // Restaurar color normal cuando el usuario empiece a escribir
            if (txtDescripcion.BackColor != SystemColors.Window)
            {
                txtDescripcion.BackColor = SystemColors.Window;
            }
        }

        private void TxtDescripcion_Enter(object? sender, EventArgs e)
        {
            // Restaurar color normal cuando el campo recibe el foco
            txtDescripcion.BackColor = SystemColors.Window;
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            try
            {
                // Preguntar confirmación antes de eliminar todos los datos
                var respuesta = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar TODOS los datos del árbol?\n\n" +
                    "Esta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    // Limpiar el árbol (eliminar todos los datos)
                    _limpiarArbolUseCase.Ejecutar();

                    // Limpiar el área de resultados
                    if (txtResultado != null)
                    {
                        txtResultado.Clear();
                        txtResultado.AppendText("═══════════════════════════════════════════════════════════\n");
                        txtResultado.AppendText("ÁRBOL LIMPIADO EXITOSAMENTE ✅\n");
                        txtResultado.AppendText("═══════════════════════════════════════════════════════════\n\n");
                        txtResultado.AppendText("Todos los historiales clínicos han sido eliminados.\n");
                        txtResultado.AppendText("El árbol está vacío ahora.\n\n");
                        txtResultado.AppendText("Puedes empezar a insertar nuevos datos.\n");
                        txtResultado.AppendText("\n═══════════════════════════════════════════════════════════\n");
                    }

                    MessageBox.Show("✓ Todos los datos han sido eliminados correctamente.\n\nEl árbol está vacío ahora.",
                        "Datos Eliminados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar el árbol: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

