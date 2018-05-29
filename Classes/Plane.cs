using OpenTK;

class Plane : Primitive
{
    public int origindistance;

    public Plane(Vector3 pos, int distance, Vector3 norm, Vector3 col)
    {
        position = pos;
        origindistance = distance;
        normal = norm;
        color = col;
        v = new Vector3(1, 0, 0);
        u = new Vector3(0, 0, 1);
    }

    public override void DrawDebug(float sceneWidth, float sceneHeight)
    {
        base.DrawDebug(sceneWidth, sceneHeight);
    }
}
