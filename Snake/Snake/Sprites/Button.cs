using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Sprites
{
    class Button
    {
        protected Texture2D img;
        protected Vector2 position;
        protected int width;
        protected int height;

        public Button() { }

        public Button(Vector2 _position, Texture2D _img)
        {
            position = _position;
            img = _img;
            width = _img.Width;
            height = _img.Height;
        }

        public bool resize(int _width, int _height)
        {
            if (_width > 0 && _height > 0)
            {
                width = _width;
                height = _height;
                return true;
            }
            else
                return false;           
        }

        public void setPosition(Vector2 _pos)
        {
            position = _pos;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Rectangle rec = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(img, rec, Color.White);
        }

        public bool CheckPoint(Vector2 point)
        {
            if (point.X > position.X && point.X < point.X + width && point.Y > position.Y && point.Y < point.Y + height)
                return true;
            else
                return false;
        }  
    }
}
