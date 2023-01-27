using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ExpressedEngine.ExpressedEngine;
using System.Windows.Forms;

namespace ExpressedEngine
{
    class DemoGame : ExpressedEngine.ExpressedEngine
    {
        Shape2D Player1;
        NuggieShape Nuggie1;
        Collision collision1;

        bool left;
        bool right;
        bool up;
        bool down;
        bool interact;

        public DemoGame() : base(new Vector2(615,520),"Expressed Engine Demo"){}

        public override void Onload()
        {
            BackgroundColour = Color.White;

            Nuggie1 = new NuggieShape(new Vector2(40, 40), new Vector2(40, 240), "lol");
            Nuggie1 = new NuggieShape(new Vector2(120, 40), new Vector2(160, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(240, 0), new Vector2(40, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(80, 120), new Vector2(240, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(80, 200), new Vector2(280, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(160, 40), new Vector2(160, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(360, 40), new Vector2(40, 280), "lol");
            Nuggie1 = new NuggieShape(new Vector2(400, 120), new Vector2(80, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(440, 200), new Vector2(80, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(440, 0), new Vector2(40, 120), "lol");
            Nuggie1 = new NuggieShape(new Vector2(520, 40), new Vector2(40, 440), "lol");
            Nuggie1 = new NuggieShape(new Vector2(120, 280), new Vector2(200, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(120, 320), new Vector2(40, 160), "lol");
            Nuggie1 = new NuggieShape(new Vector2(40, 320), new Vector2(40, 120), "lol");
            Nuggie1 = new NuggieShape(new Vector2(440, 200), new Vector2(120, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(200, 400), new Vector2(360, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(440, 280), new Vector2(40, 120), "lol");
            Nuggie1 = new NuggieShape(new Vector2(360, 360), new Vector2(40, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(280, 320), new Vector2(40, 40), "lol");
            Nuggie1 = new NuggieShape(new Vector2(200, 360), new Vector2(40, 40), "lol");

            Nuggie1 = new NuggieShape(new Vector2(490, 450), new Vector2(20, 20), "door");

            collision1 = new Collision(new Vector2(490, 450), new Vector2(20, 20), "collisiontest");

            Player1 = new Shape2D(new Vector2(570, 450), new Vector2(20, 20), "player");
        }

        public override void OnDraw()
        {
        }
        
        float x = 0.1f;
        float y = 0.1f;
        public override void OnUpdate()
        {
            if (up)
            {
                Player1.postition.Y -= 5f;
            }
            if (down)
            {
                Player1.postition.Y += 5f;
            }
            if (left)
            {
                Player1.postition.X -= 5f;
            }
            if (right)
            {
                Player1.postition.X += 5f;
            }
            if (interact)
            {
                bool isCorrect = false;

                while (!isCorrect)
                {
                    Console.WriteLine("What is the capital of France? ");
                    Console.WriteLine("A. Paris");
                    Console.WriteLine("B. London");
                    Console.WriteLine("C. Rome");

                    string userAnswer = Console.ReadLine();

                    switch (userAnswer.ToUpper())
                    {
                        case "A":
                            Console.WriteLine("Correct! The capital of France is Paris.");
                            isCorrect = true;
                            break;
                        case "B":
                            Console.WriteLine("Incorrect. The capital of France is not London.");
                            break;
                        case "C":
                            Console.WriteLine("Incorrect. The capital of France is not Rome.");
                            break;
                        default:
                            Console.WriteLine("Invalid answer. Please select A, B or C.");
                            break;
                    }
                }
            }
        }
        public override void GetKeyDown(KeyEventArgs e)
        {
           if (e.KeyCode == Keys.W) { up = true; }
           if (e.KeyCode == Keys.S) { down = true; }
           if (e.KeyCode == Keys.A) { left  = true; }
           if (e.KeyCode == Keys.D) { right = true; }
           if (e.KeyCode == Keys.E){ interact = true; }
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
            if (e.KeyCode == Keys.E){ interact = false; }
        }

    }
}
