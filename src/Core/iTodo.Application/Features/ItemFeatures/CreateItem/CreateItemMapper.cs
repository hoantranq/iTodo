using AutoMapper;
using iTodo.Domain.Entities;

namespace iTodo.Application.Features.ItemFeatures.CreateItem;

public class CreateItemMapper : Profile
{
	public CreateItemMapper()
	{
		CreateMap<Item, CreateItemRequest>().ReverseMap();
		CreateMap<Item, CreateItemResponse>().ReverseMap();
	}
}

