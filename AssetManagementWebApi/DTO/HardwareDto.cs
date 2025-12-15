namespace AssetManagementWebApi.DTO
{
    
    public class CreateHardwareDto
    {
        public string Name { get; set; } = null!;

        public string Model { get; set; } = null!;

        public DateOnly? PurchaseDate { get; set; }
        public int? AssignedUserId { get; set; }
    }

    
    public class UpdateHardwareDto
    {
        public string? Name { get; set; }

        public string Model { get; set; } = null!;
        public DateOnly? PurchaseDate { get; set; }
        public int? AssignedUserId { get; set; }
    }

    
    public class HardwareDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Model { get; set; } = null!;
        public DateOnly? PurchaseDate { get; set; }
        public int? AssignedUserId { get; set; }
        public string? AssignedUsername { get; set; }
    }
}
