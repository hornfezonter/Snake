using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Snake.Sprites;

using System.Diagnostics;

namespace Snake
{
    public enum Contain
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
        protected Vector2 origin;
        protected List<Stone> stones;

        protected int timePerMove;
        protected int timeSinceLastMove;

        #endregion

        public Scene(Game game)
            : base(game)
        {
            origin = new Vector2(0, 0);
            stones = new List<Stone>();
            timePerMove = 1000;
            timeSinceLastMove = 0;
        }

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);          
            contains = new Contain[20, 20];
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    contains[i,j] = Contain.emtpy;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            img_head = Game.Content.Load<Texture2D>(@"images/head");
            img_straightBody = Game.Content.Load<Texture2D>(@"images/straightBody");
            img_cornerBody = Game.Content.Load<Texture2D>(@"images/cornerBody");
            img_tail = Game.Content.Load<Texture2D>(@"images/tail");
            Texture2D img_wall = Game.Content.Load<Texture2D>(@"images/objects/wall");

            for (int i = 0; i < 20; i++)
            {
                Stone stone = new Stone(img_wall, origin, new Point(i, 0));
                stones.Add(stone);
            }
            for (int i = 0; i < 20; i++)
            {
                Stone stone = new Stone(img_wall, origin, new Point(i, 18));
                stones.Add(stone);
            }
            for (int i = 1; i < 19; i++)
            {
                Stone stone = new Stone(img_wall, origin, new Point(0, i));
                stones.Add(stone);
            }
            for (int i = 1; i < 19; i++)
            {
                Stone stone = new Stone(img_wall, origin, new Point(18, i));
                stones.Add(stone);
            }

            player = new Snake.Sprites.Snake(origin, new Point(3, 3), img_head, img_straightBody, img_cornerBody, img_tail);
            contains[3, 3] = Contain.snakeHead;
            contains[3, 4] = Contain.snakeBody;
            contains[3, 5] = Contain.snakeTail;

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            foreach (Stone i in stones)
                i.Update(gameTime);

            timeSinceLastMove += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastMove >= timePerMove)
            {
                timeSinceLastMove = 0;
                player.move(false);
            }

            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.W) || key.IsKeyDown(Keys.Up))
                player.turn(Direction.Up);
            else if (key.IsKeyDown(Keys.S) || key.IsKeyDown(Keys.Down))
                player.turn(Direction.Down);
            else if (key.IsKeyDown(Keys.A) || key.IsKeyDown(Keys.Left))
                player.turn(Direction.Left);
            else if (key.IsKeyDown(Keys.D) || key.IsKeyDown(Keys.Right))
                player.turn(Direction.Right);


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            player.Draw(gameTime, spriteBatch);
            Debug.WriteLine(stones.Count);
            foreach (Stone s in stones)
            {
                //Debug.WriteLine(s);
                s.Draw(gameTime, spriteBatch);
            }
            
            base.Draw(gameTime);
        }

    }
}
