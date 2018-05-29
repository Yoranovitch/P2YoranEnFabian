using OpenTK;

class Primitive
{
    public Vector3 color;
    public Vector3 position;

    public virtual Intersection Intersects(Vector3 rayOrigin, Vector3 rayDirection)
    {
        return null;
    }

    public virtual void DrawDebug(float sceneWidth, float sceneHeight)
    {
    }
}
