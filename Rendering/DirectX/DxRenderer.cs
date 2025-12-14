using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX;
using Device = SharpDX.Direct3D11.Device;

namespace DemoAimbotTool.Rendering.DirectX
{
    public class DxRenderer
    {
        public Primitives Primitives { get; }
        private SwapChain _swap;
        private RenderTargetView _rtv;

        public DxRenderer(System.Windows.Forms.Form f)
        {
            Device.CreateWithSwapChain(
                SharpDX.Direct3D.DriverType.Hardware,
                DeviceCreationFlags.BgraSupport,
                new SwapChainDescription
                {
                    BufferCount = 1,
                    ModeDescription = new ModeDescription(
                        f.Width, f.Height,
                        new Rational(60, 1),
                        Format.R8G8B8A8_UNorm),
                    Usage = Usage.RenderTargetOutput,
                    OutputHandle = f.Handle,
                    SampleDescription = new SampleDescription(1, 0),
                    IsWindowed = true
                },
                out var device,
                out _swap);

            using var bb = _swap.GetBackBuffer<Texture2D>(0);
            _rtv = new RenderTargetView(device, bb);
            Primitives = new Primitives(device);
        }

        public void Begin()
        {
            var ctx = Primitives.Device.ImmediateContext;
            ctx.OutputMerger.SetTargets(_rtv);
            ctx.ClearRenderTargetView(_rtv, new Color4(0, 0, 0, 0));
        }

        public void End() => _swap.Present(1, PresentFlags.None);
    }
}

