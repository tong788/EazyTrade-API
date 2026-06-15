using EazyTrade.Dto;

namespace EazyTrade.Interface.Service
{
    public interface IRoleService
    {
        public Task<List<RoleDto>> GetRolesAsync();
        public Task<RoleDto?> GetRoleByIdAsync(int id);
        public Task<RoleDto> CreateRoleAsync(RoleForManipulationDto payload);
        public Task<RoleDto?> UpdateRoleAsync(int id, RoleForManipulationDto payload);
        public Task<bool> DeleteRoleAsync(int id);
    }
}
