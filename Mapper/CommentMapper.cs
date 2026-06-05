using EazyTrade.Dto;
using EazyTrade.Models;

namespace EazyTrade.Mapper
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Detail = commentModel.Detail,
                CommodityId = commentModel.CommodityId,
                CreateAt = commentModel.CreateAt
            };
        }

        public static Comment ToCommentFromManipulation(this CommentForManipulationDto commentForManipulationDto)
        {
            return new Comment
            {
                Detail = commentForManipulationDto.Detail,
                CommodityId = commentForManipulationDto.CommodityId,
                CreateAt = DateTime.UtcNow, // Default for now since it's required
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
