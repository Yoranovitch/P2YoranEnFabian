using OpenTK;

class Light
{
    public Vector3 position;
    public float lightintensity;

    public Light(Vector3 pos, float intensity)
    {
        position = pos;
        lightintensity = intensity;
    }
}