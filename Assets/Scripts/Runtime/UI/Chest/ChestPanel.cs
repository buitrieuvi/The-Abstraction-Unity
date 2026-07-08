using Abstraction.SharedModel;
using Cysharp.Threading.Tasks;
using ModestTree;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using Zenject;
using Zenject.SpaceFighter;

namespace Abstraction
{
    public class ChestPanel 
    {
        //[Inject] private GameDataManager _gameData;

        //[SerializeField] private ScrollRect _scroll_L; 
        //[SerializeField] private ScrollRect _scroll_R;
        //[SerializeField] private ChestSlot _slotPrefab;

        //private List<ChestSlot> _slotsL => _scroll_L.content.GetComponentsInChildren<ChestSlot>(true).ToList();
        //private List<ChestSlot> _slotsR => _scroll_R.content.GetComponentsInChildren<ChestSlot>(true).ToList();

        //public DTO_Chest ChestsData => Data as DTO_Chest;

        //public DTO_Inventory L => ChestsData.Items_L;
        //public DTO_Inventory R => ChestsData.Items_R;


        //public override void Start()
        //{
        //    base.Start();

        //    //btnClose?.Button.onClick.AddListener(() =>
        //    //{
        //    //    panelMg.OnInputAction<ChestPanel>().Forget();
        //    //});

        //    for (int i = 0; i < 24; i++)
        //    {
        //        var slot = Instantiate(_slotPrefab, _scroll_L.content);
        //        slot.ViewBase.ClickEvt += s => Selected(s);
        //    }

        //    for (int i = 0; i < 20; i++)
        //    {
        //        var slot = Instantiate(_slotPrefab, _scroll_R.content);
        //        slot.ViewBase.ClickEvt += s => Selected(s);
        //    }

        //}
        
        //public override void Open()
        //{
        //    Refesh();

        //    base.Open();
        //}

        //public override void Selected(SlotBase slot)
        //{
        //    ChestSlot chestSlot = slot as ChestSlot;

        //    if (_slotsL.Contains(chestSlot))
        //    {
        //        _gameData.PlayerData.Transfer(L, R, chestSlot.Item.Id);
        //        UpdateSlot(-1, R.Items.IndexOf(R.Items.FirstOrDefault(s => s.Id == chestSlot.Item.Id)));
        //    }
        //    else 
        //    {
        //        _gameData.PlayerData.Transfer(R, L, chestSlot.Item.Id);
        //        UpdateSlot(L.Items.IndexOf(L.Items.FirstOrDefault(s => s.Id == chestSlot.Item.Id)), -1);
        //    }
        //    chestSlot.Quantity.Value--;
        //}

        //public override void OnCloseCompleted()
        //{
        //    base.OnCloseCompleted();
        //}

        //public void Refesh() 
        //{
        //    foreach (var slot in _slotsL)
        //    {
        //        if (slot.Quantity.Value == 0)
        //        {
        //            break;
        //        }

        //        slot.Quantity.Value = 0;
        //        slot.Item = null;
        //    }

        //    foreach (var slot in _slotsR)
        //    {
        //        if (slot.Quantity.Value == 0)
        //        {
        //            break;
        //        }

        //        slot.Quantity.Value = 0;
        //        slot.Item = null;
        //    }

        //    for (int i = 0; i < L.Items.Count; i++)
        //    {
        //        _slotsL[i].Item = _gameData.ItemSOs.First(x => x.Id == L.Items[i].Id);
        //        _slotsL[i].Quantity.Value = L.Items[i].Quantity;
        //    }

        //    for (int i = 0; i < R.Items.Count; i++)
        //    {
        //        _slotsR[i].Item = _gameData.ItemSOs.First(x => x.Id == R.Items[i].Id);
        //        _slotsR[i].Quantity.Value = R.Items[i].Quantity;
        //    }
        //}

        //public void UpdateSlot(int indexL, int indexR)
        //{
        //    if (indexL >= 0)
        //    {
        //        _slotsL[indexL].Item = _gameData.ItemSOs.First(x => x.Id == L.Items[indexL].Id);
        //        _slotsL[indexL].Quantity.Value = L.Items[indexL].Quantity;
        //    }

        //    if (indexR >= 0) 
        //    {
        //        _slotsR[indexR].Item = _gameData.ItemSOs.First(x => x.Id == R.Items[indexR].Id);
        //        _slotsR[indexR].Quantity.Value = R.Items[indexR].Quantity;
        //    }
        //}
    }
}
