using EazyTrade.Dto;
using EazyTrade.Interface.Repository;
using EazyTrade.Interface.Service;
using EazyTrade.Models;
using Mapster;

namespace EazyTrade.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RoleDto>> GetRolesAsync()
        {
            var queries = await _repository.GetAllAsync();
            return queries.Select(r => r.Adapt<RoleDto>()).ToList();
        }

        public async Task<RoleDto?> GetRoleByIdAsync(int id)
        {
            var query = await _repository.GetByIdAsync(id);
            if (query == null)
            {
                return null;
            }
            return query.Adapt<RoleDto>();
        }

        public async Task<RoleDto> CreateRoleAsync(RoleForManipulationDto payload)
        {
            var entity = payload.Adapt<Role>();
            await _repository.CreateAsync(entity);
            return entity.Adapt<RoleDto>();
        }

        public async Task<RoleDto?> UpdateRoleAsync(int id, RoleForManipulationDto payload)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            payload.Adapt(entity);
            entity.UpdateAt = DateTime.UtcNow;

            await _repository.UpdateAsync(id, entity);
            return entity.Adapt<RoleDto>();
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
