using System;

namespace DemoAimbotTool.Math
{
    public static class CameraMath
    {
        public static Angle CalcAngle(Vector3 src, Vector3 dst)
        {
            Vector3 d = dst - src;
            float hyp = MathF.Sqrt(d.X * d.X + d.Y * d.Y);
            float pitch = MathF.Atan2(-d.Z, hyp) * 57.29578f;
            float yaw = MathF.Atan2(d.Y, d.X) * 57.29578f;
            return MathHelpers.NormalizeAngles(new Angle(pitch, yaw));
        }

        public static void AngleVectors(
            Angle a, out Vector3 f, out Vector3 r, out Vector3 u)
        {
            float sp = MathF.Sin(a.Pitch * 0.0174533f);
            float cp = MathF.Cos(a.Pitch * 0.0174533f);
            float sy = MathF.Sin(a.Yaw * 0.0174533f);
            float cy = MathF.Cos(a.Yaw * 0.0174533f);

            f = new Vector3(cp * cy, cp * sy, -sp);
            r = new Vector3(-sy, cy, 0);
            u = new Vector3(sp * cy, sp * sy, cp);
        }
    }
}

