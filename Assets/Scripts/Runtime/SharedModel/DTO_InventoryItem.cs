
using System;

namespace Abstraction.SharedModel 
{
    [Serializable]
    public class DTO_InventoryItem : DTO_Base
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
            
        public DTO_InventoryItem() 
        {
            Id = string.Empty;
            Quantity = 0;
        }

        public DTO_InventoryItem(string id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public DTO_InventoryItem(DTO_InventoryItem newItem)
        {
            Id = newItem.Id;
            Quantity = newItem.Quantity;
        }
    }

}