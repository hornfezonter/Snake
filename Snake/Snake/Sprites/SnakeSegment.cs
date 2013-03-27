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

        public SnakeSegment() : base()
        {
            direction = Direction.Up;
        }

        public SnakeSegment(Texture2D _img, Vector2 _origin, Point _position) : base(_img, _origin, _position) {
            direction = Direction.Up;
        }

        public SnakeSegment(Texture2D _img, Vector2 _origin, Point _position, Point _frameSize, Point _sheetSize) : base(_img, _origin, _position, _frameSize, _sheetSize) {
            direction = Direction.Up;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle destRec = new Rectangle((int)(origin.X+position.X*displayWidth), (int)(origin.Y+position.Y*displayHeight), displayWidth,displayHeight);
            Vector2 rotationOrigin = new Vector2((float)(origin.X+position.X*displayWidth + displayWidth * 0.5), (float)(origin.Y+position.Y*displayHeight + displayHeight * 0.5));
            float rotation;

            switch (direction)
            {
                case Direction.Up:
                    rotation = 0;
                    break;
                case Direction.Left:
                    rotation = 90;
                    break;
                case Direction.Down:
                    rotation = 180;
                    break;
                case Direction.Right:
                    rotation = 270;
                    break;
                default:
                    rotation = 0;
                    break;
            }

            spriteBatch.Begin();
            spriteBatch.Draw(img, destRec, null, Color.White, rotation, rotationOrigin, SpriteEffects.None, 0.5f);
            spriteBatch.End();
        }
    }
}
