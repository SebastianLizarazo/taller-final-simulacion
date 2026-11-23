# Simulación de un sistema mecánico de 3 grados de libertad

Aplicación de escritorio (Windows Forms, C# / .NET 8) que simula un sistema mecánico de **3 masas, 4 resortes y 3 amortiguadores** excitado por una **fuerza pulsada** sobre la masa `m3`, e integra las ecuaciones de movimiento con **Runge-Kutta de 4.º orden (RK4)**.

Incluye la gráfica de la respuesta con marcador de avance, la animación del mecanismo en GDI+, el análisis de máximos por masa y la tabla de muestras.

| | |
|---|---|
| **Framework** | .NET 8 (`net8.0-windows`), Windows Forms |
| **Gráficas** | ScottPlot 5.0.56 (`ScottPlot.WinForms`) |
| **Integración** | RK4 con subpasos y división por evento |
| **Animación** | GDI+ sobre `Graphics` del control del diseñador |
| **Repositorio** | <https://github.com/SebastianLizarazo/taller-final-simulacion> |

---

## Inicio rápido

**Requisitos:** Windows 10/11 y el [SDK de .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.

```bash
git clone https://github.com/SebastianLizarazo/taller-final-simulacion.git
cd taller-final-simulacion
dotnet restore
dotnet build
dotnet run --project taller-final-simulacion
```

1. La app abre con los valores por defecto, que producen una oscilación amortiguada visible.
2. `Simular` valida los parámetros, integra el sistema y llena la gráfica, el análisis y la tabla.
3. `Reproducir` anima el mecanismo; `Pausa` detiene; `Reiniciar` vuelve al instante inicial.

El paquete NuGet `ScottPlot.WinForms` se restaura automáticamente: no hay que instalarlo a mano.

---

## Qué simula

### Topología del mecanismo

```
        SOPORTE FIJO (superior)
   ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
         │k1           │k4
         k1            k4
         b1            b2
         │             │
     ┌───────┐     ┌───────┐
     │  m1   │     │  m2   │
     └───────┘     └───────┘
         │k2            b3
         │              │
    ┌────────────────────────┐
    │          m3             │  ◄── F(t) aplicada aquí
    └────────────────────────┘
         │k3
         k3
   ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
        SOPORTE FIJO (inferior)
```

| Elemento | Une | Tipo |
|---|---|---|
| `k1` | soporte superior ↔ `m1` | resorte |
| `b1` | soporte superior ↔ `m1` | amortiguador (en paralelo con `k1`) |
| `k4` | soporte superior ↔ `m2` | resorte |
| `b2` | soporte superior ↔ `m2` | amortiguador (en paralelo con `k4`) |
| `k2` | `m1` ↔ `m3` | resorte |
| `b3` | `m2` ↔ `m3` | amortiguador |
| `k3` | `m3` ↔ soporte inferior | resorte |

### Ecuaciones de movimiento

Desplazamientos medidos desde el equilibrio estático, positivos hacia abajo:

```
m1·ÿ1 = −k1·y1 − b1·ẏ1 − k2·(y1 − y3)
m2·ÿ2 = −k4·y2 − b2·ẏ2 − b3·(ẏ2 − ẏ3)
m3·ÿ3 = F(t) − k2·(y3 − y1) − b3·(ẏ3 − ẏ2) − k3·y3
```

Vector de estado: `x = [y1, y2, y3, v1, v2, v3]`, con `v = ẏ`.
Condiciones iniciales: `y(0) = 0`, `ẏ(0) = 0`.

### Fuerza de excitación

Pulso rectangular sobre `m3`:

```
        ⎧ A     si  0 ≤ t ≤ Tf
F(t) =  ⎨
        ⎩ 0     en otro caso
```

`A` es la amplitud (N) y `Tf` la duración (s). Si `Tf > T` el pulso queda truncado y la app lo avisa.

---

## Integración numérica

| Aspecto | Comportamiento |
|---|---|
| Paso entre muestras | `Δt = T / (N − 1)` |
| Subpasos internos | El paso se divide para que el paso interno nunca supere **1 ms** (`subpasos = ⌈Δt / 1 ms⌉`), lo que mantiene la estabilidad con sistemas rígidos |
| División por evento | Si un paso cruza la discontinuidad en `t = Tf`, se parte en dos: el primer tramo con la fuerza activa y el segundo sin ella |
| Divergencia | Se aborta con `SimulationException` si aparece un valor no finito o si `|y| > 10⁶ m` |

**Por qué la división por evento.** Un RK4 clásico no puede integrar un paso que cruza una discontinuidad: el error local cae a orden `h` en lugar de orden `h⁴`, y el resultado deja de ser exacto. Partiendo el paso en `t = Tf` se conserva el orden esperado del método.

---

## Parámetros de entrada

Todos los campos aceptan notación decimal con punto o coma (`12.5` y `12,5` son equivalentes) y deben ser números finitos.

| Control | Símbolo | Unidad | Por defecto | Rango válido |
|---|---|---|---|---|
| `txtM1` | `m1` | kg | `1` | `> 0` |
| `txtM2` | `m2` | kg | `1` | `> 0` |
| `txtM3` | `m3` | kg | `1,5` | `> 0` |
| `txtK1` | `k1` | N/m | `120` | `≥ 0` |
| `txtK2` | `k2` | N/m | `80` | `≥ 0` |
| `txtK3` | `k3` | N/m | `100` | `≥ 0` |
| `txtK4` | `k4` | N/m | `90` | `≥ 0` |
| `txtB1` | `b1` | N·s/m | `2` | `≥ 0` |
| `txtB2` | `b2` | N·s/m | `1,5` | `≥ 0` |
| `txtB3` | `b3` | N·s/m | `1` | `≥ 0` |
| `txtAmplitud` | `A` | N | `10` | `≥ 0` |
| `txtDuracion` | `Tf` | s | `1` | `≥ 0` |
| `txtTiempo` | `T` | s | `10` | `> 0` |
| `txtMuestras` | `N` | — | `1000` | `2 ≤ N ≤ 200 000` |
| `txtEscala` | `Escala` | px/m | `100` | `> 0` |

`Restablecer` restaura este conjunto de valores.

### Errores y avisos

Los **errores** bloquean la simulación y se señalan campo a campo con `ErrorProvider`, además de un `MessageBox` resumen.

Los **avisos** no bloquean: la simulación se ejecuta y el motivo aparece debajo, junto a la barra de progreso.

| Aviso | Cuándo |
|---|---|
| `A = 0` | el sistema no está excitado y sólo oscila con las condiciones iniciales nulas |
| `Tf > T` | el pulso de fuerza quedará truncado |
| `k1+k2+k3+k4 = 0` | el sistema no tiene rigidez y no generará respuesta |
| `b1+b2+b3 = 0` | la respuesta no se disipará y puede crecer de forma sostenida |

---

## Interfaz

| Zona | Contenido |
|---|---|
| **Panel lateral** | Parámetros de entrada, botonera (`Simular`, `Reproducir`, `Reiniciar`, `Restablecer`), barra de progreso y avisos |
| **Gráfica** | Tres curvas (`y1`, `y2`, `y3`) con leyenda, título y ejes con unidades; una línea vertical y tres marcadores que indican el instante actual de la animación |
| **Animación** | Mecanismo dibujado con GDI+: soportes, masas, resortes y amortiguadores con longitud variable, y contorno discontinuo en la posición de equilibrio de cada masa |
| **Tabla de muestras** | Modo virtual con las columnas `i`, `t (s)`, `F(t) (N)`, `y1 (m)`, `y2 (m)`, `y3 (m)` |
| **Tabla de análisis** | Por masa: `Máximo (m)`, `t (s)`, `Mínimo (m)`, `t (s)`, `Máx. absoluto (m)`, `t (s)` |

### Interacción

- `Simular` valida, integra en segundo plano y actualiza gráfica, análisis y tabla.
- `Reproducir` / `Pausa` controlan la animación; `Reiniciar` vuelve al instante inicial.
- **Hacer clic en una fila de la tabla de muestras salta la animación a ese instante.**
- Durante la reproducción la tabla **no** se repinta: el repintado de un `DataGridView` dentro de un `TableLayoutPanel` cuesta del orden de 80 ms y bloquea la interfaz. El índice de la animación se deriva del tiempo real transcurrido, no del número de eventos, para que no se acumule rezago.

---

## Estructura del proyecto

```
taller-final-simulacion.slnx                  Solución
taller-final-simulacion/
  taller-final-simulacion.csproj              net8.0-windows, WinForms, ScottPlot.WinForms 5.0.56
  Program.cs                                  Punto de entrada ([STAThread], HighDpiMode.SystemAware)
  Form1.cs                                    Solo lógica: validación, orquestación, gráfica, tablas, animación
  Form1.Designer.cs                           Declaración de TODOS los controles, Timer, ErrorProvider y columnas
  Form1.resx                                  Recursos
  Controles/
    PanelDobleBuffer.cs                       Panel con doble búfer (WinForms no lo expone públicamente)
    DibujadorMecanismo.cs                     Dibujo GDI+ del mecanismo
  Modelos/
    SystemParameters.cs                       Parámetros, valores por defecto, Validate() y ValidateWarnings()
    SimulationResult.cs                       Series de la simulación y MassAnalysis (máx., mín., máx. absoluto)
  Simulacion/
    Simulator.cs                              Integrador RK4 con subpasos y división por evento
```

---

## Decisiones de diseño

**Ningún control se crea en tiempo de ejecución.** Todos los controles, el `Timer`, el `ErrorProvider`, la `ProgressBar` y las columnas de los `DataGridView` están declarados en `Form1.Designer.cs`. `Form1.cs` sólo contiene lógica. La animación se dibuja sobre el `Graphics` del control `panelAnimacion` en su evento `Paint`.

**ScottPlot 5.0.56 y no 5.1.x.** La rama 5.1.x arrastra `SkiaSharp.Views.WindowsForms` 3.119.0, cuyo TFM mínimo es `net8.0-windows10.0.19041`, incompatible con `net8.0-windows`. La rama 5.0.x (SkiaSharp 2.88.9 → `net6.0-windows7.0`) compila limpia. Persiste un aviso `NU1701` residual (OpenTK 3.1.0, sólo assets de .NET Framework 2.0, usado por el control OpenGL opcional de SkiaSharp que la app no utiliza): está silenciado y documentado en el `.csproj`.

**La simulación no bloquea la interfaz.** `Simulator.Run` se ejecuta en `Task.Run` y reporta el avance con `IProgress<int>` hacia la barra de progreso.

**División por evento en la discontinuidad.** Ver [Integración numérica](#integración-numérica).

---

## Alcance implementado

- [x] Modelo de 3 GDL con 4 resortes y 3 amortiguadores, excitado por fuerza pulsada sobre `m3`.
- [x] Integración numérica RK4 con subpasos y división por evento en `t = Tf`.
- [x] Entrada de los 15 parámetros desde la interfaz, con validación de errores y avisos.
- [x] Gráfica de `y1`, `y2`, `y3` con marcador de avance sincronizado con la animación.
- [x] Animación del mecanismo en GDI+, con longitudes de resorte y amortiguador variables.
- [x] Análisis de máximos (máximo, mínimo, máximo absoluto e instante) por masa y tabla de muestras.

---

## Limitaciones conocidas

- La detección de divergencia se evalúa en los límites de muestra, no dentro de los subpasos internos.
- El número de muestras se trunca a entero: un valor fraccionario se redondea en lugar de rechazarse.
- La tabla de muestras no sigue al tiempo durante la reproducción; hay que hacer clic en la fila para navegar a un instante.
- El repositorio no incluye un proyecto de tests automatizados: la verificación se hizo con bancos de prueba descartables durante el desarrollo.
