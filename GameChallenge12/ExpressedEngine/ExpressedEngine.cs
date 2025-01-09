using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace ExpressedEngine.ExpressedEngine
{
    class Canvas : Form
    {
        // Panels used in the Canvas
        private Panel[] panels;

        public Canvas()
        {
            // Enable double buffering to reduce flicker
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialize panels
            panels = new Panel[11];
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i] = new Panel
                {
                    BackColor = Color.Bisque,
                    Size = new Size(30, 30),
                    Location = new Point(29 + (i % 4) * 30, 29 + (i / 4) * 30)
                };
                this.Controls.Add(panels[i]);
            }

            // Adjust specific panel sizes and locations
            panels[4].Size = new Size(117, 30);
            panels[4].Location = new Point(87, 29);
            panels[7].Location = new Point(174, 0);

            // Canvas properties
            this.BackColor = SystemColors.Control;
            this.ClientSize = new Size(426, 339);
            this.Name = "Canvas";
            this.ResumeLayout(false);
        }
    }
    public abstract class ExpressedEngine
    {
        // Screen size and title of the game window
        private Vector2 ScreenSize = new Vector2(512, 480);
        private string Title = "New Game";
        private Canvas Window = null;
        private Thread GameLoopThread = null;

        // Lists to hold different game objects
        private static List<Shape2D> AllShapes = new List<Shape2D>();
        protected static List<WallShape> WallShapes = new List<WallShape>();
        private static List<Sprite2D> AllSprites = new List<Sprite2D>();
        private static List<Collision> Collisions = new List<Collision>();
        protected static List<System.Drawing.Rectangle> rect = new List<System.Drawing.Rectangle>();

        // Player rectangle
        public System.Drawing.Rectangle player;

        // Background color of the game window
        public Color BackgroundColour = Color.Beige;

        // Camera position and angle
        public Vector2 CameraPosition = Vector2.Zero();
        public float CameraAngle = 0f;

        public ExpressedEngine(Vector2 ScreenSize, String Title)
        {
            // Initialize player rectangle
            player = new System.Drawing.Rectangle(570, 450, 20, 20);
            Log.Info("Game Is Starting");
            this.ScreenSize = ScreenSize;
            this.Title = Title;

            // Initialize game window
            Window = new Canvas();
            Window.Size = new Size((int)this.ScreenSize.X, (int)this.ScreenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            // Run the application
            Application.Run(Window);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            // Handle key up event
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle key down event
            GetKeyDown(e);
        }

        public static void RegisterShape(Shape2D shape)
        {
            // Register a Shape2D object
            AllShapes.Add(shape);
        }

        public static void RegisterShape(System.Drawing.Rectangle shape)
        {
            // Register a Rectangle object
            rect.Add(shape);
        }

        public static void RegisterShape(WallShape shape)
        {
            // Register a WallShape object
            WallShapes.Add(shape);
        }

        public static void RegisterShape(Collision collision)
        {
            // Register a Collision object
            Collisions.Add(collision);
        }

        public static void RegisterSprite(Sprite2D Sprite)
        {
            // Register a Sprite2D object
            AllSprites.Add(Sprite);
        }

        public static void UnRegisterShape(Shape2D shape)
        {
            // Unregister a Shape2D object
            AllShapes.Remove(shape);
        }

        public static void UnRegisterShape(WallShape shape)
        {
            // Unregister a WallShape object
            WallShapes.Remove(shape);
        }

        public static void UnRegisterSprite(Sprite2D Sprite)
        {
            // Unregister a Sprite2D object
            AllSprites.Remove(Sprite);
        }

        public static void UnRegisterShape(Collision collision)
        {
            // Unregister a Collision object
            Collisions.Remove(collision);
        }

        void GameLoop()
        {
            // Load game resources
            Onload();
            while (GameLoopThread.IsAlive)
            {
                try
                {
                    // Draw game objects
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });

                    // Update game logic
                    OnUpdate();
                    Collision();
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

            // Apply camera transformations
            g.TranslateTransform(CameraPosition.X, CameraPosition.Y);
            g.RotateTransform(CameraAngle);

            // Draw all shapes
            foreach (Shape2D Shape in AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.SeaGreen), Shape.postition.X, Shape.postition.Y, Shape.Scale.X, Shape.Scale.Y);
            }
            foreach (WallShape Shape in WallShapes)
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
            foreach (System.Drawing.Rectangle i in rect)
            {
                g.FillRectangle(new SolidBrush(Color.Blue), i);
            }
            g.FillRectangle(new SolidBrush(Color.Red), this.player);
        }

        // Abstract methods to be implemented by derived classes
        public abstract void Onload();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void Collision();

        protected void HandleCollision()
        {
            bool canMoveUp = true;
            bool canMoveDown = true;
            bool canMoveLeft = true;
            bool canMoveRight = true;

    foreach (var wall in WallShapes)
    {
        Rectangle wallRect = new Rectangle(
            Convert.ToInt32(wall.postition.X),
            Convert.ToInt32(wall.postition.Y),
            Convert.ToInt32(wall.Scale.X),
            Convert.ToInt32(wall.Scale.Y)
        );

        if (player.IntersectsWith(wallRect))
        {
            // Check collision from the top
            if (player.Bottom > wallRect.Top && player.Top < wallRect.Top)
            {
                canMoveDown = false;
            }
            // Check collision from the bottom
            if (player.Top < wallRect.Bottom && player.Bottom > wallRect.Bottom)
            {
                canMoveUp = false;
            }
            // Check collision from the left
            if (player.Right > wallRect.Left && player.Left < wallRect.Left)
            {
                canMoveRight = false;
            }
            // Check collision from the right
            if (player.Left < wallRect.Right && player.Right > wallRect.Right)
            {
                canMoveLeft = false;
            }
        }
    }

            // Update player movement based on collision checks
            if (canMoveUp)
            {
                // Allow movement up
            }
            if (canMoveDown)
            {
                // Allow movement down
            }
            if (canMoveLeft)
            {
                // Allow movement left
            }
            if (canMoveRight)
            {
                // Allow movement right
            }
        }

        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
    }
}
