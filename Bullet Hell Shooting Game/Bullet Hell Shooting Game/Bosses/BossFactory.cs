using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Bosses
{
    class BossFactory
    {
        private ContentManager content;

        public BossFactory(ContentManager content)
        {
            this.content = content;
        }

        public Boss SpawnEnemy(string type)
        {
            switch (type)
            {

                case "MidBoss":
                    return new MidBoss(this.content);
                case "FinalBoss":
                    return new FinalBoss(this.content);

                default:
                    return null;
            }
        }
    }
}

