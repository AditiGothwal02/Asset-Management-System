namespace AssetManagementWebApi.DTO
{
    
    public class CreateSoftwareDto
    {
        public string Name { get; set; } = null!;
        public string? Version { get; set; }
        public string? LicenseKey { get; set; }
        public int? AssignedUserId { get; set; }
    }

    public class UpdateSoftwareDto
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public string? LicenseKey { get; set; }
        public int? AssignedUserId { get; set; }
    }

    public class SoftwareDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Version { get; set; }
        public string? LicenseKey { get; set; }
        public int? AssignedUserId { get; set; }
        public string? AssignedUsername { get; set; } 
    }
}
