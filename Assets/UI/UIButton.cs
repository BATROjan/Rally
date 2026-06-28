using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class UIButton : MonoBehaviour, IPointerClickHandler
    {
        public Action OnClick;
        public Action<int> OnSelect;

        [SerializeField] private Text buttonText;
        [SerializeField] private int playerCount;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnSelect?.Invoke(playerCount);
            OnClick?.Invoke();
        }
    }
}