namespace AssetManagementWebApi.DTO
{
    public class CreateBookDto
    {
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateOnly? PurchaseDate { get; set; }
        public int? AssignedUserId { get; set; }
    }

    public class UpdateBookDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public DateOnly? PurchaseDate { get; set; }
        public int? AssignedUserId { get; set; }
    }

    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateOnly? PurchaseDate { get; set; }
        public int? AssignedUserId { get; set; }
        public string? AssignedUsername { get; set; }
    }
}
    


