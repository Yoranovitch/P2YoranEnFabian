using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

class Plane : Primitive
{
    Vector3 normal = new Vector3(0, 0, 0);
    int origindistance;
    public Surface screen;

    public Plane()
    {

    }
}
