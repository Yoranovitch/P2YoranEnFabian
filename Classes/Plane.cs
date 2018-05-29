using OpenTK;

class Plane : Primitive
{
    public Vector3 normal;
    public int origindistance;

    public Plane(Vector3 pos, int distance, Vector3 norm, Vector3 col)
    {
        position = pos;
        origindistance = distance;
        normal = norm;
        color = col;
    }

    public override void DrawDebug(float sceneWidth, float sceneHeight)
    {
        base.DrawDebug(sceneWidth, sceneHeight);
    }
}
