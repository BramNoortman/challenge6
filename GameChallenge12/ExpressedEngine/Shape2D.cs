using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressedEngine.ExpressedEngine
{
    public class Shape2D
    {
        public Vector2 postition = null;
        public Vector2 Scale = null;
        public string Tag = "";

        public Shape2D(Vector2 postition, Vector2 scale, string Tag)
        {
            this.postition = postition;
            this.Scale = scale;
            this.Tag = Tag;

            Log.Info($"[SHAPE2D]({Tag}) - Has Been Registerd");
            ExpressedEngine.RegisterShape(this);
        }
        public void DestroySelf()
        {
            Log.Info($"[SHAPE2D]({Tag}) - Has Been Destroyed");

            ExpressedEngine.UnRegisterShape(this);
        }
    }
}
