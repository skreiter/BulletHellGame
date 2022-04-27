using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class GruntAMovement : Movement
    {
        //private int stepCount;

        public GruntAMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
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
                distance.X = this.speed.X * (float)elapsedTime;
                distance.Y = 0;
                return distance + position;
            }

            if (stepCount == -1)
            {
                distance.Y = this.speed.Y * (float)elapsedTime;
                distance.X = 0;
                if (position.Y >= this.startPos.Y + 30)
                    stepCount++;
            }
            else if (stepCount % 4 == 0)
            {
                distance.X = this.speed.X * (float)elapsedTime;
                distance.Y = this.speed.Y * (float)elapsedTime;
                if (position.X > this.startPos.X + 100)
                    stepCount++;
            }
            else if (stepCount % 4 == 1)
            {
                distance.X = -this.speed.X * (float)elapsedTime;
                distance.Y = this.speed.Y * (float)elapsedTime;
                if (position.Y >= this.startPos.Y + 230)
                    stepCount++;
            }
            else if (stepCount % 4 == 2)
            {
                distance.X = -this.speed.X * (float)elapsedTime;
                distance.Y = -this.speed.Y * (float)elapsedTime;
                if (position.X <= this.startPos.X - 100)
                    stepCount++;
            }
            else if (stepCount % 4 == 3)
            {
                distance.X = this.speed.X * (float)elapsedTime;
                distance.Y = -this.speed.Y * (float)elapsedTime;
                if (position.Y <= this.startPos.Y + 30)
                    stepCount++;
            }

            return position + distance;
        }
    }
}
