using Common;

using MapCard;

using UnityEngine;


namespace Manager {

    public class DungeonManager : MonoBehaviour {

        public CardArea CardArea;
        
        private void newGameDungeon() {
            
        }


        private void Start() {
            if(!Config.isGameStarted) {
                newGameDungeon();
            }
        }

    }

}