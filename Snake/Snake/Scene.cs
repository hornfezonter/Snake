using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Snake.Sprites;

namespace Snake
{
    enum Contain
    {
        food,
        snakeBody,
        snakeHead,
        snakeTail,
        stone,
        emtpy
    }

    public class Scene:DrawableGameComponent
    {
        #region 成员变量

        protected SpriteBatch spriteBatch;
        protected Texture2D img_background;
        protected Texture2D img_food;
        protected Texture2D img_head;
        protected Texture2D img_straightBody;
        protected Texture2D img_cornerBody;
        protected Texture2D img_tail;

        protected Contain[,] contains;
        protected Snake.Sprites.Snake player;

        #endregion

        public Scene(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            contains = new Contain[20, 20];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            img_head = Game.Content.Load<Texture2D>(@"image/head");

            base.LoadContent();
        }

    }
}
