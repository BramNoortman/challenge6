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
        NuggieShape Wall;
        Collision collision1;
        BigDoorBenny door;
        bool left;
        bool right;
        bool up;
        bool down;
        bool interact;

        public DemoGame() : base(new Vector2(620,523),"Expressed Engine Demo"){}

        public override void Onload()
        {
            BackgroundColour = Color.White;
            Wall = new NuggieShape(new Vector2(600, 0), new Vector2(5, 615), "BoxInside");
            Wall = new NuggieShape(new Vector2(0,480), new Vector2(800, 5), "BoxInside");
            Wall = new NuggieShape(new Vector2(-25, 0), new Vector2(800, 5), "BoxInside");
            Wall = new NuggieShape(new Vector2(0, -1), new Vector2(5, 615), "BoxInside2");
            Wall = new NuggieShape(new Vector2(40, 40), new Vector2(40, 240), "wall1");
            Wall = new NuggieShape(new Vector2(120, 40), new Vector2(160, 40), "Wall2");
            Wall = new NuggieShape(new Vector2(240, 0), new Vector2(40, 40), "Wall3");
            Wall = new NuggieShape(new Vector2(80, 120), new Vector2(240, 40), "Wall4");
            Wall = new NuggieShape(new Vector2(80, 200), new Vector2(280, 40), "Wall5");
            Wall = new NuggieShape(new Vector2(160, 40), new Vector2(160, 40), "Wall6");
            Wall = new NuggieShape(new Vector2(360, 40), new Vector2(40, 280), "Wall7");
            Wall = new NuggieShape(new Vector2(400, 120), new Vector2(80, 40), "Wall8");
            Wall = new NuggieShape(new Vector2(440, 200), new Vector2(80, 40), "Wall9");
            Wall = new NuggieShape(new Vector2(440, 0), new Vector2(40, 120), "Wall10");
            Wall = new NuggieShape(new Vector2(520, 40), new Vector2(40, 440), "Wall11");
            Wall = new NuggieShape(new Vector2(120, 280), new Vector2(200, 40), "Wall12");
            Wall = new NuggieShape(new Vector2(120, 320), new Vector2(40, 160), "Wall13");
            Wall = new NuggieShape(new Vector2(40, 320), new Vector2(40, 120), "Wall14");
            Wall = new NuggieShape(new Vector2(440, 200), new Vector2(120, 40), "Wall15");
            Wall = new NuggieShape(new Vector2(200, 400), new Vector2(360, 40), "Wall16");
            Wall = new NuggieShape(new Vector2(440, 280), new Vector2(40, 120), "Wall17");
            Wall = new NuggieShape(new Vector2(360, 360), new Vector2(40, 40), "Wall18");
            Wall = new NuggieShape(new Vector2(280, 320), new Vector2(40, 40), "Wall19");
            Wall = new NuggieShape(new Vector2(200, 360), new Vector2(40, 40), "Wall20");

            door = new BigDoorBenny(new Vector2(490, 450), new Vector2(20, 20), "door");

            collision1 = new Collision(new Vector2(490, 450), new Vector2(20, 20), "collisiontest");
        }

        public override void OnDraw()
        {
        }
       
        public override void OnUpdate()
        {
            if (up)
            {
                player.Y -= 5;
            }
            if (down)
            {
                player.Y += 5;
            }
            if (left)
            {
                player.X -= 5;
            }
            if (right)
            {
                player.X += 5;
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

        public override void Collision()
        {
            foreach(System.Drawing.Rectangle i in rect)
            {
                if(i.IntersectsWith(player))
                {
                    if (up)
                    {
                        player.Y += 5;
                    }
                    if (down)
                    {
                        player.Y -= 5;
                    }
                    if (left)
                    {
                        player.X += 5;
                    }
                    if (right)
                    {
                        player.X -= 5;
                    }
                }
            }


        }

    }
}
