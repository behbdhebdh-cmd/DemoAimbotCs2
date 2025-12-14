using SharpDX;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;

namespace DemoAimbotTool.Rendering.DirectX
{
    public class Primitives
    {
        public Device Device { get; }

        public Primitives(Device d) => Device = d;

        public void DrawLine(float x1, float y1, float x2, float y2, Color c)
        {
            var verts = new[] { new Vector4(x1, y1, 0, 1), new Vector4(x2, y2, 0, 1) };
            using var vb = Buffer.Create(Device, BindFlags.VertexBuffer, verts);
            var ctx = Device.ImmediateContext;
            ctx.InputAssembler.PrimitiveTopology = PrimitiveTopology.LineList;
            ctx.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vb, 16, 0));
            ctx.Draw(2, 0);
        }

        public void DrawDot(float x, float y, float s, Color c)
        {
            DrawLine(x - s, y, x + s, y, c);
            DrawLine(x, y - s, x, y + s, c);
        }
    }
}

