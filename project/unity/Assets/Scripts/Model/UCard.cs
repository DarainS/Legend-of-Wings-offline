using System;

using Manager;

using Model.card;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Model {

    public class UCard : MonoBehaviour, IComparable<UCard> {

        public Text cardName;

        public Text cardSimpleDesc;

        public BattleManager battleManager;

        public CardStatus status;

        public Character character;

        public Text CurrenCooldownText;
        
        public CardType CardType;

        public CardProperty CardProperty;

        public delegate void PlayEffect_(BattleManager manager, Character player);

        public delegate bool CouldCharacterUse_(BattleManager manager, Character c);

        public CouldCharacterUse_ CouldCharacterUse;

        public PlayEffect_ PlayEffect;

        public RectTransform rectTransform;

        public int MaxCooldownTime { get; set; }

        public int FirstCooldown { get; set; }

        private int _currentCooldown;

        public int CurrentCooldown {
            get { return _currentCooldown; }
            set {
                _currentCooldown = value;
                if(value == 0) {
                    CurrenCooldownText.text = "";
                }
                else {
                    CurrenCooldownText.text = "" + value;
                }
            }
        }

        private string _name;

        public string Name {
            get { return _name; }
            set {
                name = value;
                _name = name;
            }
        }

        public string SimgleDesc { get; set; }


        public Card Card {
            set {
                Name = value.Name;
                SimgleDesc = value.SimgleDesc;
                cardName.text = Name;
                cardSimpleDesc.text = SimgleDesc;
                MaxCooldownTime = value.CooldownTime;
                CurrentCooldown = value.FirstCooldown;
                value.uCard = this;
                CardType = value.CardType;
                CardProperty = value.CardProperty;

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

        private void Awake() {
            if(CurrentCooldown == 0) {
                CurrenCooldownText.text = "";
                return;
            }
            CurrenCooldownText.text = "" + CurrentCooldown;
        }

        private void Start() {
            initEventListenser();
            rectTransform = GetComponent<RectTransform>();
        }

        public void AfterPlayEffect(BattleManager manager, Character player) {
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
            isUpper = false;
        }

        private readonly Vector3 _positionUpper = new Vector3(0, 50);

        private bool isUpper = false;

        private void OnMouseEnter(BaseEventData pointData) {
            if(character.CouldUseCard(this)) {
                rectTransform.position += _positionUpper;
                isUpper = true;
            }
        }

        private void OnMouseExit(BaseEventData pointData) {
            if(isUpper) {
                rectTransform.position -= _positionUpper;
                isUpper = false;
            }
        }

        public int CompareTo(UCard other) {
            if(CurrentCooldown > other.CurrentCooldown) {
                return -1;
            }

            if(CurrentCooldown < other.CurrentCooldown) {
                return 1;
            }
            
            return 0;
        }

    }

}