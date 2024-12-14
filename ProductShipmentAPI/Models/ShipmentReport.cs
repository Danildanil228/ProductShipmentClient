    namespace ProductShipmentAPI.Models
    {
        public class ShipmentReport
        {
            public string Name { get; set; }  // Название товара
            public string Store { get; set; }  // Номер магазина
            public DateTime ShipmentDate { get; set; }  // Дата отправления
            public int TotalBatchSize { get; set; }  // Общий размер партии
            public decimal TotalBatchCost { get; set; }  // Общая стоимость партии
            public decimal TotalWeight { get; set; }  // Общий вес партии 
        }

    }
