using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace taller_final_simulacion.Controles
{
    /// <summary>
    /// Estado instantáneo del mecanismo que se dibuja en la animación.
    /// </summary>
    public sealed class EstadoMecanico
    {
        /// <summary>Desplazamiento de m1 (m).</summary>
        public double Y1 { get; set; }

        /// <summary>Desplazamiento de m2 (m).</summary>
        public double Y2 { get; set; }

        /// <summary>Desplazamiento de m3 (m).</summary>
        public double Y3 { get; set; }

        /// <summary>Factor de escala de la animación (píxeles por metro). Sólo afecta a la visualización.</summary>
        public double Escala { get; set; }
    }

    /// <summary>
    /// Dibujo del mecanismo con GDI+ (soportes, masas, resortes y amortiguadores).
    /// Todo el dibujo se realiza sobre el <see cref="System.Drawing.Graphics"/> del control
    /// declarado en el diseñador: no se crea ningún control en tiempo de ejecución.
    /// </summary>
    public static class DibujadorMecanismo
    {
        private static readonly Font FuenteMasa = new("Segoe UI", 10f, FontStyle.Bold);
        private static readonly Font FuenteElemento = new("Segoe UI", 8f, FontStyle.Bold);
        private static readonly Font FuenteSoporte = new("Segoe UI", 7f, FontStyle.Bold);

        // Paleta del mecanismo.
        private static readonly Color ColorSoporte = Color.FromArgb(125, 130, 136);
        private static readonly Color ColorBorde = Color.FromArgb(55, 60, 66);
        private static readonly Color ColorResorte = Color.FromArgb(45, 48, 56);
        private static readonly Color ColorAmortiguador = Color.FromArgb(75, 80, 88);
        private static readonly Color ColorMasa1 = Color.FromArgb(120, 176, 230);
        private static readonly Color ColorMasa2 = Color.FromArgb(140, 200, 175);
        private static readonly Color ColorMasa3 = Color.FromArgb(235, 190, 120);

        /// <summary>
        /// Dibuja el sistema completo en el área indicada.
        /// </summary>
        /// <param name="g">Contexto de dibujo del control del diseñador.</param>
        /// <param name="area">Tamaño del área cliente del control.</param>
        /// <param name="estado">Desplazamientos instantáneos de las tres masas.</param>
        /// <returns>
        /// <c>true</c> si algún desplazamiento tuvo que ser recortado para que el esquema
        /// siguiera siendo legible (factor de escala excesivo).
        /// </returns>
        public static bool Dibujar(Graphics g, Size area, EstadoMecanico estado)
        {
            ArgumentNullException.ThrowIfNull(g);
            ArgumentNullException.ThrowIfNull(estado);

            if (area.Width <= 0 || area.Height <= 0)
            {
                return false;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            float ancho = area.Width;
            float alto = area.Height;

            // ---------------------------------------------------------------------
            // Geometría del esquema (coordenadas de equilibrio en píxeles)
            // ---------------------------------------------------------------------
            const float AltoSoporte = 15f;
            const float MargenLateral = 16f;
            const float AltoMasaSuperior = 40f;
            const float AltoMasaInferior = 44f;

            float ySoporteSuperior = 10f;
            float ySoporteInferior = alto - 10f - AltoSoporte;

            float anchoMasa1 = 88f;
            float anchoMasa2 = 88f;
            float anchoMasa3 = ancho * 0.56f;

            float xMasa1 = ancho * 0.25f;
            float xMasa2 = ancho * 0.75f;
            float xMasa3 = ancho * 0.50f;

            float yMasa1 = alto * 0.22f;
            float yMasa2 = alto * 0.22f;
            float yMasa3 = alto * 0.60f;

            // ---------------------------------------------------------------------
            // Desplazamiento en píxeles, recortado para mantener el esquema legible
            // ---------------------------------------------------------------------
            float escala = (float)estado.Escala;

            float limiteSuperior = yMasa1 - (ySoporteSuperior + AltoSoporte) - 10f;
            float limiteInferiorSuperior = (yMasa3 - (yMasa1 + AltoMasaSuperior)) - 24f;
            float limiteInferiorInferior = (ySoporteInferior - (yMasa3 + AltoMasaInferior)) - 10f;
            float limiteSuperiorInferior = -(yMasa3 - (yMasa1 + AltoMasaSuperior)) - 24f;

            float desplazamiento1 = Limitar((float)(estado.Y1 * escala), -limiteSuperior, limiteInferiorSuperior);
            float desplazamiento2 = Limitar((float)(estado.Y2 * escala), -limiteSuperior, limiteInferiorSuperior);
            float desplazamiento3 = Limitar((float)(estado.Y3 * escala), limiteSuperiorInferior, limiteInferiorInferior);

            bool recortado =
                Math.Abs((float)(estado.Y1 * escala) - desplazamiento1) > 0.5f ||
                Math.Abs((float)(estado.Y2 * escala) - desplazamiento2) > 0.5f ||
                Math.Abs((float)(estado.Y3 * escala) - desplazamiento3) > 0.5f;

            // ---------------------------------------------------------------------
            // Soportes fijos
            // ---------------------------------------------------------------------
            using (SolidBrush pincelSoporte = new(ColorSoporte))
            using (Pen penSoporte = new(ColorBorde, 1f))
            {
                RectangleF soporteSuperior = new(MargenLateral, ySoporteSuperior, ancho - 2 * MargenLateral, AltoSoporte);
                RectangleF soporteInferior = new(MargenLateral, ySoporteInferior, ancho - 2 * MargenLateral, AltoSoporte);

                DibujarSoporte(g, soporteSuperior, pincelSoporte, penSoporte, "SOPORTE FIJO");
                DibujarSoporte(g, soporteInferior, pincelSoporte, penSoporte, "SOPORTE FIJO");
            }

            // ---------------------------------------------------------------------
            // Resortes y amortiguadores (la longitud depende de los desplazamientos)
            // ---------------------------------------------------------------------
            float y1Actual = yMasa1 + desplazamiento1;
            float y2Actual = yMasa2 + desplazamiento2;
            float y3Actual = yMasa3 + desplazamiento3;

            using (Pen penResorte = new(ColorResorte, 2f))
            using (Pen penAmortiguador = new(ColorAmortiguador, 1.6f))
            using (SolidBrush pincelCuerpo = new(ColorAmortiguador))
            using (Pen penFantasma = new(Color.FromArgb(150, 150, 160), 1f) { DashStyle = DashStyle.Dash })
            {
                // Posición de equilibrio (línea discontinua) de cada masa.
                DibujarMasaFantasma(g, penFantasma, new RectangleF(xMasa1 - anchoMasa1 / 2, yMasa1, anchoMasa1, AltoMasaSuperior));
                DibujarMasaFantasma(g, penFantasma, new RectangleF(xMasa2 - anchoMasa2 / 2, yMasa2, anchoMasa2, AltoMasaSuperior));
                DibujarMasaFantasma(g, penFantasma, new RectangleF(xMasa3 - anchoMasa3 / 2, yMasa3, anchoMasa3, AltoMasaInferior));

                float topeSuperior = ySoporteSuperior + AltoSoporte;
                float topeInferior = ySoporteInferior;

                // Soporte superior -> m1 (k1 en paralelo con b1).
                DibujarResorte(g, penResorte, xMasa1 - 26f, topeSuperior, y1Actual, "k1");
                DibujarAmortiguador(g, penAmortiguador, pincelCuerpo, xMasa1 + 26f, topeSuperior, y1Actual, "b1");

                // Soporte superior -> m2 (k4 en paralelo con b2).
                DibujarResorte(g, penResorte, xMasa2 - 26f, topeSuperior, y2Actual, "k4");
                DibujarAmortiguador(g, penAmortiguador, pincelCuerpo, xMasa2 + 26f, topeSuperior, y2Actual, "b2");

                // m1 -> m3 (resorte k2).
                DibujarResorte(g, penResorte, xMasa1, y1Actual + AltoMasaSuperior, y3Actual, "k2");

                // m2 -> m3 (amortiguador b3).
                DibujarAmortiguador(g, penAmortiguador, pincelCuerpo, xMasa2, y2Actual + AltoMasaSuperior, y3Actual, "b3");

                // m3 -> soporte inferior (resorte k3).
                DibujarResorte(g, penResorte, xMasa3, y3Actual + AltoMasaInferior, topeInferior, "k3");
            }

            // ---------------------------------------------------------------------
            // Masas
            // ---------------------------------------------------------------------
            using (SolidBrush pincel1 = new(ColorMasa1))
            using (SolidBrush pincel2 = new(ColorMasa2))
            using (SolidBrush pincel3 = new(ColorMasa3))
            using (Pen penMasa = new(ColorBorde, 1.4f))
            {
                DibujarMasa(g, new RectangleF(xMasa1 - anchoMasa1 / 2, y1Actual, anchoMasa1, AltoMasaSuperior), "m1", pincel1, penMasa);
                DibujarMasa(g, new RectangleF(xMasa2 - anchoMasa2 / 2, y2Actual, anchoMasa2, AltoMasaSuperior), "m2", pincel2, penMasa);
                DibujarMasa(g, new RectangleF(xMasa3 - anchoMasa3 / 2, y3Actual, anchoMasa3, AltoMasaInferior), "m3", pincel3, penMasa);
            }

            return recortado;
        }

        /// <summary>Recorta un desplazamiento a los límites visuales permitidos.</summary>
        private static float Limitar(float valor, float minimo, float maximo)
        {
            if (minimo > maximo)
            {
                minimo = maximo;
            }

            return Math.Min(maximo, Math.Max(minimo, valor));
        }

        /// <summary>Soporte fijo (barra rayada).</summary>
        private static void DibujarSoporte(Graphics g, RectangleF area, Brush pincel, Pen pen, string etiqueta)
        {
            g.FillRectangle(pincel, area);
            g.DrawRectangle(pen, area.X, area.Y, area.Width, area.Height);

            // Rayado diagonal característico de un apoyo fijo.
            using (Pen penRayado = new(Color.FromArgb(90, 95, 100), 1f))
            {
                for (float x = area.X - area.Height; x < area.Right; x += 9f)
                {
                    g.DrawLine(penRayado, x, area.Bottom, x + area.Height, area.Top);
                }
            }

            StringFormat formato = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            using (SolidBrush pincelTexto = new(Color.FromArgb(250, 250, 250)))
            {
                g.DrawString(etiqueta, FuenteSoporte, pincelTexto, area, formato);
            }
        }

        /// <summary>Masa con su etiqueta centrada.</summary>
        private static void DibujarMasa(Graphics g, RectangleF area, string etiqueta, Brush pincel, Pen pen)
        {
            g.FillRectangle(pincel, area);
            g.DrawRectangle(pen, area.X, area.Y, area.Width, area.Height);

            StringFormat formato = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };
            using (SolidBrush pincelTexto = new(Color.FromArgb(25, 30, 35)))
            {
                g.DrawString(etiqueta, FuenteMasa, pincelTexto, area, formato);
            }
        }

        /// <summary>Contorno discontinuo que marca la posición de equilibrio de una masa.</summary>
        private static void DibujarMasaFantasma(Graphics g, Pen pen, RectangleF area)
        {
            g.DrawRectangle(pen, area.X, area.Y, area.Width, area.Height);
        }

        /// <summary>
        /// Resorte en zigzag entre dos puntos verticales.
        /// La longitud del trazo depende de la separación real entre las masas,
        /// que a su vez depende de los desplazamientos instantáneos.
        /// </summary>
        private static void DibujarResorte(Graphics g, Pen pen, float x, float yTop, float yBottom, string etiqueta)
        {
            float largo = yBottom - yTop;

            if (largo < 6f)
            {
                g.DrawLine(pen, x, yTop, x, yBottom);
                DibujarEtiqueta(g, etiqueta, x, (yTop + yBottom) / 2f);
                return;
            }

            int segmentos = Math.Max(4, (int)(largo / 9f));
            if (segmentos % 2 != 0)
            {
                segmentos++;
            }

            float amplitud = 7f;
            PointF[] puntos = new PointF[segmentos + 1];

            for (int i = 0; i <= segmentos; i++)
            {
                float t = (float)i / segmentos;
                float y = yTop + t * largo;
                float dx = i % 2 == 0 ? -amplitud / 2f : amplitud / 2f;
                puntos[i] = new PointF(x + dx, y);
            }

            g.DrawLines(pen, puntos);
            DibujarEtiqueta(g, etiqueta, x, (yTop + yBottom) / 2f);
        }

        /// <summary>
        /// Amortiguador (cilindro + vástago + pistón) entre dos puntos verticales.
        /// </summary>
        private static void DibujarAmortiguador(Graphics g, Pen pen, Brush pincel, float x, float yTop, float yBottom, string etiqueta)
        {
            float largo = yBottom - yTop;

            if (largo < 10f)
            {
                g.DrawLine(pen, x, yTop, x, yBottom);
                DibujarEtiqueta(g, etiqueta, x, (yTop + yBottom) / 2f);
                return;
            }

            float alturaCuerpo = Math.Min(28f, Math.Max(12f, largo * 0.42f));
            float yCuerpoTop = yBottom - alturaCuerpo;

            // Vástago desde el anclaje superior hasta el cuerpo.
            g.DrawLine(pen, x, yTop, x, yCuerpoTop);

            // Cuerpo cilíndrico del amortiguador.
            RectangleF cuerpo = new(x - 6.5f, yCuerpoTop, 13f, alturaCuerpo);
            g.FillRectangle(pincel, cuerpo);
            g.DrawRectangle(pen, cuerpo.X, cuerpo.Y, cuerpo.Width, cuerpo.Height);

            // Pistón dentro del cuerpo.
            float yPiston = yCuerpoTop + alturaCuerpo * 0.38f;
            g.DrawLine(pen, x - 6.5f, yPiston, x + 6.5f, yPiston);

            DibujarEtiqueta(g, etiqueta, x, (yTop + yBottom) / 2f);
        }

        /// <summary>Etiqueta del elemento (k1, b3, ...).</summary>
        private static void DibujarEtiqueta(Graphics g, string etiqueta, float x, float y)
        {
            using (SolidBrush pincel = new(Color.FromArgb(70, 75, 85)))
            {
                g.DrawString(etiqueta, FuenteElemento, pincel, x + 9f, y - 7f);
            }
        }
    }
}
