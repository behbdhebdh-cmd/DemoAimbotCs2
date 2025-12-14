using System;
using System.Drawing;
using System.Windows.Forms;
using DemoAimbotTool.Math;
using DemoAimbotTool.Rendering;
using DemoAimbotTool.Rendering.DirectX;

namespace DemoAimbotTool
{
    public partial class MainForm : Form
    {
        private DxOverlay _overlay;
        private AimSmoother _aim = new AimSmoother();

        // Fake demo camera state (replace with real demo data)
        private Vector3 _cameraPos = new Vector3(0, 0, 64);
        private Angle _cameraAngles = new Angle(0, 0);
        private Vector3 _targetPoint = new Vector3(200, 100, 72);

        private Timer _timer;

        public MainForm()
        {
            InitializeComponent();
            SetupOverlay();
            SetupLoop();
        }

        private void SetupOverlay()
        {
            _overlay = new DxOverlay();
            _overlay.Show();

            DebugDraw.DrawCircle = (x, y, r, c) =>
                _overlay.Renderer.Primitives.DrawDot(x, y, r, ToDx(c));

            DebugDraw.DrawLine = (x1, y1, x2, y2, c) =>
                _overlay.Renderer.Primitives.DrawLine(x1, y1, x2, y2, ToDx(c));
        }

        private void SetupLoop()
        {
            _timer = new Timer();
            _timer.Interval = 16; // ~60 fps
            _timer.Tick += Update;
            _timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            float dt = 0.016f;

            bool smoothKey = (Control.MouseButtons & MouseButtons.Right) != 0;

            if (smoothKey)
            {
                _cameraAngles = _aim.Update(
                    _cameraAngles,
                    _cameraPos,
                    _targetPoint,
                    dt
                );
            }

            _overlay.Renderer.Begin();

            DebugDraw.DrawWorldPoint(
                _targetPoint,
                _cameraPos,
                _cameraAngles,
                90f,
                _overlay.Width,
                _overlay.Height,
                5f,
                Color.Red
            );

            DebugDraw.DrawWorldLine(
                _cameraPos,
                _targetPoint,
                _cameraPos,
                _cameraAngles,
                90f,
                _overlay.Width,
                _overlay.Height,
                Color.Yellow
            );

            _overlay.Renderer.End();
        }

        private SharpDX.Color ToDx(Color c)
            => new SharpDX.Color(c.R, c.G, c.B, c.A);
    }
}

