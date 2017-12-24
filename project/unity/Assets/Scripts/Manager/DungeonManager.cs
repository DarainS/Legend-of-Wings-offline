using Common;

using MapCard;

using Model;
using Model.character;

using UnityEngine;
using UnityEngine.SceneManagement;


namespace Manager {

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