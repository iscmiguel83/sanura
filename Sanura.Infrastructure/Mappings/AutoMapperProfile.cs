using AutoMapper;
using Sanura.Core.DTOs;
using Sanura.Core.Entities;

namespace Sanura.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Module, ModuleDto>()
                .ForMember(dest => dest.ModuleParent, opt => opt.MapFrom(src => src.ModuleParentObject != null
                        ? src.ModuleParentObject.Code
                        : null))
                .ForMember(dest => dest.CreationDateTime, opt => opt.MapFrom(src => src.CreationDateTime.DateTime))
                .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.CreatedByUserObject != null
                        ? string.Format("{0} {1}", src.CreatedByUserObject.FirstName, src.CreatedByUserObject.LastName)
                        : null))
                .ForMember(dest => dest.UpdateDateTime, opt => opt.MapFrom(src => src.UpdateDateTime != null
                        ? (DateTime?)src.UpdateDateTime.Value.DateTime
                        : null))
                .ForMember(dest => dest.UpdatedByUser, opt => opt.MapFrom(src => src.UpdatedByUserObject != null
                        ? string.Format("{0} {1}", src.UpdatedByUserObject.FirstName, src.UpdatedByUserObject.LastName)
                        : null))
                .ReverseMap();
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.CreationDateTime, opt => opt.MapFrom(src => src.CreationDateTime.DateTime))
                .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.CreatedByUserObject != null
                        ? string.Format("{0} {1}", src.CreatedByUserObject.FirstName, src.CreatedByUserObject.LastName)
                        : null))
                .ForMember(dest => dest.UpdateDateTime, opt => opt.MapFrom(src => src.UpdateDateTime != null
                        ? (DateTime?)src.UpdateDateTime.Value.DateTime
                        : null))
                .ForMember(dest => dest.UpdatedByUser, opt => opt.MapFrom(src => src.UpdatedByUserObject != null
                        ? string.Format("{0} {1}", src.UpdatedByUserObject.FirstName, src.UpdatedByUserObject.LastName)
                        : null))
                .ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday != null
                        ? (DateTime?)src.Birthday.Value.DateTime
                        : null))
                .ForMember(dest => dest.CreationDateTime, opt => opt.MapFrom(src => src.CreationDateTime.DateTime))
                .ForMember(dest => dest.CreatedByUser, opt => opt.MapFrom(src => src.CreatedByUserObject != null
                        ? string.Format("{0} {1}", src.CreatedByUserObject.FirstName, src.CreatedByUserObject.LastName)
                        : null))
                .ForMember(dest => dest.UpdateDateTime, opt => opt.MapFrom(src => src.UpdateDateTime != null
                        ? (DateTime?)src.UpdateDateTime.Value.DateTime
                        : null))
                .ForMember(dest => dest.UpdatedByUser, opt => opt.MapFrom(src => src.UpdatedByUserObject != null
                        ? string.Format("{0} {1}", src.UpdatedByUserObject.FirstName, src.UpdatedByUserObject.LastName)
                        : null))
                .ReverseMap();
        }
    }
}
