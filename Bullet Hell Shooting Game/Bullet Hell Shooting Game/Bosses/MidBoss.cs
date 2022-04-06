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
    class MidBoss : Boss
    {
        ContentManager content;
        private double screenTime;


        public MidBoss(ContentManager content)//replace Texture2D texture with ContentManager content
        {
            this.position.X = 350;
            this.position.Y = 10;//-
            this.texture = content.Load<Texture2D>("Crab"); //texture
            this.size.X = 50;
            this.size.Y = 50;
            this.speed.X = 0;
            this.speed.Y = 2.5f;
            this.stepCount = 0;
            this.health = 15;

            this.content = content;
            this.screenTime = 0;


        }

        public override void UpdateDirection()
        {
            if (this.position.Y == 150)
            {
                if (screenTime > (60 * 27)) //exit phase 60*27
                {
                    this.speed.X = 0;
                    this.speed.Y = -2.5f;
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
            else if (this.position.X == 200)
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
            List<Projectile> triShot = new List<Projectile>();
            Vector2 positionTemp1 = position;
            positionTemp1.X += 0;
            positionTemp1.Y += 120;
            //triShot.Add(new MidBossProjectile(this.content, positionTemp1));
            Vector2 positionTemp2 = position;
            positionTemp2.X -= 65;
            positionTemp2.Y += 120;
            //triShot.Add(new MidBossProjectile(this.content, positionTemp2));
            Vector2 positionTemp3 = position;
            positionTemp3.X += 120;
            positionTemp3.Y += 120;
            //triShot.Add(new MidBossProjectile(this.content, positionTemp3));

            return triShot;
        }
    }
}
