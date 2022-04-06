using System;
using System.Collections.Generic;
using System.Text;
using Bullet_Hell_Shooting_Game.Movements;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bullet_Hell_Shooting_Game.Enemies
{
    public  class FinalBoss : Entity
    {
        public FinalBoss(ContentManager content, Dictionary<string, string> entitySettings) : base(content, entitySettings)
        {
        }
        public override void Die()
        {
            //play death animation
        }
    }
}

