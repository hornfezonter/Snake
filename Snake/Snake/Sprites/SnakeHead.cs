using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Sprites
{
    public class SnakeHead:SnakeSegment
    {
        protected Direction nextDirection;

         public SnakeHead() : base(){ }

        public SnakeHead(Texture2D _img, Vector2 _origin, Point _position) : base(_img, _origin, _position) { }

        public SnakeHead(Texture2D _img, Vector2 _origin, Point _position, Point _frameSize, Point _sheetSize) : base(_img, _origin, _position, _frameSize, _sheetSize) { }

        public bool turn(Direction dir)
        {
            if (direction == Direction.Down || direction == Direction.Up)
            {
                if (dir == Direction.Left || dir == Direction.Right)
                {
                    nextDirection = dir;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (dir == Direction.Down || dir == Direction.Up)
                {
                    nextDirection = dir;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
