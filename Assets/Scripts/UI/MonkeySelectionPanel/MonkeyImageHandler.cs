using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour, IDragHandler, IDropHandler, IPointerDownHandler
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private Vector2 originalAnchoredPos;
        private Vector3 originalRectPosition;

        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }

        public void OnDrag(PointerEventData eventData)
        {
            monkeyImage.rectTransform.anchoredPosition += eventData.delta;
            owner.MonkeyDraggedAt(monkeyImage.rectTransform.position);
        }

        public void OnDrop(PointerEventData eventData)
        {
            owner.MonkeyDroppedAt(eventData.position);
            ResetMonkey();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            monkeyImage.color = new Color(1, 1, 1, 0.5f);
        }

        private void ResetMonkey()
        {
            monkeyImage.rectTransform.anchoredPosition = originalAnchoredPos;
            monkeyImage.rectTransform.position = originalRectPosition;
            monkeyImage.color = new Color(1, 1, 1, 1);
            monkeyImage.GetComponent<LayoutElement>().enabled = false;
            monkeyImage.GetComponent<LayoutElement>().enabled = true;
        }

        private void Awake()
        {
            monkeyImage = GetComponent<Image>();
            monkeyImage.sprite = spriteToSet;
            originalAnchoredPos = monkeyImage.rectTransform.anchoredPosition;
            originalRectPosition = monkeyImage.rectTransform.position;
        }
    }
}