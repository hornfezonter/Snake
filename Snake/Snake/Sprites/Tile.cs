using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Sprites
{
    public abstract class Tile
    {
        protected Texture2D img;
        protected Point position;
        protected Vector2 origin;
        protected Point frameSize;
        protected Point currentFrame;
        protected Point sheetSize;
        protected int timeSinceLastFrame;
        protected int timePerFrame;
        protected int displayWidth;
        protected int displayHeight;

        public Tile() 
        {
            position = new Point(0,0);
            origin = new Vector2(0,0);
            frameSize = new Point(1,1);
            currentFrame = new Point(0,0);
            sheetSize = new Point(1,1);
            timePerFrame = 16;
            timeSinceLastFrame = 16;
        }

        public Tile(Texture2D _img, Vector2 _origin, Point _position)
            : this()
        {
            img = _img;
            origin = _origin;
            position = _position;
            displayHeight = _img.Height;
            displayWidth = _img.Width;
        }

        public Tile(Texture2D _img, Vector2 _origin, Point _position, Point _frameSize, Point _sheetSize)
            : this(_img, _origin, _position)
        {
            frameSize = _frameSize;
            sheetSize = _sheetSize;
        }


    }
}
