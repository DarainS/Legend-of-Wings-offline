using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.Experimental.UIElements;


namespace Manager
{
    public class HandsArea : BaseCardAreaManager
    {
        public BattleManager battleManager;

        public RectTransform rectTransform;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private int size = -2;

        public override void AddCard(UCard uCard)
        {
            uCard.transform.parent = transform;
            size++;
            uCard.rectTransform.position = rectTransform.position + new Vector3(170 * size, 0);
        }

        public override void RemoveCard(UCard card)
        {
            card.gameObject.SetActive(false);
            cards.Remove(card);
        }
    }
}