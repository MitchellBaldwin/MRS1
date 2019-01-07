using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Test
{
    public partial class TestGfx : Form
    {
        private PictureBox NorthUpPictureBox;
        private PictureBox HeadingUpPictureBox;

        private Image MapImage = null;
        private Bitmap MapBitmap = null;

        private float trueHeading = 0.0f;

        //private PointF PresentPosition = new PointF(714.0F, 699.0F);
        private PointF PresentPosition = new PointF(640.0F, 640.0F);

        public TestGfx()
        {
            InitializeComponent();

            NorthUpPictureBox = new PictureBox() { Top = 20, Left = 10, Width = 280, Height = 280, BorderStyle = BorderStyle.FixedSingle };
            HeadingUpPictureBox = new PictureBox() { Top = 20, Left = NorthUpPictureBox.Right + 10, Width = 280, Height = 280, BorderStyle = BorderStyle.FixedSingle };

            NorthUpPictureBox.Paint += new PaintEventHandler(NorthUpPictureBox_Paint);
            HeadingUpPictureBox.Paint += new PaintEventHandler(HeadingUpPictureBox_Paint);

            this.Controls.Add(NorthUpPictureBox);
            this.Controls.Add(HeadingUpPictureBox);

            this.Controls.Add(new Label() { Text = "Left = translation only, Right = translation and rotation", Width = Width / 2 });

            this.ClientSize = new Size(HeadingUpPictureBox.Right + 10, HeadingUpPictureBox.Bottom + 10);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MapImage != null)
                MapImage.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            const float MoveSpeed = 6.0f;

            switch (e.KeyCode)
            {
                case Keys.Q:
                    trueHeading -= 1.0f;
                    break;
                case Keys.E:
                    trueHeading += 1.0f;
                    break;
                case Keys.Up:
                    PresentPosition = new PointF(PresentPosition.X - (float)Math.Sin(trueHeading / 180 * Math.PI) * MoveSpeed, PresentPosition.Y - (float)Math.Cos(trueHeading / 180 * Math.PI) * MoveSpeed);
                    break;
                case Keys.Down:
                    PresentPosition = new PointF(PresentPosition.X + (float)Math.Sin(trueHeading / 180 * Math.PI) * MoveSpeed, PresentPosition.Y + (float)Math.Cos(trueHeading / 180 * Math.PI) * MoveSpeed);
                    break;
                case Keys.Left:
                    PresentPosition = new PointF(PresentPosition.X - (float)Math.Cos(trueHeading / 180 * Math.PI) * MoveSpeed, PresentPosition.Y + (float)Math.Sin(trueHeading / 180 * Math.PI) * MoveSpeed);
                    break;
                case Keys.Right:
                    PresentPosition = new PointF(PresentPosition.X + (float)Math.Cos(trueHeading / 180 * Math.PI) * MoveSpeed, PresentPosition.Y - (float)Math.Sin(trueHeading / 180 * Math.PI) * MoveSpeed);
                    break;
            }

            NorthUpPictureBox.Invalidate();
            HeadingUpPictureBox.Invalidate();
        }

        // Display the map in a "North up" orientation with a carrat at the center indication the heading
        private void NorthUpPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (MapImage != null)
            {
                e.Graphics.ResetTransform();

                // Construct a transform to translate the map keeping the present position centered

                Matrix transformMatrix = new Matrix();

                transformMatrix.Translate(-PresentPosition.X, -PresentPosition.Y);

                e.Graphics.Transform = transformMatrix;

                e.Graphics.DrawImage(MapBitmap, NorthUpPictureBox.Width / 2, NorthUpPictureBox.Height / 2);

                // Construct a new transform to display a carrat indicating present heading

                transformMatrix = new Matrix();

                transformMatrix.Translate(NorthUpPictureBox.Width / 2, NorthUpPictureBox.Height / 2);
                transformMatrix.RotateAt(-trueHeading, new PointF(20, 20));

                e.Graphics.Transform = transformMatrix;

                e.Graphics.DrawString("^", new Font(DefaultFont.FontFamily, 40), Brushes.Black, 0, 0);

                //Draw Cross

                e.Graphics.ResetTransform();
                Rectangle rc = NorthUpPictureBox.ClientRectangle;

                e.Graphics.DrawLine(Pens.Red, rc.Width / 2, rc.Height / 2 + 10, rc.Width / 2, rc.Height / 2 - 10);
                e.Graphics.DrawLine(Pens.Red, rc.Width / 2 + 10, rc.Height / 2, rc.Width / 2 - 10, rc.Height / 2);

            }
        }

        private void HeadingUpPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (MapImage != null)
            {
                e.Graphics.ResetTransform();

                Matrix transformMatrix = new Matrix();

                transformMatrix.Translate(-PresentPosition.X, -PresentPosition.Y);
                transformMatrix.RotateAt(trueHeading, new PointF(HeadingUpPictureBox.Width / 2 + PresentPosition.X, HeadingUpPictureBox.Height / 2 + PresentPosition.Y));

                e.Graphics.Transform = transformMatrix;

                e.Graphics.DrawImage(MapBitmap, HeadingUpPictureBox.Width / 2, HeadingUpPictureBox.Height / 2);
                
                //Draw Cross

                e.Graphics.ResetTransform();
                Rectangle rc = NorthUpPictureBox.ClientRectangle;

                e.Graphics.DrawLine(Pens.Red, rc.Width / 2, rc.Height / 2 + 10, rc.Width / 2, rc.Height / 2 - 10);
                e.Graphics.DrawLine(Pens.Red, rc.Width / 2 + 10, rc.Height / 2, rc.Width / 2 - 10, rc.Height / 2);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MapImage = Image.FromFile("C:\\MRC 42085H UTM 16N N 4756980 E 609580 NAD83 4m.jpg");
                MapBitmap = (Bitmap)Bitmap.FromFile("C:\\MRC 42085H UTM 16N N 4756980 E 609580 NAD83 4m.jpg");

                MapBitmap.SetResolution(96, 96);

                using (Graphics g = Graphics.FromImage(MapBitmap))
                {
                    using (Pen BluePen = new Pen(Color.Blue, 3))
                    {
                        g.DrawLine(BluePen, MapBitmap.Width / 2, MapBitmap.Height / 2 + 10, MapBitmap.Width / 2, MapBitmap.Height / 2 - 10);
                        g.DrawLine(BluePen, MapBitmap.Width / 2 + 10, MapBitmap.Height / 2, MapBitmap.Width / 2 - 10, MapBitmap.Height / 2);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ensure C:\\MRC 42085H UTM 16N N 4756980 E 609580 NAD83 4m.jpg exists!");
            }

        }
    }
}