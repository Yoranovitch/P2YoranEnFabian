using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace template
{
    public class Plane : Primitive
    {
        public Surface screen;
        Vector3 normal = new Vector3(0, 0, 0);
        int distance;

        public Plane(Vector3 LB, Vector3 LO, Vector3 RO, Vector3 RB)
        {
            screen.Line((int)LB.X, (int)LB.Y, (int)LO.X, (int)LO.Y, 0xffffff);
            screen.Line((int)LO.X, (int)LO.Y, (int)RO.X, (int)RO.Y, 0xffffff);
            screen.Line((int)RO.X, (int)RO.Y, (int)RB.X, (int)RB.Y, 0xffffff);
            screen.Line((int)RB.X, (int)RB.Y, (int)LB.X, (int)LB.Y, 0xffffff);
        }
    }
}
