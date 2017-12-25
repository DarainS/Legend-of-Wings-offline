using common.config;

using model.character;

using MapCard;

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
            if(!Config.isGameStarted) {
                newGameDungeon();
            }
        }

    }

}