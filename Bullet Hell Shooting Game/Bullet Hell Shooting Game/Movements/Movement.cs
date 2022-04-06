using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    public  abstract class Movement
    {
        protected float speed;
        protected Vector2 startPos;
        protected Vector2 size;
        protected int stepCount;

        public Movement(float newSpeed, Vector2 newPos, Vector2 size)
        {
            this.speed = newSpeed;
            this.startPos = newPos;
            this.size = size;
        }

        public abstract Vector2 Move(Vector2 position, double elapsedTime);
        public abstract int getStepCount();
    }
}
