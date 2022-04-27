using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class MidBossMovement : Movement
    {
        //private int stepCount;
        int waitCounter;

        public MidBossMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
        {
            stepCount = -1;
            waitCounter = 0;
        }

        public override int getStepCount()
        {
            return this.stepCount;
        }

        public override Vector2 Move(Vector2 position, double elapsedTime)
        {
            Vector2 distance = new Vector2(0, 0);
            //int waitCounter = 0;

            if (stepCount == 12) //exit
            {
                distance.X = 0;
                distance.Y = -this.speed.Y * (float)elapsedTime;
                return position + distance;
            }
            if (stepCount == -1)
            {
                if (position.X < 350)
                {
                    distance.X = this.speed.X * (float)elapsedTime;
                    distance.Y = 0;
                }
                else if (position.X > 350)
                {
                    distance.X = -this.speed.X * (float)elapsedTime;
                    distance.Y = 0;
                }
                else
                {
                    distance.Y = this.speed.Y * (float)elapsedTime;
                    distance.X = 0;
                    if (position.Y >= 150)//this.startPos.Y + 170
                        stepCount++;
                }
                
            }
            else if (stepCount % 3 == 0) //top
            {
                if (waitCounter < 120)//stall 2 seconds
                {
                    waitCounter++;
                    distance.X = 0;
                    distance.Y = 0;
                    //return distance + position;
                }
                else
                {
                    distance.X = this.speed.X * (float)elapsedTime;
                    distance.Y = this.speed.Y * (float)elapsedTime;
                    if (position.X >= 500)//this.startPos.X + 150
                    {
                        stepCount++;
                        waitCounter = 0;
                    }
                }
                
            }
            else if (stepCount % 3 == 1)//right
            {
                if (waitCounter < 120)//stall 2 seconds
                {
                    waitCounter++;
                }
                else
                {
                    distance.X = -this.speed.X * (float)elapsedTime;
                    distance.Y = 0;
                    if (position.X <= 200)//this.startPos.X - 150
                    {
                        stepCount++;
                        waitCounter = 0;
                    }
                }
            }
            else if (stepCount % 3 == 2)//left
            {
                if (waitCounter < 120)
                {
                    waitCounter++;
                }
                else
                {
                    distance.X = this.speed.X * (float)elapsedTime;
                    distance.Y = -this.speed.Y * (float)elapsedTime;
                    if (position.Y <= 150)//this.startPos.Y + 170
                    {
                        stepCount++;
                        waitCounter = 0;
                    }
                }
                
            }

            return position + distance;
        }
    }
}
