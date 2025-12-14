using System;

namespace DemoAimbotTool.Math
{
    public static class Projection
    {
        public static bool WorldToScreen(
            Vector3 w, Vector3 c, Angle a, float fov,
            int sw, int sh, out Vector3 s)
        {
            s = new Vector3();
            CameraMath.AngleVectors(a, out var f, out var r, out var u);
            Vector3 d = w - c;

            float x = d.X * r.X + d.Y * r.Y + d.Z * r.Z;
            float y = d.X * u.X + d.Y * u.Y + d.Z * u.Z;
            float z = d.X * f.X + d.Y * f.Y + d.Z * f.Z;

            if (z <= 0.1f) return false;

            float t = MathF.Tan(fov * 0.0087266f);
            s.X = sw / 2f * (1 + x / (z * t));
            s.Y = sh / 2f * (1 - y / (z * t));
            return true;
        }
    }
}

