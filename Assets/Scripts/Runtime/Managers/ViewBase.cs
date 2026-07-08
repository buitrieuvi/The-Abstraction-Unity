using Abstraction.SharedModel;
using Assets.Scripts.Runtime.Interface;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Abstraction
{
    public abstract class ViewBase : MonoBehaviour,
        IView,
        IPointerClickHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        protected CanvasGroup cvGroup => GetComponent<CanvasGroup>();
        protected Button btn => GetComponent<Button>();

        protected float openAnimationDuration = 0.4f;
        protected float closeAnimationDuration = 0.3f;

        public event UnityAction<ViewBase> ClickEvt;
        public event UnityAction<ViewBase> HoverEvt;
        public event UnityAction<ViewBase> UnHoverEvt;

        [Inject] protected GameDataManager gameData;
        [Inject] protected UIManager uiManager;
        [Inject] protected InputManager inputManager;

        protected bool inited;
        protected DTO_Base data;

        public virtual void Awake()
        {
            btn?.onClick.AddListener(() => PointerClick());
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (btn != null) 
            {
                return;
            }

            PointerClick();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEnter();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExit();
        }

        public virtual void PointerClick() 
        {
            ClickEvt?.Invoke(this);
        }
        public virtual void PointerEnter() 
        {
            HoverEvt?.Invoke(this);
        }
        public virtual void PointerExit() 
        {
            UnHoverEvt?.Invoke(this);
        }

        public virtual void Open(DTO_Base data) 
        {
           
        }
        public virtual void Close() 
        {

        }

        public virtual void OnCompleted() 
        {

        }
        public virtual void OnCloseCompleted() 
        {

        }
    }
}