using OpenTK;

class Primitive
{
    public Vector3 color;
    public Vector3 position;
    public Vector3 normal;
    public Vector3 v, u;

    public virtual void DrawDebug(float sceneWidth, float sceneHeight)
    {
    }
}
