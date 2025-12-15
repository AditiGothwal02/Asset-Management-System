using AssetManagementWebApi.DTO;
using AssetManagementWebApi.Models;
using AssetManagementWebApi.Repositories.Interfaces;
using AssetManagementWebApi.Services.Interfaces;
using AssetManagementWebApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementWebApi.Services.Implementation
{
    public class AssetService : IAssetService
    {
        private readonly IGenericRepository<Book> _bookRepo;
        private readonly IGenericRepository<Hardware> _hardwareRepo;
        private readonly IGenericRepository<Software> _softwareRepo;
        private readonly IUserRepository _userRepo;

        public AssetService(
            IGenericRepository<Book> bookRepo,
            IGenericRepository<Hardware> hardwareRepo,
            IGenericRepository<Software> softwareRepo,
            IUserRepository userRepo)
        {
            _bookRepo = bookRepo;
            _hardwareRepo = hardwareRepo;
            _softwareRepo = softwareRepo;
            _userRepo = userRepo;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto dto)
        {
            await ValidateUser(dto.AssignedUserId);

            var book = new Book
            {
                Name = dto.Name,
                Author = dto.Author,
                PurchaseDate = dto.PurchaseDate,
                AssignedUserId = dto.AssignedUserId
            };

            await _bookRepo.AddAsync(book);
            await _bookRepo.SaveChangesAsync();

            return MapBookToDto(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            return books.Select(MapBookToDto);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            return book == null ? null : MapBookToDto(book);
        }

        public async Task<BookDto> UpdateBookAsync(int id, UpdateBookDto dto)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) throw new AppException("Book not found");

            await ValidateUser(dto.AssignedUserId);

            book.Name = dto.Name ?? book.Name;
            book.Author = dto.Author ?? book.Author;
            book.PurchaseDate = dto.PurchaseDate ?? book.PurchaseDate;
            book.AssignedUserId = dto.AssignedUserId ?? book.AssignedUserId;

            _bookRepo.Update(book);
            await _bookRepo.SaveChangesAsync();

            return MapBookToDto(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) throw new AppException("Book not found");

            _bookRepo.Delete(book);
            await _bookRepo.SaveChangesAsync();
        }

     
        public async Task<HardwareDto> CreateHardwareAsync(CreateHardwareDto dto)
        {
            await ValidateUser(dto.AssignedUserId);

            var hardware = new Hardware
            {
                Name = dto.Name,
                Model = dto.Model,
                PurchaseDate = dto.PurchaseDate,
                AssignedUserId = dto.AssignedUserId
            };

            await _hardwareRepo.AddAsync(hardware);
            await _hardwareRepo.SaveChangesAsync();

            return MapHardwareToDto(hardware);
        }

        public async Task<IEnumerable<HardwareDto>> GetHardwareAsync()
        {
            var hardwareList = await _hardwareRepo.GetAllAsync();
            return hardwareList.Select(MapHardwareToDto);
        }

        public async Task<HardwareDto?> GetHardwareByIdAsync(int id)
        {
            var hardware = await _hardwareRepo.GetByIdAsync(id);
            return hardware == null ? null : MapHardwareToDto(hardware);
        }

        public async Task<HardwareDto> UpdateHardwareAsync(int id, UpdateHardwareDto dto)
        {
            var hardware = await _hardwareRepo.GetByIdAsync(id);
            if (hardware == null) throw new AppException("Hardware not found");

            await ValidateUser(dto.AssignedUserId);

            hardware.Name = dto.Name ?? hardware.Name;
            hardware.Model = dto.Model ?? hardware.Model;
            hardware.PurchaseDate = dto.PurchaseDate ?? hardware.PurchaseDate;
            hardware.AssignedUserId = dto.AssignedUserId ?? hardware.AssignedUserId;

            _hardwareRepo.Update(hardware);
            await _hardwareRepo.SaveChangesAsync();

            return MapHardwareToDto(hardware);
        }

        public async Task DeleteHardwareAsync(int id)
        {
            var hardware = await _hardwareRepo.GetByIdAsync(id);
            if (hardware == null) throw new AppException("Hardware not found");

            _hardwareRepo.Delete(hardware);
            await _hardwareRepo.SaveChangesAsync();
        }

      
        public async Task<SoftwareDto> CreateSoftwareAsync(CreateSoftwareDto dto)
        {
            await ValidateUser(dto.AssignedUserId);

            var software = new Software
            {
                Name = dto.Name,
                Version = dto.Version,
                AssignedUserId = dto.AssignedUserId
            };

            await _softwareRepo.AddAsync(software);
            await _softwareRepo.SaveChangesAsync();

            return MapSoftwareToDto(software);
        }

        public async Task<IEnumerable<SoftwareDto>> GetSoftwareAsync()
        {
            var softwareList = await _softwareRepo.GetAllAsync();
            return softwareList.Select(MapSoftwareToDto);
        }

        public async Task<SoftwareDto?> GetSoftwareByIdAsync(int id)
        {
            var software = await _softwareRepo.GetByIdAsync(id);
            return software == null ? null : MapSoftwareToDto(software);
        }

        public async Task<SoftwareDto> UpdateSoftwareAsync(int id, UpdateSoftwareDto dto)
        {
            var software = await _softwareRepo.GetByIdAsync(id);
            if (software == null) throw new AppException("Software not found");

            await ValidateUser(dto.AssignedUserId);

            software.Name = dto.Name ?? software.Name;
            software.Version = dto.Version ?? software.Version;
            software.AssignedUserId = dto.AssignedUserId ?? software.AssignedUserId;

            _softwareRepo.Update(software);
            await _softwareRepo.SaveChangesAsync();

            return MapSoftwareToDto(software);
        }

        public async Task DeleteSoftwareAsync(int id)
        {
            var software = await _softwareRepo.GetByIdAsync(id);
            if (software == null) throw new AppException("Software not found");

            _softwareRepo.Delete(software);
            await _softwareRepo.SaveChangesAsync();
        }

        private async Task ValidateUser(int? userId)
        {
            if (userId.HasValue)
            {
                var user = await _userRepo.GetByIdAsync(userId.Value);
                if (user == null) throw new AppException("Assigned user does not exist");
            }
        }

        private BookDto MapBookToDto(Book book) => new BookDto
        {
            Id = book.Id,
            Name = book.Name,
            Author = book.Author,
            PurchaseDate = book.PurchaseDate,
            AssignedUserId = book.AssignedUserId,
            AssignedUsername = book.AssignedUser?.Username
        };

        private HardwareDto MapHardwareToDto(Hardware hardware) => new HardwareDto
        {
            Id = hardware.Id,
            Name = hardware.Name,
            Model = hardware.Model,
            PurchaseDate = hardware.PurchaseDate,
            AssignedUserId = hardware.AssignedUserId,
            AssignedUsername = hardware.AssignedUser?.Username
        };

        private SoftwareDto MapSoftwareToDto(Software software) => new SoftwareDto
        {
            Id = software.Id,
            Name = software.Name,
            Version = software.Version,
            AssignedUserId = software.AssignedUserId,
            AssignedUsername = software.AssignedUser?.Username
        };
    }
}
