using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace ExpressedEngine.ExpressedEngine
{
    class Canvas : Form
    {
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private Panel panel11;
        private Panel panel1;

        public Canvas()
        {
            this.DoubleBuffered = true;
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Location = new System.Drawing.Point(145, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 30);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Bisque;
            this.panel2.Location = new System.Drawing.Point(29, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(30, 30);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Bisque;
            this.panel3.Location = new System.Drawing.Point(174, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(30, 30);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Bisque;
            this.panel4.Location = new System.Drawing.Point(116, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(30, 30);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Bisque;
            this.panel5.Location = new System.Drawing.Point(87, 29);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(117, 30);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Bisque;
            this.panel6.Location = new System.Drawing.Point(29, 58);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(30, 30);
            this.panel6.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Bisque;
            this.panel7.Location = new System.Drawing.Point(29, 87);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(30, 30);
            this.panel7.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Bisque;
            this.panel8.Location = new System.Drawing.Point(174, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(30, 30);
            this.panel8.TabIndex = 7;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Bisque;
            this.panel9.Location = new System.Drawing.Point(29, 116);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(30, 30);
            this.panel9.TabIndex = 8;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Bisque;
            this.panel10.Location = new System.Drawing.Point(29, 145);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(30, 30);
            this.panel10.TabIndex = 9;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Bisque;
            this.panel11.Location = new System.Drawing.Point(29, 174);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(30, 30);
            this.panel11.TabIndex = 10;
            // 
            // Canvas
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(426, 339);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Canvas";
            this.ResumeLayout(false);

        }
    }
    public abstract class ExpressedEngine
    {
        private Vector2 ScreenSize = new Vector2(512, 480);
        private string Title = "New Game";
        private Canvas Window = null;
        private Thread GameLoopThread = null;

        private static List<Shape2D> AllShapes = new List<Shape2D>();
        protected static List<NuggieShape> NuggieShapes = new List<NuggieShape>();
        private static List<Sprite2D> AllSprites = new List<Sprite2D>(); 
        private static List<Collision> Collisions = new List<Collision>();

        public Color BackgroundColour = Color.Beige;

        public Vector2 CameraPosition = Vector2.Zero();
        public float CameraAngle = 0f;
        public ExpressedEngine(Vector2 ScreenSize, String Title)
        {
            Log.Info("Game Is Starting");
            this.ScreenSize = ScreenSize;
            this.Title = Title;

            Window = new Canvas();
            Window.Size = new Size((int)this.ScreenSize.X, (int)this.ScreenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }
        public static void RegisterShape(NuggieShape shape)
        {
            NuggieShapes.Add(shape);
        }
        public static void RegisterShape(Collision collision)
        {
            Collisions.Add(collision);
        }
        public static void RegisterSprite(Sprite2D Sprite)
        {
            AllSprites.Add(Sprite);
        }

        public static void UnRegisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
        }
        public static void UnRegisterShape(NuggieShape shape)
        {
            NuggieShapes.Remove(shape);
        }
        public static void UnRegisterSprite(Sprite2D Sprite)
        {
            AllSprites.Remove(Sprite);
        }
        public static void UnRegisterShape(Collision collision)
        {
            Collisions.Remove(collision);
        }

        public static void collisiondetect()
        {

        }
        void GameLoop()
        {

            Onload();
            while (GameLoopThread.IsAlive) {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
  
                    OnUpdate();
                    Thread.Sleep(10);
                }
                catch 
                {
                    Log.Error("Game Has Not Been Found");
                    break;               
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColour);

            g.TranslateTransform(CameraPosition.X, CameraPosition.Y);
            g.RotateTransform(CameraAngle);

            foreach (Shape2D Shape in AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.SeaGreen),Shape.postition.X,Shape.postition.Y,Shape.Scale.X,Shape.Scale.Y);
            }
            foreach (NuggieShape Shape in NuggieShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Blue), Shape.postition.X, Shape.postition.Y, Shape.Scale.X, Shape.Scale.Y);
            }
            foreach (Sprite2D Sprite in AllSprites)
            {
                g.DrawImage(Sprite.Sprite, Sprite.postition.X, Sprite.postition.Y, Sprite.Scale.X, Sprite.Scale.Y);
            }
            foreach (Collision collision in Collisions)
            {
                g.FillRectangle(new SolidBrush(Color.Red), collision.postition.X, collision.postition.Y, collision.Scale.X, collision.Scale.Y);
            }

        }

        public abstract void Onload();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
    }
}
