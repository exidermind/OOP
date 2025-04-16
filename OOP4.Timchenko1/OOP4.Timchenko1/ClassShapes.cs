using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OOP4.Timchenko1
{
    internal abstract class Shapes
    {
        protected
            bool isSelected = false;
        Color color;
        int x, y;
        int size;

        protected Shapes() { }

        public virtual void DoSpecific(Graphics g, Pen pen) { }

        public void draw(Graphics g)
        {
            Pen pen;

            if (isSelected)
            {
                pen = new Pen(Color.Blue, 3);
            }
            else
            {
                pen = new Pen(color, 3);
            }

            DoSpecific(g, pen);

            pen.Dispose();

        }

        public void move(int w, int h, int dx, int dy)
        {
            if (isAvailableLocation(w, h, dx, dy))
            {
                this.x += dx;
                this.y += dy;
            }
        }

        public abstract bool isAvailableLocation(int w, int h, int dX, int dY);

        public abstract bool ContainsPoint(int pointX, int pointY);

        public void setIsSelected(bool isSelected)
        {
            this.isSelected = isSelected;
        }

        public bool getIsSelected()
        {
            return isSelected;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public Color getColor()
        {
            return color;
        }

        public int getSize()
        {
            return size;
        }

        public void setSize(int size)
        {
            this.size = size;
        }

        public void ChangeSize(int newSize, int w, int h)
        {
            if (newSize > 0)
            {
                int newWidth = getX() + newSize * 2;
                int newHeight = getY() + newSize * 2;

                if (isAvailableLocation(w, h, 0, 0) &&
                    getX() - newSize >= 0 &&
                    getY() - newSize >= 0 &&
                    newWidth <= w &&
                    newHeight <= h)
                {
                    setSize(newSize);
                }
            }
            else
            {
                if (getSize() + newSize > 0)
                {
                    setSize(newSize);
                }
            }
        }



        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }

    }

    internal class Square : Shapes
    {
        //private
        //const int SideLength = 160;

        public Square()
        {
            this.setX(0);
            this.setY(0);
            this.setSize(0);
        }
        public Square(int x, int y, Color color, int size)
        {
            this.setX(x);
            this.setY(y);
            this.setColor(color);
            this.setSize(size);
        }

        public override bool isAvailableLocation(int w, int h, int dX, int dY)
        {
            if (getY() + getSize() / 2 + dY >= getSize() &&
                getX() + getSize() / 2 + dX >= getSize() &&
                getY() + getSize() / 2 + dY <= h &&
                getX() + getSize() / 2 + dX <= w)
            {
                return true;
            }
            return false;
        }
        public override void DoSpecific(Graphics g, Pen pen)
        {
            int topLeftX = getX() - getSize() / 2;
            int topLeftY = getY() - getSize() / 2;

            g.DrawRectangle(pen, topLeftX, topLeftY, getSize(), getSize());
            pen.Dispose();
        }


        public override bool ContainsPoint(int pointX, int pointY)
        {
            int left = getX() - getSize() / 2;
            int right = getX() + getSize() / 2;
            int top = getY() - getSize() / 2;
            int bottom = getY() + getSize() / 2;

            return pointX >= left && pointX <= right && pointY >= top && pointY <= bottom;
        }
    };

    internal class Circle : Shapes
    {
        //private
        //const int r = 100;

        public Circle()
        {
            this.setX(0);
            this.setY(0);
            setSize(0);
        }
        public Circle(int x, int y, Color color, int size)
        {
            this.setX(x);
            this.setY(y);
            this.setColor(color);
            setSize(size);
        }

        public override bool isAvailableLocation(int w, int h, int dX, int dY)
        {
            if (getY() + dY >= getSize() &&
            getX() + dX >= getSize() &&
            getY() + getSize() + dY <= h &&
            getX() + getSize() + dX <= w)
            {
                return true;
            }
            return false;
        }

        public override void DoSpecific(Graphics g, Pen pen)
        {
            g.DrawEllipse(pen, getX() - getSize(), getY() - getSize(), getSize() * 2, getSize() * 2);

        }

        public override bool ContainsPoint(int pointX, int pointY)
        {
            double distance = Math.Sqrt(Math.Pow(pointX - getX(), 2) + Math.Pow(pointY - getY(), 2));
            return distance <= getSize();
        }
    };

    internal class Rectangle : Shapes
    {
        private
         int Width;

        public Rectangle()
        {
            this.setX(0);
            this.setY(0);
            setSize(0);
            this.Width = 0;

        }
        public Rectangle(int x, int y, Color color, int size)
        {
            this.setX(x);
            this.setY(y);
            this.setColor(color);
            this.Width = size;
            setSize(size / 2);

        }

        public override bool isAvailableLocation(int w, int h, int dX, int dY)
        {
            if (getY() + dY >= 0 &&
            getX() + dX >= 0 &&
            getY() + getSize() + dY <= h &&
            getX() + Width + dX <= w)
            {
                return true;
            }
            return false;
        }

        public override void DoSpecific(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, getX(), getY(), Width, getSize());
        }


        public override bool ContainsPoint(int pointX, int pointY)
        {
            return pointX >= getX() && pointX <= getX() + Width &&
                   pointY >= getY() && pointY <= getY() + getSize();
        }
    }
}
