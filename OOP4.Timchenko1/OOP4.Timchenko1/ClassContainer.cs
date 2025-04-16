using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4.Timchenko1
{
    internal class Shapes_Container
    {
        private List<Shapes> Container = new List<Shapes>();
        public void Add_Shapes(Shapes shape)
        {
            Container.Add(shape);
        }

        public void Remove_Shapes(Shapes shape)
        {
            Container.Remove(shape);
        }

        public List<Shapes> Get_Shapes()
        {
            return Container;
        }

        public void DrawAll(Graphics g)
        {
            foreach (var shape in Container)
            {
                shape.draw(g);
            }
        }

        public Shapes FindShapeAtPoint(int pointX, int pointY)
        {
            foreach (Shapes shape in Container)
            {
                if (shape.ContainsPoint(pointX, pointY))
                {
                    return shape;
                }
            }
            return null;
        }
    }
}
