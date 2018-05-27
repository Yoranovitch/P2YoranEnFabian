using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
