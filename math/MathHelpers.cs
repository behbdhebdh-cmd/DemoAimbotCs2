namespace DemoAimbotTool.Math
{
    public static class MathHelpers
    {
        public static Angle NormalizeAngles(Angle a)
        {
            while (a.Yaw > 180) a.Yaw -= 360;
            while (a.Yaw < -180) a.Yaw += 360;
            if (a.Pitch > 89) a.Pitch = 89;
            if (a.Pitch < -89) a.Pitch = -89;
            a.Roll = 0;
            return a;
        }
    }
}

