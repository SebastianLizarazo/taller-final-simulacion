using System.Windows.Forms;

namespace taller_final_simulacion.Controles
{
    /// <summary>
    /// Panel con doble búfer (double buffering) habilitado.
    /// WinForms no expone <see cref="System.Windows.Forms.Control.DoubleBuffered"/> de forma pública,
    /// por eso se deriva de <see cref="System.Windows.Forms.Panel"/>: el control se declara y se
    /// instancia en el diseñador (Form1.Designer.cs) igual que cualquier otro control, pero
    /// evita el parpadeo characteristic del repintado con GDI+.
    /// </summary>
    public class PanelDobleBuffer : System.Windows.Forms.Panel
    {
        public PanelDobleBuffer()
        {
            // Doble búfer: el bitmap de fondo se conserva y se copia al cliente, sin parpadeo.
            DoubleBuffered = true;
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);
        }
    }
}
