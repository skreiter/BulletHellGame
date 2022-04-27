using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Bullet_Hell_Shooting_Game.Enemies;
using System.Timers;


namespace Bullet_Hell_Shooting_Game
{
    public class Player : Entity
    {
        private int lives;
        private int startLives;
        private Texture2D healthTexture;
        private Rectangle healthRectangle = new Rectangle(530,10,160,25);
        private Rectangle innerHealthRectangle;
        private Input input;

        public Rectangle InnerHealthRectangle { get => innerHealthRectangle; }
        public Rectangle HealthRectangle { get => healthRectangle; }
        public Texture2D HealthTexture { get => healthTexture; }
        public int Lives { get => lives; }

        public Player(Dictionary<string, string> settings, ContentManager content) : base(content, settings)
        {
            startLives = int.Parse(settings["Lives"]);
            input = new Input();
            lives = startLives;
            healthTexture = content.Load<Texture2D>(settings["HealthTexture"]);
            innerHealthRectangle = new Rectangle(healthRectangle.X, healthRectangle.Y, healthRectangle.Width, healthRectangle.Height);
        }
        public void AddLives(int num)
        {
            lives += num;
        }
        public void MakeInvulnerable()
        {
            invulnerable = true;
            Timer invulTimer = new Timer(5000);
            invulTimer.Elapsed += setInvulnerable;
            invulTimer.Start();
        }
        public bool IsGameOver()
        {
            return lives < 0;
        }
        public new void DealDamage(int damage)
        {
            if (this.invulnerable)
                return;
            this.health -= damage;
            updateHealth();
        }
        public void Reset()
        {
            lives = startLives;
            health = maxHP;
            ResetPosition();
            updateHealth();
            prevShotTime = 0;
        }
        public new bool ShootCheck(double gametime)
        {
            if (input.GetShotInput() && prevShotTime + .2 < gametime)
            {
                prevShotTime = gametime;
                return true;
            }
            return false;
        }
        public void Die()
        {
            lives--;
            health = maxHP;
            this.invulnerable = true;
            ResetPosition();
            updateHealth();
            Timer invulTimer = new Timer(1000);
            invulTimer.Elapsed += setInvulnerable;
            invulTimer.Start();
        }
        private void updateHealth()
        {
            float percentage = (float)(this.health) / this.maxHP;
            innerHealthRectangle.Width = (int)(percentage * (healthRectangle.Width));
        }
        private void setInvulnerable(object sender, ElapsedEventArgs e)
        {
            this.invulnerable = false;
        }
        
    }
}
