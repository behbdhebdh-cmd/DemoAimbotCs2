using System.Windows.Forms;

namespace DemoAimbotTool.Rendering.DirectX
{
    public class DxOverlay : Form
    {
        public DxRenderer Renderer { get; }

        public DxOverlay()
        {
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            ShowInTaskbar = false;
            BackColor = System.Drawing.Color.Black;
            TransparencyKey = System.Drawing.Color.Black;
            Bounds = Screen.PrimaryScreen.Bounds;
            Renderer = new DxRenderer(this);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80000 | 0x20;
                return cp;
            }
        }
    }
}

