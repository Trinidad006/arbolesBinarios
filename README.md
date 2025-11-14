# Sistema de Priorización de Historiales Clínicos (SPHC)

Sistema de gestión de prioridades para Historiales Clínicos Digitales (HCD) implementado con un **Árbol Binario de Búsqueda (BST)** utilizando **Clean Architecture** y principios **SOLID**.

## 📋 Descripción

Este sistema permite gestionar historiales clínicos con diferentes niveles de prioridad, organizándolos automáticamente en un árbol binario de búsqueda. Los IDs se asignan automáticamente según el tipo de consulta, y el sistema garantiza que los historiales más urgentes se procesen primero.

## 🏗️ Arquitectura

El proyecto está organizado siguiendo los principios de **Clean Architecture** con las siguientes capas:

### 📁 Domain (Capa de Dominio)
- **Entities**: Entidades del dominio (`HistorialClinico`, `Nodo`)
- **Enums**: Enumeraciones (`TipoRecorrido`, `TipoConsulta`)
- **Interfaces**: Contratos del dominio (`IArbolBinarioBusqueda`, `IRecorridoStrategy`, `IRecorridoStrategyFactory`)

### 📁 Application (Capa de Aplicación)
- **Use Cases**: Casos de uso de la aplicación
  - `InsertarHistorialUseCase`: Inserta un nuevo historial con ID automático
  - `RecorrerArbolUseCase`: Recorre el árbol según el tipo de recorrido
  - `ObtenerEstructuraArbolUseCase`: Obtiene la estructura visual del árbol
  - `ObtenerEstructuraVisualUseCase`: Obtiene la estructura por niveles
  - `LimpiarArbolUseCase`: Limpia todos los datos del árbol
- **DTOs**: Objetos de transferencia de datos (`HistorialClinicoDto`)

### 📁 Infrastructure (Capa de Infraestructura)
- **ArbolBinarioBusqueda**: Implementación concreta del BST
- **Recorridos**: Estrategias de recorrido del árbol
  - `InOrdenStrategy`: Recorrido In-orden (Izquierda → Raíz → Derecha)
  - `PreOrdenStrategy`: Recorrido Pre-orden (Raíz → Izquierda → Derecha)
  - `PostOrdenStrategy`: Recorrido Post-orden (Izquierda → Derecha → Raíz)
  - `PorNivelStrategy`: Recorrido por niveles (BFS)
  - `RecorridoStrategyFactory`: Factory para crear estrategias

### 📁 Presentation (Capa de Presentación)
- **WindowsForms**: Interfaz de usuario de Windows Forms
  - `MainForm`: Formulario principal con todos los controles
  - `Program`: Punto de entrada de la aplicación

## 🎯 Características

### ✨ Sistema de IDs Automáticos
- Los IDs se asignan automáticamente según el tipo de consulta
- Fórmula: `ID = (Prioridad × 1,000,000) + Contador`
- Cada tipo de consulta tiene su propio rango de IDs:
  - **Reanimación (1)**: IDs 1,000,001, 1,000,002, 1,000,003...
  - **UCI (2)**: IDs 2,000,001, 2,000,002, 2,000,003...
  - **Emergencia (3)**: IDs 3,000,001, 3,000,002, 3,000,003...
  - Y así sucesivamente...

### 🔍 Validación de IDs
- El sistema verifica si un ID ya existe antes de insertar
- Si existe, incrementa el contador hasta encontrar un ID disponible
- Garantiza IDs únicos sin duplicados

### 📊 Tipos de Consulta y Prioridades
1. **Reanimación** (Prioridad 1) - Máxima prioridad
2. **UCI** (Prioridad 2)
3. **Emergencia** (Prioridad 3)
4. **Consulta Urgente** (Prioridad 4)
5. **Radiografía** (Prioridad 5)
6. **Fisioterapia** (Prioridad 6)
7. **Consulta Rutina** (Prioridad 7)
8. **Alta Médica** (Prioridad 8) - Menor prioridad

### 🌳 Tipos de Recorrido
1. **In-orden**: Orden ascendente por ID (para reportes de prioridad)
2. **Pre-orden**: Raíz primero, luego subárboles (para respaldos)
3. **Post-orden**: Hojas primero, luego padres (para eliminación segura)
4. **Por Nivel**: Nivel por nivel (BFS - para ver la jerarquía)

## 🚀 Requisitos

- .NET 8.0 o superior
- Windows (para Windows Forms)
- Visual Studio 2022 o VS Code con extensión de C#

## 📦 Instalación

1. Clona el repositorio:
```bash
git clone https://github.com/Trinidad006/arbolesBinarios.git
cd arbolesBinarios
```

2. Restaura las dependencias:
```bash
dotnet restore
```

3. Compila el proyecto:
```bash
dotnet build
```

4. Ejecuta la aplicación:
```bash
dotnet run
```

## 💻 Uso

### Insertar un Historial Clínico
1. Selecciona el tipo de consulta en el ComboBox
2. Escribe la descripción en el campo de texto
3. Haz clic en "Insertar 💕"
4. El sistema asignará automáticamente un ID único según el tipo de consulta

### Recorrer el Árbol
1. Selecciona el tipo de recorrido en el ComboBox
2. Haz clic en "Ejecutar Recorrido 💖"
3. Los resultados se mostrarán en el área de resultados

### Ver la Estructura del Árbol
- **Ver Estructura (Árbol) 🌸**: Muestra la estructura con líneas y conectores
- **Ver Estructura (Niveles) 🌺**: Muestra la estructura agrupada por niveles

### Limpiar el Árbol
1. Haz clic en "Limpiar 🌺"
2. Confirma la eliminación
3. Todos los datos se eliminarán del árbol

### Cargar Datos de Prueba
1. Haz clic en "Cargar Datos de Prueba 🌸"
2. Se insertarán 5 historiales de prueba con diferentes tipos de consulta

## 🎨 Interfaz de Usuario

La aplicación cuenta con una interfaz de usuario moderna y colorida con tema rosa:
- **Fondo rosa claro** para una experiencia visual agradable
- **Botones coloridos** con emojis para mejor UX
- **Validación en tiempo real** de los campos de entrada
- **Mensajes de confirmación** para todas las operaciones

## 🏛️ Principios Aplicados

- **Separación de Responsabilidades**: Cada capa tiene una responsabilidad específica
- **Inversión de Dependencias**: Las capas superiores dependen de abstracciones (interfaces)
- **Strategy Pattern**: Para los diferentes tipos de recorrido del árbol
- **Factory Pattern**: Para la creación de estrategias de recorrido
- **Single Responsibility**: Cada clase tiene una única razón para cambiar
- **Open/Closed Principle**: Abierto para extensión, cerrado para modificación

## 📚 Estructura del Proyecto

```
arbolesBinarios/
├── Application/
│   ├── UseCases/
│   │   ├── InsertarHistorialUseCase.cs
│   │   ├── RecorrerArbolUseCase.cs
│   │   ├── ObtenerEstructuraArbolUseCase.cs
│   │   ├── ObtenerEstructuraVisualUseCase.cs
│   │   └── LimpiarArbolUseCase.cs
│   └── DTOs/
│       └── HistorialClinicoDto.cs
├── Domain/
│   ├── Entities/
│   │   ├── HistorialClinico.cs
│   │   └── Nodo.cs
│   ├── Enums/
│   │   ├── TipoRecorrido.cs
│   │   └── TipoConsulta.cs
│   └── Interfaces/
│       ├── IArbolBinarioBusqueda.cs
│       ├── IRecorridoStrategy.cs
│       └── IRecorridoStrategyFactory.cs
├── Infrastructure/
│   ├── ArbolBinarioBusqueda/
│   │   └── ArbolBinarioBusqueda.cs
│   └── Recorridos/
│       ├── InOrdenStrategy.cs
│       ├── PreOrdenStrategy.cs
│       ├── PostOrdenStrategy.cs
│       ├── PorNivelStrategy.cs
│       └── RecorridoStrategyFactory.cs
├── Presentation/
│   ├── WindowsForms/
│   │   └── MainForm.cs
│   └── Program.cs
└── SPHC.csproj
```

## 🔄 Flujo de Datos

### Insertar un Historial
```
Usuario → MainForm → InsertarHistorialUseCase → ArbolBinarioBusqueda
```

### Recorrer el Árbol
```
Usuario → MainForm → RecorrerArbolUseCase → Factory → Estrategia → Árbol → Resultados
```

## 🧪 Ejemplo de Uso

### Insertar Historiales
```csharp
// El sistema asigna automáticamente los IDs
InsertarHistorialUseCase.Ejecutar(TipoConsulta.Reanimacion, "Paciente inconsciente");
// ID asignado: 1,000,001

InsertarHistorialUseCase.Ejecutar(TipoConsulta.Emergencia, "Paciente con síntomas graves");
// ID asignado: 3,000,001
```

### Recorrer el Árbol
```csharp
// Recorrido In-orden (orden ascendente por ID)
var historiales = RecorrerArbolUseCase.Ejecutar(TipoRecorrido.InOrden);
// Resultado: [1,000,001] → [3,000,001] → [4,000,001] ...
```

## 📖 Conceptos Implementados

- **Árbol Binario de Búsqueda (BST)**: Estructura de datos para organizar los historiales
- **Recorridos de Árbol**: Diferentes algoritmos para recorrer el árbol
- **Clean Architecture**: Separación de capas y responsabilidades
- **Dependency Injection**: Inyección manual de dependencias
- **Strategy Pattern**: Para diferentes algoritmos de recorrido
- **Factory Pattern**: Para crear estrategias de recorrido

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Por favor:
1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📝 Licencia

Este proyecto es de código abierto y está disponible bajo la licencia MIT.

## 👤 Autor

**Trinidad006**
- GitHub: [@Trinidad006](https://github.com/Trinidad006)

## 🙏 Agradecimientos

- .NET Foundation por el framework
- Comunidad de C# por las mejores prácticas
- Clean Architecture por los principios de diseño

## 📧 Contacto

Para preguntas o sugerencias, por favor abre un issue en el repositorio.

---

⭐ Si te gusta este proyecto, ¡dale una estrella en GitHub!

