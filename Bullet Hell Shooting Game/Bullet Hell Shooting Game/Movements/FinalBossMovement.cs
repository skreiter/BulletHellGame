using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Movements
{
    internal class FinalBossMovement : Movement
    {
        //private int stepCount;
        private int waitCounter;

        public FinalBossMovement(Vector2 newSpeed, Vector2 newPos, Vector2 size) : base(newSpeed, newPos, size)
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
            Vector2 distance = new Vector2(0,0);
            //int waitCounter = 0;

            if(stepCount <= 12) //first phase
            {
                if (stepCount == 12) //exit
                {
                    distance.X = -this.speed.X * (float)elapsedTime;
                    distance.Y = 0;
                    if (position.X <= 100)//this.startPos.X - 250
                    {
                        stepCount++;// ==13
                        waitCounter = 0;
                    }
                }
                if (stepCount == -1)
                {
                    if(position.X < 350)
                    {
                        distance.X = this.speed.X * (float)elapsedTime;
                        distance.Y = 0;   
                    }
                    else if(position.X >350)
                    {
                        distance.X = -this.speed.X * (float)elapsedTime;
                        distance.Y = 0;
                    }
                    else
                    {
                        distance.Y = this.speed.X * (float)elapsedTime;
                        distance.X = 0;
                        if (position.Y >= 150)//depth=150 //this.startPos.Y + 170
                            stepCount++;
                    }
                    
                }
                else if (stepCount % 3 == 0) //top
                {
                    if (waitCounter < 120)//stall 2 seconds
                    {
                        waitCounter++;
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
            }
            else if(stepCount <= 27)//Second phase
            {
                if (stepCount == 27)
                {
                    distance.X = this.speed.X * (float)elapsedTime;
                    distance.Y = this.speed.Y * (float)elapsedTime;
                    if (position.X >= 600)//this.startPos.X + 250
                    {
                        stepCount++;
                        waitCounter = 0;
                    }
                }
                if(stepCount % 6 == 0)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = -this.speed.X * (float)elapsedTime;
                        distance.Y = 0;
                        if (position.X <= 100)//this.startPos.X - 250
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if(stepCount % 6 == 1)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = 0;
                        distance.Y = this.speed.Y * (float)elapsedTime;
                        if (position.Y >= 600) //this.startPos.Y + 620
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if (stepCount % 6 == 2)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = 0;
                        distance.Y = -this.speed.Y * (float)elapsedTime;
                        if (position.Y <= 100) //this.startPos.Y + 120
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                    

                }
                else if (stepCount % 6 == 3)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = this.speed.X * (float)elapsedTime;
                        distance.Y = 0;
                        if (position.X >= 600) //this.startPos.X + 250
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if (stepCount % 6 == 4)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = 0;
                        distance.Y = this.speed.Y * (float)elapsedTime;
                        if (position.Y >= 600) //this.startPos.Y + 620
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }   
                }
                else if (stepCount % 6 == 5)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = 0;
                        distance.Y = -this.speed.Y * (float)elapsedTime;
                        if (position.Y <= 100) //this.startPos.Y + 120
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }  
                }
            }
            else if(stepCount <= 39)// third phase
            {
                if (stepCount == 39)
                {
                    distance.X =this.speed.X * (float)elapsedTime;
                    distance.Y =this.speed.Y * (float)elapsedTime;
                    if(position.X >= 300)//this.startPos.X - 50
                    {
                        stepCount++;
                        waitCounter = 0;
                    }
                }
                if(stepCount % 4 == 0)
                {if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = 0;
                        distance.Y = -this.speed.X * (float)elapsedTime;
                        if (position.Y <= 100)//this.startPos.Y + 120
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if(stepCount % 4 == 1)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = -this.speed.X * (float)elapsedTime;
                        distance.Y = this.speed.Y * (float)elapsedTime;
                        if (position.X <= 100)//this.startPos.X - 250
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                    
                }
                else if (stepCount % 4 == 2)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = 0;
                        distance.Y = -this.speed.Y * (float)elapsedTime;
                        if (position.Y <= 100)//this.startPos.Y + 120
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                    
                }
                else if (stepCount % 4 == 3)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = this.speed.X * (float)elapsedTime;
                        distance.Y = this.speed.Y * (float)elapsedTime;
                        if (position.X >= 600)//this.startPos.X + 250
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    } 
                }
            }
            else if(stepCount <= 55)
            {
                if(stepCount == 55)
                {
                    distance.X = 0;
                    distance.Y = -this.speed.Y * (float)elapsedTime;
                }
                if(stepCount % 8 == 0)
                {
                    if(waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = 0;
                        distance.Y = this.speed.Y * (float)elapsedTime;
                        if (position.Y >= 400)//this.startPos.Y + 420
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                    
                }
                else if(stepCount % 8 == 1)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = -this.speed.X * (float)elapsedTime;
                        distance.Y = this.speed.Y * (float)elapsedTime;
                        if (position.X <= 100)//this.startPos.X -250
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if (stepCount % 8 == 2)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = this.speed.X * (float)elapsedTime;
                        distance.Y = 0;
                        if (position.X >= 600)//this.startPos.X + 250
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if (stepCount % 8 == 3)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = -this.speed.X * (float)elapsedTime;
                        distance.Y = -this.speed.Y * (float)elapsedTime;
                        if (position.X <= 400)//this.startPos.X + 50
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if (stepCount % 8 == 4)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = 0;
                        distance.Y = -this.speed.Y * (float)elapsedTime;
                        if (position.Y <= 300)//this.startPos.Y + 320
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if (stepCount % 8 == 5)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = this.speed.X * (float)elapsedTime;
                        distance.Y = -this.speed.Y * (float)elapsedTime;
                        if (position.X >= 600)//this.startPos.X + 250
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if (stepCount % 8 == 6)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = -this.speed.X * (float)elapsedTime;
                        distance.Y = 0;
                        if (position.X <= 100)//this.startPos.X - 250
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
                else if (stepCount % 8 == 7)
                {
                    if (waitCounter < 120)
                    {
                        waitCounter++;
                    }
                    else
                    {
                        distance.X = this.speed.X * (float)elapsedTime;
                        distance.Y = this.speed.Y * (float)elapsedTime;
                        if (position.X <= 300)//this.startPos.X - 50
                        {
                            stepCount++;
                            waitCounter = 0;
                        }
                    }
                }
            }


            return distance + position;
        }
    }
}
