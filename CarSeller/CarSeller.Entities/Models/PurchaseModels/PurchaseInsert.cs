namespace CarSeller.Entities.Models.PurchaseModels
{
    /// <summary>
    ///     The purchase insert.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class PurchaseInsert
    {
        /// <summary>
        ///     The user Id.
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        ///     The car Id.
        /// </summary>
        public int CarId { get; set; }

        public int SellerId { get; set; } = int.MinValue;
    }
}