using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Bullet_Hell_Shooting_Game.Menus
{
    internal class MainMenu
    {
        private SpriteFont font;
        private Input input = new Input();
        private bool option = true;
        private bool delay = false;
        private int delayValue = 500;

        public MainMenu(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("Time");
        }

        public bool Update(GameTime gameTime)
        {


            if (input.GetMoveInput().Y != 0 && !delay)
            {

                Timer timer = new Timer(delayValue);
                timer.Elapsed += setDelay;
                delay = true;
                timer.Start();
                option = !option;
            }
            if (input.GetShotInput() && !delay)
            {
                if (!option)
                {
                    Environment.Exit(0);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(font, "Bullet Hell Game", new Vector2(170, 100), Color.White, 0, Vector2.One, 3, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, "Start", new Vector2(300, 200), option ? Color.Red : Color.White, 0, Vector2.One, 2, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, "Quit", new Vector2(305, 300), option ? Color.White : Color.Red, 0, Vector2.One, 2, SpriteEffects.None, 1);
        }

        private void setDelay(object sender, ElapsedEventArgs e)
        {
            this.delay = false;
        }
    }
}
