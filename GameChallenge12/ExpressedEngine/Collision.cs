using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpressedEngine.ExpressedEngine;


namespace ExpressedEngine.ExpressedEngine
{
    public class Collision
    {
        public Vector2 postition = null;
        public Vector2 Scale = null;
        public string Tag = "";

        public Collision(Vector2 postition, Vector2 scale, string Tag)
        {
            this.postition = postition;
            this.Scale = scale;
            this.Tag = Tag;

            Log.Info($"[Collision]({Tag}) - Has Been Registerd");
            ExpressedEngine.RegisterShape(this);
        }
        public void DestroySelf()
        {
            Log.Info($"[Collision]({Tag}) - Has Been Destroyed");

            ExpressedEngine.UnRegisterShape(this);
        }
        public void Detection()
        {
            Log.Detection($"[detection]({Tag}) - Collision Detected");


        }
    }
}
