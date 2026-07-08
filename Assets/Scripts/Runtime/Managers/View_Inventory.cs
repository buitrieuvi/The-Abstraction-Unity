using Abstraction.SharedModel;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Abstraction
{
    public class View_Inventory : ViewBase, IInventory
    {
        [Inject] private DiContainer _container;

        [SerializeField] View_InventoryItem _inventoryItemPrefab;
        [SerializeField] ViewBase _closeUI;
        [SerializeField] ScrollRect _scroll;

        List<View_InventoryItem> _listInventoryItem = new();

        DTO_Inventory _inventoryData = new();

        public override void Awake()
        {
            base.Awake();

            for (int i = 0; i < 9 * 4; i++)
            {
                var ins = _container
                    .InstantiatePrefabForComponent<View_InventoryItem>(_inventoryItemPrefab, _scroll.content.transform);
                _listInventoryItem.Add(ins);
            }

        }

        public void Start()
        {

            if (_closeUI != null)
            {
                _closeUI.ClickEvt += (e) =>
                {
                    uiManager.OnUI<View_Inventory>().Forget();
                };
            }
        }

        public override void Open(DTO_Base data)
        {
            _inventoryData = data as DTO_Inventory;
            _inventoryData.Interfaces.Add(this);
            for (int i = 0; i < _inventoryData.Items.Count; i++)
            {
                _listInventoryItem[i].ItemData.Id = _inventoryData.Items[i].Id;
                _listInventoryItem[i].ItemData.Quantity = _inventoryData.Items[i].Quantity;
            }

            OnCompleted();
        }

        public override void Close()
        {
            inputManager.IsCurrsor(false);

            base.Close();
            _inventoryData.Interfaces.Remove(this);
            cvGroup.blocksRaycasts = false;
            cvGroup.interactable = false;

            OnCloseCompleted();

        }

        public override async void OnCompleted()
        {
            Sequence sequence = DOTween.Sequence();
            _listInventoryItem.ForEach(x => {
                sequence.Join(x.Ani_1());
            });

            await sequence.Play().OnComplete(() => 
            {
                cvGroup.blocksRaycasts = true;
                cvGroup.interactable = true;
                base.OnCompleted();
            });

            inputManager.IsCurrsor(true);

            
        }

        public override void OnCloseCompleted()
        {
            base.OnCloseCompleted();

            Destroy(gameObject);
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

        public void ChangeItemByIndex(int index, int quantity)
        {
            if (quantity == 0)
            {
                _listInventoryItem[index].ItemData.Id = "";
                _listInventoryItem[index].ItemData.Quantity = 0;
                _listInventoryItem[index].transform.SetAsLastSibling();
            }
            else
            {
                _listInventoryItem[index].ItemData.Quantity = quantity;
            }

        }

        public void ChangeItemById(string id, int quantity)
        {

        }
    }
}