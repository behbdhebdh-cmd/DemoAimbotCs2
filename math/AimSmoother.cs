using System;

namespace DemoAimbotTool.Math
{
    public class AimSmoother
    {
        public float Smoothing = 12f;

        public Angle Update(Angle cur, Vector3 cam, Vector3 tgt, float dt)
        {
            Angle dst = CameraMath.CalcAngle(cam, tgt);
            float t = 1f - MathF.Exp(-Smoothing * dt);

            cur.Pitch += Delta(cur.Pitch, dst.Pitch) * t;
            cur.Yaw += Delta(cur.Yaw, dst.Yaw) * t;

            return MathHelpers.NormalizeAngles(cur);
        }

        private float Delta(float a, float b)
        {
            float d = b - a;
            while (d > 180) d -= 360;
            while (d < -180) d += 360;
            return d;
        }
    }
}

