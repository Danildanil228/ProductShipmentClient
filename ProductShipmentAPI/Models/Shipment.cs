namespace ProductShipmentAPI.Models
{
    public class Shipment
    {
        public int ShipmentId {  get; set; }
        public int ProductId { get; set; }  
        public string Store { get; set; } 
        public int BatchSize { get; set; }  
        public DateTime ShipmentDate { get; set; }  
        public decimal BatchCost { get; set; }  
    }

}
