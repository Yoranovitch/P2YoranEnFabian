using OpenTK;

class Plane : Primitive
{
    public int origindistance;
    public float startdistance;

    public Plane(Vector3 pos, int distance, Vector3 norm, Vector3 col)
    {
        position = pos;
        origindistance = distance;
        normal = norm;
        color = col;
        startdistance = 4.0f;
    }

    public override void DrawDebug(float sceneWidth, float sceneHeight)
    {
        base.DrawDebug(sceneWidth, sceneHeight);
    }
}
