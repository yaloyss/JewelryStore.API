using System;
using AutoMapper;
using JewelryStore.BLL.DTOs.Client;
using JewelryStore.BLL.DTOs.Employee;
using JewelryStore.BLL.DTOs.Order;
using JewelryStore.BLL.DTOs.Product;
using JewelryStore.DAL.Models;

namespace JewelryStore.BLL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientSummaryDTO>();

            CreateMap<Employee, EmployeeSummaryDTO>();

            CreateMap<Product, ProductListViewDTO>();
            CreateMap<Product, ProductDetailedViewDTO>();
            CreateMap<ProductCreateUpdateDTO, Product>();

            CreateMap<Order, ClientOrderHistoryDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price));

            CreateMap<Order, AdminOrderHistoryDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client));

            CreateMap<Order, OrderCreatedResponseDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"));
        }
    }
}

