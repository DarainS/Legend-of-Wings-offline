using System.Collections.Generic;


namespace model.character {

    public enum CharacterEventType {

        BeforeDamage,
        AfterDamage

    }

    public class CharacterEvent {

        public static void EventList() {
            var list = new List<CharacterEventType> {
                CharacterEventType.AfterDamage,
                CharacterEventType.BeforeDamage
            };
        }

    }

}