namespace MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos
{
    public class UpdateCargoOperationDto
    {
        public int CargoOperationID { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
