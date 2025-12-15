using AssetManagementWebApi.DTO;

namespace AssetManagementWebApi.Services.Interfaces
{
    public interface IAssetService
    {
        
        Task<BookDto> CreateBookAsync(CreateBookDto dto);
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<BookDto> UpdateBookAsync(int id, UpdateBookDto dto);
        Task DeleteBookAsync(int id);

       
        Task<SoftwareDto> CreateSoftwareAsync(CreateSoftwareDto dto);
        Task<IEnumerable<SoftwareDto>> GetSoftwareAsync();
        Task<SoftwareDto?> GetSoftwareByIdAsync(int id);
        Task<SoftwareDto> UpdateSoftwareAsync(int id, UpdateSoftwareDto dto);
        Task DeleteSoftwareAsync(int id);

      
        Task<HardwareDto> CreateHardwareAsync(CreateHardwareDto dto);
        Task<IEnumerable<HardwareDto>> GetHardwareAsync();
        Task<HardwareDto?> GetHardwareByIdAsync(int id);
        Task<HardwareDto> UpdateHardwareAsync(int id, UpdateHardwareDto dto);
        Task DeleteHardwareAsync(int id);
    }
}
