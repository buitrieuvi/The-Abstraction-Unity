using Abstraction.SharedModel;
using Assets.Scripts.Runtime.Interface;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Abstraction
{

    public class Button_01 : ViewBase,
        ISelect
    {
        [SerializeField] Image bg;
        [SerializeField] TMP_Text text;

        public RectTransform View;

        public override void Awake()
        {
            base.Awake();
        }

        public void Start()
        {
            
        }

        public override void Open(DTO_Base data)
        {
            base.Open(data);
        }

        public override void OnCompleted()
        {
            base.OnCompleted();
        }


        public override void PointerClick()
        {
            base.PointerClick();
        }

        public override void PointerEnter()
        {
            base.PointerEnter();
        }

        public override void PointerExit()
        {
            base.PointerExit();
        }

        public void Selected()
        {
            DoTweenExtensions.Selected(bg, text, Color.white, Color.black);
        }

        public void DeSelected()
        {
            DoTweenExtensions.DeSelected(bg, text, Color.white, Color.black);
        }

        public void Hover()
        {
            View.Hover();
        }

        public void UnHover()
        {
            View.UnHover();
        }
    }
}