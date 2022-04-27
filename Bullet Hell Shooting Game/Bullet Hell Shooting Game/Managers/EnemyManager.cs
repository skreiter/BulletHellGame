using System;
using System.Collections.Generic;
using System.Text;
using Bullet_Hell_Shooting_Game.Movements;
using Bullet_Hell_Shooting_Game.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.IO;
using System.Text.Json;
using Bullet_Hell_Shooting_Game.Content.Engine;

namespace Bullet_Hell_Shooting_Game.Enemies
{
    public class EnemyManager
    {
        private StageInterpreter stageInterpreter;
        private EnemyInterpreter enemyInterpreter;
        private EnemyFactory enemyFactory;
        private ContentManager contentManager;
        private List<Entity> enemies;
        private List<Dictionary<string, string>> loadedWaves;
        private string folderPath;
        private string currentFile;
        private int currentStage;
        private int stageStartTime;
        private bool finished = false;
        private double prevUpdate = 0;

        public EnemyManager(ContentManager Content, List<Entity> enemyList)
        {
            contentManager = Content;
            enemies = enemyList;
            enemyFactory = new EnemyFactory(Content);
            loadedWaves = new List<Dictionary<string, string>>();

            folderPath = "../../../Content/Engine/";
            currentFile = "Stage1.json";
            string data = File.ReadAllText(folderPath + currentFile);
            stageInterpreter = JsonSerializer.Deserialize<StageInterpreter>(data);
            data = File.ReadAllText(folderPath + "Enemies.json");
            enemyInterpreter = JsonSerializer.Deserialize<EnemyInterpreter>(data);

            currentStage = 1;
            stageStartTime = 0;
        }

        public void Update(double time)
        {
            UpdateEnemy(time);
            if (finished)
                return;
            foreach (KeyValuePair<string, Dictionary<string, string>> wave in stageInterpreter.stage)
            {
                if (Int32.Parse(stageInterpreter.stage[wave.Key]["time"]) + stageStartTime < (int)time + 1)
                {
                    loadedWaves.Add(stageInterpreter.stage[wave.Key]);
                    stageInterpreter.stage.Remove(wave.Key);
                }
            }

            if (stageInterpreter.stage.Count == 0 && loadedWaves.Count == 0)
                LoadStage(time);

            Spawn(time);
        }

        private void UpdateEnemy(double time)
        {
            foreach (Entity enemy in enemies)
            {
                enemy.Update(time - prevUpdate);
            }
            prevUpdate = time;
        }

        private void Spawn(double time)
        {
            for (int i = 0; i < loadedWaves.Count; i++)
            {
                // If current time is greater than previous spawn time + interval
                if (Int32.Parse(loadedWaves[i]["time"]) + stageStartTime + Int32.Parse(loadedWaves[i]["interval"]) < (int)time + 1)
                {
                    // Set time to the previous time something was spawned
                    loadedWaves[i]["time"] = (Int32.Parse(loadedWaves[i]["time"]) + Int32.Parse(loadedWaves[i]["interval"])).ToString();

                    CreateEntitySettings(loadedWaves[i]);
                    enemies.Add(enemyFactory.SpawnEnemy(loadedWaves[i]["enemyType"], enemyInterpreter.enemies));

                    loadedWaves[i]["enemyAmount"] = (Int32.Parse(loadedWaves[i]["enemyAmount"]) - 1).ToString();
                    if (loadedWaves[i]["enemyAmount"] == "0")
                    {
                        loadedWaves.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        private void CreateEntitySettings(Dictionary<string, string> wave)
        {
            enemyInterpreter.enemies[wave["enemyType"]]["ProjectileType"] = wave["projectileType"];
            enemyInterpreter.enemies[wave["enemyType"]]["PatternType"] = wave["projectilePattern"];
            enemyInterpreter.enemies[wave["enemyType"]]["positionX"] = wave["positionX"];
            enemyInterpreter.enemies[wave["enemyType"]]["positionY"] = wave["positionY"];
        }


        private void IncreaseStageCount()
        {
            currentStage++;
            currentFile = "Stage" + currentStage + ".json";
        }

        private void LoadStage(double time)
        {
            IncreaseStageCount();
            string data;
            try
            {
                data = File.ReadAllText(folderPath + currentFile);
            }
            catch
            {
                finished = true;
                return;
            }

            stageStartTime = (int)time + 1;
            stageInterpreter = JsonSerializer.Deserialize<StageInterpreter>(data);
        }

        public void Reset()
        {
            currentStage = 1;
            enemies.Clear();
            currentFile = "Stage1.json";
            stageStartTime = 0;
            string data = File.ReadAllText(folderPath + currentFile);
            stageInterpreter = JsonSerializer.Deserialize<StageInterpreter>(data);
            finished = false;
        }
    }
}

