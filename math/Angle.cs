namespace DemoAimbotTool.Math
{
    public struct Angle
    {
        public float Pitch, Yaw, Roll;
        public Angle(float p, float y, float r = 0)
        {
            Pitch = p; Yaw = y; Roll = r;
        }
    }
}

