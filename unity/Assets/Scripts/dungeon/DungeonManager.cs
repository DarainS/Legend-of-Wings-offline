using common.config;

using dungeon.mapcard;

using model.character;

using UnityEngine;
using UnityEngine.SceneManagement;


namespace dungeon {

    public class DungeonManager : MonoBehaviour {

        public CardArea CardArea;

        public Hero Hero;

        private void newGameDungeon() {
        }

        public void GenerateBattle(Hero hero, Monster monster) {
            Config.Hero = hero;
            Config.Monster = monster;
            SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
        }

        private void Start() {
            Hero = Config.Hero;
            Config.DungeonManager = this;
            if(!Config.IsGameStarted) {
                newGameDungeon();
            }
        }

    }

}