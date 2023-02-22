using AutoMapper;
using iTodo.Application.Features.ItemFeatures.Dtos;
using iTodo.Domain.Entities;

namespace iTodo.Application.Features.ItemFeatures.Mappings;

public class ItemMappingProfile : Profile
{
    public ItemMappingProfile()
    {
        CreateMap<Item, ItemResponseDto>().ReverseMap();
    }
}