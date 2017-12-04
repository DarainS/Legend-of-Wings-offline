using System;

using JetBrains.Annotations;

using Manager;

using Model.card;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Model {

    public class UCard : MonoBehaviour {

        public Text cardName;

        public Text cardSimpleDesc;

        public BattleManager battleManager;

        public CardStatus status;

        public Character character;

        public delegate void PlayEffect_(Character player = null, Character target = null);

        public delegate bool CouldCharacterUse_(Character c);

        public CouldCharacterUse_ CouldCharacterUse;

        public PlayEffect_ PlayEffect;

        public RectTransform rectTransform;

        public int CooldownTime { get; set; }

        public int currentCooldown;

        public int CurrentCooldown {
            get { return currentCooldown; }
            set { currentCooldown = value; }
        }

        protected string _name;

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public string SimgleDesc {
            get { return simgleDesc; }
            set { simgleDesc = value; }
        }

        protected string simgleDesc;

        public Card Card {
            set {
                Name = value.Name;
                SimgleDesc = value.SimgleDesc;
                cardName.text = Name;
                cardSimpleDesc.text = SimgleDesc;
                CooldownTime = value.CooldownTime();
                CurrentCooldown = CooldownTime;
                
                PlayEffect = value.PlayEffect;
                PlayEffect += AfterPlayEffect;
                
                CouldCharacterUse = value.CouldCharacterUse;
            }
        }

        public string SimpleDesc {
            get { return cardSimpleDesc.text; }
            set {
                cardSimpleDesc.text = value;
                SimgleDesc = value;
            }
        }

        private void Start() {
            initEventListenser();
            rectTransform = GetComponent<RectTransform>();
        }

        public void AfterPlayEffect(Character player = null, Character target = null) {
            MoveCard(CardStatus.InHands, CardStatus.InYield);
        }

        public void MoveCard(CardStatus from, CardStatus to) {
            battleManager.MoveCard(this, from, to);
        }

        private void initEventListenser() {
            var btn = GetComponent<Button>();

            var trigger = btn.GetComponent<EventTrigger>();

            var entry = new EventTrigger.Entry {
                eventID = EventTriggerType.PointerClick,
                callback = new EventTrigger.TriggerEvent()
            };
            entry.callback.AddListener(OnClick);
            trigger.triggers.Add(entry);

            var entry2 = new EventTrigger.Entry {
                eventID = EventTriggerType.PointerEnter,
                callback = new EventTrigger.TriggerEvent()
            };
            entry2.callback.AddListener(OnMouseEnter);
            trigger.triggers.Add(entry2);

            var entry3 = new EventTrigger.Entry {
                eventID = EventTriggerType.PointerExit,
                callback = new EventTrigger.TriggerEvent()
            };
            entry3.callback.AddListener(OnMouseExit);
            trigger.triggers.Add(entry3);
        }

        private void OnClick(BaseEventData pointData) {
            Debug.Log("Button click. EventTrigger..");
            if(character.CouldUseCard(this)) {
                character.PlayEffect(this);
            }
        }

        private readonly Vector3 _positionUpper = new Vector3(0, 50);

        private bool isUpper = false;

        private void OnMouseEnter(BaseEventData pointData) {
            if(character.CouldUseCard(this)) {
                transform.position += _positionUpper;
                isUpper = true;
            }
        }

        private void OnMouseExit(BaseEventData pointData) {
            if(isUpper) {
                transform.position -= _positionUpper;
                isUpper = false;
            }
        }

    }

}