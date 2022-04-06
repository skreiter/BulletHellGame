using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework.Content;

namespace Bullet_Hell_Shooting_Game.Bosses
{
    class FinalBoss : Boss
    {
        ContentManager content;
        private double screenTime;
        private bool clockWise;

        public FinalBoss(ContentManager content)
        {
            this.position.X = 350;
            this.position.Y = 10;
            this.texture = content.Load<Texture2D>("Dragon"); //Need to add correct Boss png.
            this.size.X = 50;
            this.size.Y = 50;
            this.speed.X = 0;
            this.speed.Y = 2.5f;
            this.stepCount = 0;
            this.health = 40;

            this.content = content;
            this.screenTime = 0;
            this.clockWise = true;

        }


        public override void UpdateDirection()
        {
            //first FinalBoss Pattern <20 sec
            if (screenTime < (60 * 22))
            {
                if (this.position.Y == 150)
                {
                    if (screenTime > (60 * 20)) //exit phase 60*27
                    {
                        this.speed.X = -2.5f;
                        this.speed.Y = 0;
                    }
                    else if (this.stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 2.5f;
                        this.speed.Y = 2.5f;
                    }
                }
                else if (this.position.X == 497.5)
                {
                    stepCount = 0;
                }
                else if (this.position.X == 500 && this.position.Y > 150)
                {
                    if (this.stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = -2.5f;
                        this.speed.Y = 0;
                    }
                }
                else if (this.position.X == 202.5)
                {
                    stepCount = 0;
                }
                else if (this.position.X == 200 && (screenTime < (60 * 20)))
                {
                    if (this.stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 2.5f;
                        this.speed.Y = -2.5f;
                    }
                }
                else if (this.position.X == 347.5)
                {
                    stepCount = 0;
                }
            }
            //second FinalBoss pattern 20<x<40
            else if (screenTime > (60 * 20) && screenTime < (60 * 39))//47
            {
                //setup
                if (this.position.X == 150 && this.position.Y == 150 && clockWise == true)
                {
                    this.speed.X = 0;
                    this.speed.Y = 2.5f;
                }
                else if (this.position.Y == 400 && this.position.X == 150 && clockWise == true)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.clockWise = true;
                        this.speed.X = 0;
                        this.speed.Y = -2.5f;
                    }
                }
                //stepcount LT v LB
                else if (this.position.Y == 397.5 && this.position.X == 150 && clockWise == false)
                {
                    stepCount = 0;
                }
                //LB ^ LT
                else if (this.position.Y == 400 && this.position.X == 150 && clockWise == false)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        clockWise = true;
                        this.speed.X = 0;
                        this.speed.Y = -2.5f;
                    }
                }
                //stepCount LB^LT
                else if (this.position.X == 150 && this.position.Y == 202.5 && clockWise == true)
                {
                    stepCount = 0;
                }
                //LT>RT
                else if (this.position.X == 150 && this.position.Y == 200 && clockWise == true)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 2.5f;
                        this.speed.Y = 0;
                    }
                }
                //stepCount LT>RT
                else if (this.position.X == 547.5 && this.position.Y == 200 && clockWise == true)
                {
                    stepCount = 0;
                }
                //RTvRB
                else if (this.position.X == 550 && this.position.Y == 200 && clockWise == true)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 0;
                        this.speed.Y = 2.5f;
                    }
                }
                //stepCount RTvRB
                else if (this.position.X == 550 && this.position.Y == 397.5 && clockWise == true)
                {
                    stepCount = 0;
                }
                //RB^RT
                else if (this.position.X == 550 && this.position.Y == 400 && clockWise == true)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        clockWise = false;
                        this.speed.X = 0;
                        this.speed.Y = -2.5f;
                    }
                }
                //stepCount RB^RT
                else if (this.position.X == 550 && this.position.Y == 202.5 && clockWise == false)
                {
                    stepCount = 0;
                }
                //RT>LT
                else if (this.position.X == 550 && this.position.Y == 200 && clockWise == false)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = -2.5f;
                        this.speed.Y = 0;
                    }
                }
                //stepCount RT>LT
                else if (this.position.X == 152.5 && this.position.Y == 200 && clockWise == false)
                {
                    stepCount = 0;
                }
                //LT>LB
                else if (this.position.X == 150 && this.position.Y == 200 && clockWise == false)
                {
                    //check screenTime -> execute pattern 3
                    if (screenTime > (60 * 38))
                    {
                        this.speed.X = 2.5f;
                        this.speed.Y = 0;//-2.5f
                    }
                    else if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 0;
                        this.speed.Y = 2.5f;
                    }
                }

            }
            else if (screenTime > (60 * 38) && screenTime < (60 * 69))
            {
                if (this.position.X == 500 && this.position.Y == 200)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = -2.5f;
                        this.speed.Y = 2.5f;
                    }

                }
                else if (this.position.X == 202.5 && this.position.Y == 497.5)
                {
                    stepCount = 0;
                }
                else if (this.position.X == 200 && this.position.Y == 500)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 0;
                        this.speed.Y = -2.5f;
                    }
                }
                else if (this.position.X == 200 && this.position.Y == 202.5)
                {
                    stepCount = 0;
                }
                else if (this.position.X == 200 && this.position.Y == 200)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 2.5f;
                        this.speed.Y = 2.5f;
                    }
                }
                else if (this.position.X == 497.5 && this.position.Y == 497.5)
                {
                    stepCount = 0;
                }
                else if (this.position.X == 500 && this.position.Y == 500)
                {
                    if (screenTime > 60 * 68)
                    {
                        this.speed.X = -2.5f;
                        this.speed.Y = -2.5f;
                    }
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 0;
                        this.speed.Y = -2.5f;
                    }
                }
                else if (this.position.X == 500 && this.position.Y == 202.5)
                {
                    stepCount = 0;
                }

            }
            else if (screenTime > (60 * 69) && screenTime < (60 * 100))
            {
                if (this.position.X == 250 && this.position.Y == 250)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 2.5f;
                        this.speed.Y = 0;
                    }
                }
                else if (this.position.X == 347.5 && this.position.Y == 250)
                {
                    stepCount = 0;
                }
                if (this.position.X == 350 && this.position.Y == 250)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 0;
                        this.speed.Y = 2.5f;
                    }
                }
                else if (this.position.X == 350 && this.position.Y == 347.5)
                {
                    stepCount = 0;
                }
                if (this.position.X == 350 && this.position.Y == 350)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = -2.5f;
                        this.speed.Y = 0;
                    }
                }
                else if (this.position.X == 252.5 && this.position.Y == 350)
                {
                    stepCount = 0;
                }
                if (this.position.X == 250 && this.position.Y == 350)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = -2.5f;
                        this.speed.Y = 2.5f;
                    }
                }
                else if (this.position.X == 102.5 && this.position.Y == 497.5)
                {
                    stepCount = 0;
                }
                if (this.position.X == 100 && this.position.Y == 500)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 0;
                        this.speed.Y = -2.5f;
                    }
                }
                else if (this.position.X == 100 && this.position.Y == 102.5)
                {
                    stepCount = 0;
                }
                if (this.position.X == 100 && this.position.Y == 100)
                {
                    if (screenTime < (60 * 95))
                    {
                        this.speed.X = 0;
                        this.speed.Y = 10;
                    }
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 2.5f;
                        this.speed.Y = 0;
                    }
                }
                else if (this.position.X == 497.5 && this.position.Y == 100)
                {
                    stepCount = 0;
                }
                if (this.position.X == 500 && this.position.Y == 100)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = 0;
                        this.speed.Y = 2.5f;
                    }
                }
                else if (this.position.X == 500 && this.position.Y == 497.5)
                {
                    stepCount = 0;
                }
                if (this.position.X == 500 && this.position.Y == 500)
                {
                    if (stepCount < 120)
                    {
                        this.speed.X = 0;
                        this.speed.Y = 0;
                        stepCount++;
                    }
                    else
                    {
                        this.speed.X = -2.5f;
                        this.speed.Y = -2.5f;
                    }
                }
                else if (this.position.X == 252.5 && this.position.Y == 252.5)
                {
                    stepCount = 0;
                }

            }

            screenTime++;
        }

        public override bool Deleter()
        {
            if (this.position.X > 710 || this.position.Y < -5)
            {
                return true;
            }
            return false;
        }

        public override List<Projectile> Attack()
        {
            List<Projectile> finalAttacks = new List<Projectile>();
            if (this.screenTime < (60 * 22))
            {
                finalAttacks.AddRange(TriShot());
            }
            else if (screenTime > (60 * 22) && screenTime < (60 * 38))
            {
                finalAttacks.AddRange(ScatterShot());
            }
            else if (screenTime > (60 * 38) && screenTime < (60 * 69))
            {
                finalAttacks.AddRange(SunBurst());
            }
            else if (screenTime > (60 * 69) && screenTime < (60 * 95))
            {
                finalAttacks.AddRange(BowTie());
            }

            return finalAttacks;
        }

        public List<Projectile> TriShot()
        {
            List<Projectile> triShot = new List<Projectile>();
            Vector2 positionTemp1 = position;
            positionTemp1.X += 0;
            positionTemp1.Y += 120;
           // triShot.Add(new FinalBossProjectile(this.content, positionTemp1, 0, 10));
            Vector2 positionTemp2 = position;
            positionTemp2.X -= 65;
            positionTemp2.Y += 120;
           // triShot.Add(new FinalBossProjectile(this.content, positionTemp2, 0, 10));
            Vector2 positionTemp3 = position;
            positionTemp3.X += 120;
            positionTemp3.Y += 120;
          //  triShot.Add(new FinalBossProjectile(this.content, positionTemp3, 0, 10));

            return triShot;
        }

        public List<Projectile> ScatterShot()
        {
            List<Projectile> scatterShot = new List<Projectile>();
            Vector2 positionTemp1 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 120;
          //  scatterShot.Add(new FinalBossProjectile(this.content, positionTemp1, 0, 5));
            Vector2 positionTemp2 = position;
            positionTemp1.X += 60;
            positionTemp1.Y += 120;
          //  scatterShot.Add(new FinalBossProjectile(this.content, positionTemp2, -2, 5));
            Vector2 positionTemp3 = position;
            positionTemp1.X += 60;
            positionTemp1.Y += 120;
          //  scatterShot.Add(new FinalBossProjectile(this.content, positionTemp3, -4, 5));
            Vector2 positionTemp4 = position;
            positionTemp1.X += 60;
            positionTemp1.Y += 120;
         //   scatterShot.Add(new FinalBossProjectile(this.content, positionTemp4, 2, 5));
            Vector2 positionTemp5 = position;
            positionTemp1.X += 60;
            positionTemp1.Y += 120;
          //  scatterShot.Add(new FinalBossProjectile(this.content, positionTemp5, 4, 5));

            return scatterShot;
        }

        public List<Projectile> SunBurst()
        {
            List<Projectile> sunBurst = new List<Projectile>();
            Vector2 positionTemp1 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
         //   sunBurst.Add(new FinalBossProjectile(this.content, positionTemp1, 0, 5));
            Vector2 positionTemp2 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
          //  sunBurst.Add(new FinalBossProjectile(this.content, positionTemp2, 5, 0));
            Vector2 positionTemp3 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
         //   sunBurst.Add(new FinalBossProjectile(this.content, positionTemp3, -5, 0));
            Vector2 positionTemp4 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
        //    sunBurst.Add(new FinalBossProjectile(this.content, positionTemp4, 0, -5));
            Vector2 positionTemp5 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
         //   sunBurst.Add(new FinalBossProjectile(this.content, positionTemp5, 5, 5));
            Vector2 positionTemp6 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
         //   sunBurst.Add(new FinalBossProjectile(this.content, positionTemp6, -5, -5));
            Vector2 positionTemp7 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
         //   sunBurst.Add(new FinalBossProjectile(this.content, positionTemp7, 5, -5));
            Vector2 positionTemp8 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
           // sunBurst.Add(new FinalBossProjectile(this.content, positionTemp8, -5, 5));

            return sunBurst;
        }

        public List<Projectile> BowTie()
        {
            List<Projectile> bowTie = new List<Projectile>();
            Vector2 positionTemp1 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
           // bowTie.Add(new FinalBossProjectile(this.content, positionTemp1, 0, 5));
            Vector2 positionTemp2 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
           // bowTie.Add(new FinalBossProjectile(this.content, positionTemp2, 5, 0));
            Vector2 positionTemp3 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
          //  bowTie.Add(new FinalBossProjectile(this.content, positionTemp3, -5, 0));
            Vector2 positionTemp4 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
           // bowTie.Add(new FinalBossProjectile(this.content, positionTemp4, 0, -5));
            Vector2 positionTemp5 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
          //  bowTie.Add(new FinalBossProjectile(this.content, positionTemp5, 5, 2.5f));
            Vector2 positionTemp6 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
          //  bowTie.Add(new FinalBossProjectile(this.content, positionTemp6, 5, -2.5f));
            Vector2 positionTemp7 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
         //   bowTie.Add(new FinalBossProjectile(this.content, positionTemp7, -5, -2.5f));
            Vector2 positionTemp8 = position;
            positionTemp1.X += 65;
            positionTemp1.Y += 65;
         //   bowTie.Add(new FinalBossProjectile(this.content, positionTemp8, -5, 2.5f));

            return bowTie;
        }
    }
}
