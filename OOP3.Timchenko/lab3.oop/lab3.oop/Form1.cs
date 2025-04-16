
namespace lab3.oop
{
    public partial class Form1 : Form
    {
        CCircle_Container circle_container = new CCircle_Container();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PaintBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void PaintBox_MouseClick(object sender, MouseEventArgs e)
        {
            bool isCtrlPressed = (ModifierKeys & Keys.Control) == Keys.Control;

            foreach (CCircle existing_circle in circle_container.Get_CCircles()) 
            {
                if (!isCtrlPressed)
                    existing_circle.setIsSelected(false);
            }

            CCircle clickedCircle = circle_container.FindCircleAtPoint(e.X, e.Y);

            if (clickedCircle != null)
            {
                foreach (var circle in circle_container.Get_CCircles())
                {
                    if (circle.ContainsPoint(e.X, e.Y))
                    {
                        circle.setIsSelected(true);
                        //break;
                    }
                }

            }
            else
            {
                // если круг не найден, создаем новый
                CCircle newCircle = new CCircle(e.X, e.Y);
                circle_container.Add_Circle(newCircle);
            }
            PaintBox.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                //временный список для удаления
                var circlesToRemove = new List<CCircle>();

                foreach (CCircle circle in circle_container.Get_CCircles())
                {
                    if (circle.getIsSelected())
                    {
                        circlesToRemove.Add(circle);
                    }

                }

                foreach (var circle in circlesToRemove)
                {
                    circle_container.Remove_Circle(circle);
                }

                PaintBox.Invalidate();
            }

        }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            circle_container.DrawAll(e.Graphics);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void PaintBox_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
