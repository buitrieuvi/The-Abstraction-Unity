using Abstraction.SharedModel;
using Assets.Scripts.Runtime.Interface;
using DG.Tweening;
using NUnit.Framework.Interfaces;
using System;
using TMPro;
using UniRx;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Abstraction
{
    public class View_InventoryItem : ViewBase  
    {
        [SerializeField] Image _image;
        [SerializeField] Image _rank;
        [SerializeField] TMP_Text _quantity;
        [SerializeField] Transform _dataView;

        [SerializeField] RectTransform view;

        public DTO_InventoryItem ItemData = new();

        public override void Awake()
        {
            base.Awake();

            ItemData
                .ObserveEveryValueChanged(x => x.Quantity)
                .Subscribe(_ => OnChangedItem())
                .AddTo(this);

            ItemData
                .ObserveEveryValueChanged(x => x.Id)
                .Subscribe(_ => OnChangedItem())
                .AddTo(this);
        }

        public void OnChangedItem()
        {
            if (ItemData.Quantity == 0)
            {
                _dataView.gameObject.SetActive(false);
                _quantity.text = "Trống";
            }
            else
            {
                
                ItemSO itemSO = gameData.ItemSOs.Find(x => x.Id == ItemData.Id);

                _dataView.gameObject.SetActive(true);
                _image.sprite = itemSO.Sprite;
                _rank.color = itemSO.Rank.Color;
                _quantity.text = ItemData.Quantity.ToString();
            }
        }

        public Tweener Ani_1() 
        {
            view?.DOKill();
            return view.DOScale(1f, 0.35f).From(0).SetDelay(transform.GetSiblingIndex() * 0.0005f);
        }

        public override void PointerEnter()
        {
            base.PointerEnter();

            if (ItemData.Quantity != 0)
            view.DOScale(1.1f, 0.2f).SetAutoKill(false).OnKill(() =>
            {
                view.DOScale(1f, 0.2f);
            });
        }

        public override void PointerExit()
        {
            base.PointerExit();

            view?.DOKill();
        }
    }
}