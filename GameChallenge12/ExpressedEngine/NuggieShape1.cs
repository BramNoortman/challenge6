using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ExpressedEngine.ExpressedEngine
{

    public class NuggieShape
        {
        public Vector2 postition = null;
        public Vector2 Scale = null;
        public string Tag = "";

        public NuggieShape(Vector2 postition, Vector2 scale, string Tag)
        {
            this.postition = postition;
            this.Scale = scale;
            this.Tag = Tag;

            Log.Info($"[NUGGIERECT]({Tag}) - Has Been Registerd");
            ExpressedEngine.RegisterShape(this);
        }
        public void DestroySelf()
        {
            Log.Info($"[NUGGIERECT]({Tag}) - Has Been Destroyed");

            ExpressedEngine.UnRegisterShape(this);
        }
    }
}