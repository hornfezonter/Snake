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
        empty
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
        protected bool[,] growPoints;
        protected Snake.Sprites.Snake player;
        protected Vector2 origin;
        protected List<Stone> stones;
        protected List<Food> foods;
        protected bool food_eaten;

        protected Random rand;

        protected int timePerMove;
        protected int timeSinceLastMove;

        #endregion

        public Scene(Game game)
            : base(game)
        {
            origin = new Vector2(15, 15);
            stones = new List<Stone>();
            foods = new List<Food>();
            timePerMove = 300;
            timeSinceLastMove = 0;
            rand = new Random();
        }

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);          
            contains = new Contain[20, 20];
            growPoints = new bool[20, 20];
            food_eaten = true;
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    contains[i, j] = Contain.empty;
                    growPoints[i, j] = false;
                }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            img_head = Game.Content.Load<Texture2D>(@"images/head");
            img_straightBody = Game.Content.Load<Texture2D>(@"images/straightBody");
            img_cornerBody = Game.Content.Load<Texture2D>(@"images/cornerBody");
            img_tail = Game.Content.Load<Texture2D>(@"images/tail");
            img_food = Game.Content.Load<Texture2D>(@"images/objects/meat");
            Texture2D img_wall = Game.Content.Load<Texture2D>(@"images/objects/wall");

            for (int i = 0; i < 20; i++)
            {
                Stone stone = new Stone(img_wall, origin, new Point(i, 0));
                stones.Add(stone);
                contains[i, 0] = Contain.stone;
            }
            for (int i = 0; i < 20; i++)
            {
                Stone stone = new Stone(img_wall, origin, new Point(i, 19));
                stones.Add(stone);
                contains[i, 19] = Contain.stone;
            }
            for (int i = 1; i < 19; i++)
            {
                Stone stone = new Stone(img_wall, origin, new Point(0, i));
                stones.Add(stone);
                contains[0,i] = Contain.stone;
            }
            for (int i = 1; i < 19; i++)
            {
                Stone stone = new Stone(img_wall, origin, new Point(19, i));
                stones.Add(stone);
                contains[19, i] = Contain.stone;
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
            foreach (Food f in foods)
                f.Update(gameTime);

            timeSinceLastMove += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastMove >= timePerMove)
            {
                bool grow = false;
                timeSinceLastMove = 0;

                Point tailPosition = player.TailPosition;
                if (growPoints[tailPosition.X, tailPosition.Y])
                {
                    grow = true;
                    growPoints[tailPosition.X, tailPosition.Y] = false;
                }

                Point nextPosition = player.NextPosition;
                if (contains[nextPosition.X, nextPosition.Y] == Contain.empty)
                {
                    player.move(grow);
                }
                else if (contains[nextPosition.X, nextPosition.Y] == Contain.food)
                {
                    Debug.WriteLine("alert");
                    player.move(grow);
                    Debug.WriteLine("1");
                    growPoints[nextPosition.X, nextPosition.Y] = true;
                    Debug.WriteLine("2");
                    foods.RemoveAt(0);
                    Debug.WriteLine("3");
                    food_eaten = true;
                }
                Debug.WriteLine("end");
            }

            if (food_eaten)
            {
                for (; ; )
                {
                    int roll = rand.Next(0, 400);
                    Debug.WriteLine(roll);

                    if (contains[roll/20, roll%20] == Contain.empty)
                    {
                        contains[roll/20, roll%20] = Contain.food;
                        foods.Add(new Food(img_food, origin, new Point(roll/20, roll%20)));
                        food_eaten = false;
                        break;
                    }
                    
                }
                
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
            //Debug.WriteLine(stones.Count);
            foreach (Stone s in stones)
            {
                s.Draw(gameTime, spriteBatch);
            }

            foreach (Food f in foods)
            {
                f.Draw(gameTime, spriteBatch);
            }
            
            base.Draw(gameTime);
        }

    }
}
