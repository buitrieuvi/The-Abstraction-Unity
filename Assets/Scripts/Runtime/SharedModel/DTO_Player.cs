namespace Abstraction.SharedModel
{
    public class DTO_Player: DTO_Base
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        public DTO_Inventory Inventory { get; set; } = new DTO_Inventory();
    }
}