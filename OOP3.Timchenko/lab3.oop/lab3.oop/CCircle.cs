using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.oop
{

        internal class CCircle
        {
            private
                int x, y;
            const int r = 50;
            bool isSelected = false;

            public CCircle()
            {
                x = 0;
                y = 0;
            }

            public CCircle(int x, int y)
            {
                this.x = x;
                this.y = y;
            } 

            public void setIsSelected(bool isSelected)
            {
                this.isSelected = isSelected;
            }

            public bool getIsSelected()
            {
                return isSelected;
            }
            public bool ContainsPoint(int pointX, int pointY)
            {
                double distance = Math.Sqrt(Math.Pow(pointX - x, 2) + Math.Pow(pointY - y, 2));
                return distance <= r;
            }

            public void Draw(Graphics g)
            {
                Pen pen;

                if (isSelected)
                {
                    pen = new Pen(Color.Blue, 3);
                }
                else
                {
                    pen = new Pen(Color.Black, 3);
                }

                g.DrawEllipse(pen, x - r, y - r, r * 2, r * 2);
                pen.Dispose();
            }

            public int getX()
            {
                return x;
            }

            public int getY()
            {
                return y;
            }

            public int getR()
            {
                return r;
            }

            ~CCircle() { }
        }

        internal class CCircle_Container
        {

            private List<CCircle> circle_container = new List<CCircle>();

            public void Add_Circle(CCircle circle)
            {
                circle_container.Add(circle);
            }

            public void Remove_Circle(CCircle circle)
            {
                circle_container.Remove(circle);
            }

            public List<CCircle> Get_CCircles()
            {
                return circle_container;
            }
            public void DrawAll(Graphics g)
            {
                foreach (var circle in circle_container)
                {
                    circle.Draw(g);
                }
            }
            public CCircle FindCircleAtPoint(int pointX, int pointY)
            {
                foreach (var circle in circle_container)
                {
                    if (circle.ContainsPoint(pointX, pointY))
                    {
                        return circle;
                    }
                }
                return null;
            }
        }
    

}
