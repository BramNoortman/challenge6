using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ExpressedEngine.ExpressedEngine
{
    // Class representing a wall shape in the game
    public class WallShape
    {
        // Position of the wall shape
        public Vector2 postition = null;
        // Scale of the wall shape
        public Vector2 Scale = null;
        // Tag for identifying the wall shape
        public string Tag = "";

        // Constructor to initialize the wall shape
        public WallShape(Vector2 postition, Vector2 scale, string Tag)
        {
            this.postition = postition;
            this.Scale = scale;
            this.Tag = Tag;

            // Create a rectangle representing the wall shape
            Rectangle rectangle = new Rectangle(
              (int)postition.X,
              (int)postition.Y,
              (int)Scale.X,
              (int)scale.Y);

            // Log the registration of the wall shape
            Log.Info($"[WALLRECT]({Tag}) - Has Been Registered");
            // Register the wall shape with the engine
            ExpressedEngine.RegisterShape(rectangle);
        }

        // Method to destroy the wall shape
        public void DestroySelf()
        {
            // Log the destruction of the wall shape
            Log.Info($"[WALLRECT]({Tag}) - Has Been Destroyed");
            // Unregister the wall shape from the engine
            ExpressedEngine.UnRegisterShape(this);
        }
    }
}