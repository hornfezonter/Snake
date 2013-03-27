using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Sprites
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

    public class SnakeSegment:Tile
    {
        protected Direction direction;

        public SnakeSegment() : base(){ }

        public SnakeSegment(Texture2D _img, Vector2 _origin, Point _position) : base(_img, _origin, _position) { }

        public SnakeSegment(Texture2D _img, Vector2 _origin, Point _position, Point _frameSize, Point _sheetSize) : base(_img, _origin, _position, _frameSize, _sheetSize) { }

    }
}
