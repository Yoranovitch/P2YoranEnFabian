using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;

namespace template
{
    public class Camera : Raytracer
    {
        public Surface screen;
        public Plane plane;
        Vector3 pos, dir, LB, LO, RO, RB;

        public void Main()
        {
            pos = new Vector3(screen.width / 2, screen.height / 2, 0);
            dir = new Vector3(0, 0, 1);
            plane = new Plane(LB, LO, RO, RB);
        }

        public void Update()
        {
            LB = new Vector3(pos.X - 100, pos.Y - 100, 100);
            LO = new Vector3(pos.X - 100, pos.Y + 100, 100);
            RO = new Vector3(screen.width - 100, screen.height - 100, 100);
            RB = new Vector3(screen.width - 100, 100, 100);
        }
    }
}
