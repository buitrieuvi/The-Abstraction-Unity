using Abstraction.SharedModel;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Abstraction 
{
    public class View_Menu : ViewBase
    {
        [SerializeField] private ScrollRect _menu_C;
        [SerializeField] private GameObject _menu_L;

        private List<Button_01> _categorys;
        private List<Button_01> _menuSlots_C;

        [SerializeField] private DropdownUI _dropdownFPS;

        [SerializeField] private SliderUI _sliderCameraX;
        [SerializeField] private SliderUI _sliderCameraY;

        private Select _catSelected = new();

        public override void Awake()
        {
            base.Awake();
            _categorys = _menu_L.GetComponentsInChildren<Button_01>().ToList();

            foreach (var item in _categorys)
            {
                item.ClickEvt += (e) =>
                {
                    _catSelected.OnChanged(item);
                };

                item.HoverEvt += (e) =>
                {
                    _catSelected.OnHover(item);
                };

                item.UnHoverEvt += (e) =>
                {
                    _catSelected.OnUnHover();
                };
            }

            //_menuSlots_C = _menu_C.content.GetComponentsInChildren<Button_01>().ToList();

            //_dropdownFPS.Dic.Add("Không giới hạn", () => Application.targetFrameRate =-1);
            //_dropdownFPS.Dic.Add("300 FPS", () => Application.targetFrameRate = 300);
            //_dropdownFPS.Dic.Add("200 FPS", () => Application.targetFrameRate = 200);
            //_dropdownFPS.Dic.Add("100 FPS", () => Application.targetFrameRate = 100);
            //_dropdownFPS.Dic.Add("60 FPS", () => Application.targetFrameRate = 60);
            //_dropdownFPS.Dic.Add("30 FPS", () => Application.targetFrameRate = 30);

            //_dropdownFPS.AddDropdown();

            //base.Awake();
        }

        public void Start()
        {


            //_categorys.ForEach(slot =>
            //{
            //    slot.ClickEvt += evt =>
            //    {
            //        _menuSlots_C.ForEach(a => a.gameObject.SetActive(false));
            //        var mainList = _menuSlots_C.Where(b => b.tag == slot.tag).ToList();
            //        mainList.ForEach(a => a.gameObject.SetActive(true));
            //    };
            //});

            //_menuSlots_C.ForEach(x => { x.gameObject.SetActive(false);});
            //_categorys[0].ViewBase.PointerClick();

            //btnClose?.Button.onClick.AddListener(() =>
            //{
            //    panelMg.OnInputAction<View_Menu>().Forget();
            //});

            //// Set

            //_sliderCameraX.SetValue(15);
            //_sliderCameraY.SetValue(15);

            //cameraMg.SetOrbitX(_sliderCameraX.GetValue);
            //cameraMg.SetOrbitY(_sliderCameraY.GetValue);

            //cameraMg.SetPan(_sliderCameraX.GetValue);
            //cameraMg.SetTilt(_sliderCameraY.GetValue);

            //_sliderCameraX.OnSliderValueChanged += () =>
            //{
            //    cameraMg.SetOrbitX(_sliderCameraX.GetValue);
            //    cameraMg.SetPan(_sliderCameraX.GetValue);
            //};

            //_sliderCameraY.OnSliderValueChanged += () =>
            //{
            //    cameraMg.SetOrbitY(_sliderCameraY.GetValue);
            //    cameraMg.SetTilt(_sliderCameraY.GetValue);
            //};
        }

        public override void Open(DTO_Base data)
        {
            base.Open(data);

            if (!inited) { inited = true; }
            else { gameObject.SetActive(true); }

            OnCompleted();
        }

        public override void Close()
        {
            inputManager.IsCurrsor(false);
            base.Close();


            OnCloseCompleted();
        }

        //public override void CloseImmediately()
        //{
        //    base.CloseImmediately();
        //}

        public override void OnCompleted()
        {
            Sequence sequence = DOTween.Sequence();

            foreach (var slot in _categorys)
            {
                sequence.Join(slot.View.Transform(0.35f, 0.05f));
            }

            sequence.SetDelay(0.25f);
            sequence.OnComplete(() => base.OnCompleted());
            sequence.Play();

            inputManager.IsCurrsor(true);
        }

        public override void OnCloseCompleted()
        {
            base.OnCloseCompleted();
            gameObject.SetActive(false);
        }

    }
}