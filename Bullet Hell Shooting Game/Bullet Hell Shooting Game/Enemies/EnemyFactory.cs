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
            return new Entity(this.content, settings[type]);
        }
    }
}
