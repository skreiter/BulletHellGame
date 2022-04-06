using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class GruntAMovement : Movement
    {
        //private int stepCount;

        public GruntAMovement(float newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
        {
            stepCount = -1;
        }
        public override int getStepCount()
        {
            return this.stepCount;
        }

        public override Vector2 Move(Vector2 position, double elapsedTime)
        {
            Vector2 distance = new Vector2(0, 0);

            if (stepCount == 20)
            {
                distance.X = this.speed * (float)elapsedTime;
                distance.Y = 0;
                return distance + position;
            }

            if (stepCount == -1)
            {
                distance.Y = this.speed * (float)elapsedTime;
                distance.X = 0;
                if (position.Y >= this.startPos.Y + 30)
                    stepCount++;
            }
            else if (stepCount % 4 == 0)
            {
                distance.X = this.speed * (float)elapsedTime;
                distance.Y = this.speed * (float)elapsedTime;
                if (position.X > this.startPos.X + 100)
                    stepCount++;
            }
            else if (stepCount % 4 == 1)
            {
                distance.X = -this.speed * (float)elapsedTime;
                distance.Y = this.speed * (float)elapsedTime;
                if (position.Y >= this.startPos.Y + 230)
                    stepCount++;
            }
            else if (stepCount % 4 == 2)
            {
                distance.X = -this.speed * (float)elapsedTime;
                distance.Y = -this.speed * (float)elapsedTime;
                if (position.X <= this.startPos.X - 100)
                    stepCount++;
            }
            else if (stepCount % 4 == 3)
            {
                distance.X = this.speed * (float)elapsedTime;
                distance.Y = -this.speed * (float)elapsedTime;
                if (position.Y <= this.startPos.Y + 30)
                    stepCount++;
            }



            //if (position.Y < 20)
            //{
            //    distance.Y = this.speed;
            //}
            //else if (position.Y >= 20 && position.X < 450)
            //{
            //    if (stepCount == 2)
            //    {
            //        distance.X = this.speed;
            //        distance.Y = 0;
            //    }
            //    else
            //    {
            //        distance.X = this.speed;
            //        distance.Y = this.speed;
            //    }
            //}
            //else if (position.X == 450 && position.Y > 20)
            //{
            //    distance.X = -this.speed;
            //    distance.Y = this.speed;
            //}
            //else if (position.Y == 220)
            //{
            //    distance.X = -this.speed;
            //    distance.Y = -this.speed;
            //}
            //else if (position.X == 250)
            //{
            //    distance.X = this.speed;
            //    distance.Y = -this.speed;
            //}

            return position + distance;
        }
    }
}
