using AutoMapper;
using Points.Domain.Entities;
using Points.Domain.ViewModels;

namespace Points.Application.Common.MappingProfiles
{
    public class DotProfile : Profile
    {
        public DotProfile()
        {
            CreateMap<DotViewModel, Dot>();
            CreateMap<Dot, DotViewModel>();
        }
    }
}