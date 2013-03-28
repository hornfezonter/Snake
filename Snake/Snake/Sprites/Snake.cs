using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Sprites
{
    public class Snake
    {
        protected SnakeHead head;
        protected List<SnakeBody> body;
        protected SnakeTail tail;

        public Snake()
        {
            head = new SnakeHead();
            body = new List<SnakeBody>();
            body.Add(new SnakeBody());
            tail = new SnakeTail();
        }

        //蛇的最短长度为3
        public Snake(Direction _direction, int length)
        {
            if (length < 3)
                length = 3;

            head = new SnakeHead();
            body = new List<SnakeBody>();
            for (int i = 0; i < length - 2; i++)
                body.Add(new SnakeBody());
            tail = new SnakeTail();

            head.CurrentDirection = _direction;
            head.NextDirection = _direction;
            for (int i = 0; i < body.Count; i++)
            {
                body[i].CurrentDirection = _direction;
                body[i].PreDirection = _direction;
            }
            tail.CurrentDirection = _direction;
        }
    }
}
