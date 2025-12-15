using AssetManagementWebApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity, TDto> : ControllerBase
    where TEntity : class, new()
    where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericController(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TDto dto)
        {
            var entity = new TEntity();

            foreach (var prop in typeof(TDto).GetProperties())
            {
                var entityProp = typeof(TEntity).GetProperty(prop.Name);
                if (entityProp != null)
                    entityProp.SetValue(entity, prop.GetValue(dto));
            }

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = typeof(TEntity).GetProperty("Id")!.GetValue(entity) }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();

            foreach (var prop in typeof(TDto).GetProperties())
            {
                var entityProp = typeof(TEntity).GetProperty(prop.Name);
                if (entityProp != null)
                    entityProp.SetValue(entity, prop.GetValue(dto));
            }    

            _repository.Update(entity);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }

}
