namespace Poultry.Domain.Entities
{
    public class FoodService : BaseEntity
    {
        public FoodType FoodType { get; set; }
        public int Amount { get; set; }

    }

    #region FoodTypeEnum
    public enum FoodType : byte
    {
        wheat=0,
        corn,
        soy,
        barley
    }

    #endregion
}
