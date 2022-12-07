using AutoMapper;
using Points.Domain.Entities;
using Points.Domain.ViewModels;

namespace Points.Application.Common.MappingProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentViewModel, Comment>();
            CreateMap<Comment, CommentViewModel>();
        }
    }
}
