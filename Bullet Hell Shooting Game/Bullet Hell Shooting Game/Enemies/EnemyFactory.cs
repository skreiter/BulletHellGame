using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bullet_Hell_Shooting_Game.Enemies
{
    class EnemyFactory
    {
        private ContentManager content;

        public EnemyFactory(ContentManager content)
        {
            this.content = content;
        }

        public Entity SpawnEnemy(string type, Dictionary<string, Dictionary<string, string>> settings)
        {
            switch (type)
            {
                case "GruntA":
                case "gruntA":
                    return new Grunt(this.content, settings[type]);
                case "GruntB":
                    return new GruntB(this.content, settings[type]);
                case "MidBoss":
                    return new MidBoss(this.content, settings[type]);
                case "FinalBoss":
                    return new FinalBoss(this.content, settings[type]);

                default:
                    return null;
            }
        }
    }
}
