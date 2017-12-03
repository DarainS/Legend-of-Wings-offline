using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Model {

    public class UCard : MonoBehaviour {

        public Text cardName;
        
        public Text cardSimpleDesc;
           
                private Card _card;


        public Card Card {
            get { return _card; }
            set {
                _card = value;
                cardName.text = _card.Name;
                cardSimpleDesc.text = _card.SimgleDesc;
            }
        }

        public string Name {
            get { return _card.Name; }
            set {
                _card.Name = value;
                cardName.text = value;
            }
        }
        
        public string SimpleDesc {
            get { return cardSimpleDesc.text; }
            set {
                cardSimpleDesc.text = value;
                _card.SimgleDesc = value;
            }
        }


        private void Start() {
            
            initEventListenser();
            
        }

        private void initEventListenser() {
            
            var btn = GetComponent<Button>();
            
            var trigger = btn.GetComponent<EventTrigger> ();
            
            var entry = new EventTrigger.Entry {
                eventID = EventTriggerType.PointerClick,
                callback = new EventTrigger.TriggerEvent()
            };
            entry.callback.AddListener (OnClick);
            trigger.triggers.Add (entry);

            var entry2 = new EventTrigger.Entry {
                eventID = EventTriggerType.PointerEnter,
                callback = new EventTrigger.TriggerEvent()
            };
            entry2.callback.AddListener (OnMouseEnter);
            trigger.triggers.Add (entry2);
            
            var entry3 = new EventTrigger.Entry {
                eventID = EventTriggerType.PointerExit,
                callback = new EventTrigger.TriggerEvent()
            };
            entry3.callback.AddListener (OnMouseExit);
            trigger.triggers.Add (entry3);
        }
        
        private void OnClick(BaseEventData pointData){
            Debug.Log ("Button click. EventTrigger..");
            _card.playEffect();
            
        }
 
        private readonly Vector3 _positionUpper=new Vector3(0,100);
        
        private void OnMouseEnter(BaseEventData pointData) {
            transform.position += _positionUpper;
        }

        private void OnMouseExit(BaseEventData pointData) {
            transform.position -= _positionUpper;
        }

    }

}