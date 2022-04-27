﻿using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.PowerUps
{
    internal class PowerUpFactory
    {
        ContentManager content;

        public PowerUpFactory(ContentManager con)
        {
            content = con;
        }

        public PowerUp Create()
        {
            Random random = new Random();
            switch (random.Next(0, 2))
            {
                case 0:
                    return new InvulnerablePowerUp(content);
                case 1:
                    return new LifePowerUp(content);
                default:
                    return null;
            }

        }
    }
}
