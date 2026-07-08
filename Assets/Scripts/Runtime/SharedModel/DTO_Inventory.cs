using System.Collections.Generic;
using System;
using System.Linq;


namespace Abstraction.SharedModel
{
    public interface IInventory
    {
        void ChangeItemByIndex(int index, int quantity);
        void ChangeItemById(string id, int quantity);
    }

    [Serializable]
	public class DTO_Inventory : DTO_Base, IInventory
    {
        public string Id { get; set; } = string.Empty;

        public List<DTO_InventoryItem> Items { get; set; } = new();
        public List<IInventory> Interfaces { get; set; } = new();

        public DTO_Inventory()
        {

        }

        public void ChangeItemById(string id, int quantity)
        {
            int index = GetIndex(id);
            if (index != -1)
            {
                int newQuantity = Items[index].Quantity + quantity;
                if (newQuantity > 0)
                {
                    Items[index].Quantity += quantity;
                    Interfaces.ForEach(x => x.ChangeItemByIndex(index, quantity));
                }
                else
                {
                    if (newQuantity == 0) 
                    {
                        Items.RemoveAt(index);
                        Interfaces.ForEach(x => x.ChangeItemByIndex(index, 0));
                    }
                }
            }
            else
            {
                if (quantity > 0)
                {
                    Items.Add(new DTO_InventoryItem(id, quantity));
                    Interfaces.ForEach(x => x.ChangeItemByIndex(Items.Count - 1, quantity));
                }
            }
        }

        public void ChangeItemByIndex(int index, int quantity)
        {
            if (index >= 0 && index < Items.Count)
            {
                int newQuantity = Items[index].Quantity + quantity;
                if (newQuantity > 0)
                {
                    Items[index].Quantity += quantity;
                    Interfaces.ForEach(x => x.ChangeItemByIndex(index, quantity));
                }
                else
                {
                    if (newQuantity == 0) 
                    {
                        Items.RemoveAt(index);
                        Interfaces.ForEach(x => x.ChangeItemByIndex(index, 0));
                    }
                }
            }
        }

        int GetIndex(string id)
        {
            return Items.FindIndex(x => x.Id == id);    
        }
    }
}