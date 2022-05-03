using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.EmployeesDTO;
using Entities.DataTransferObjects.OfficesDTO;
using Entities.DataTransferObjects.OrdersDetailsDTO;
using Entities.DataTransferObjects.OrdersDTO;
using Entities.DataTransferObjects.PaymentDTO;
using Entities.DataTransferObjects.ProductDTO;
using Entities.DataTransferObjects.ProductLinesDTO;
using Entities.Models;

namespace StoreManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customers, CustomersDto>();
            CreateMap<CustomersForCreationDto, Customers>();
            CreateMap<CustomersForUpdateDto, Customers>();

            CreateMap<Orders, OrdersDto>();
            CreateMap<OrdersForCreationDto, Orders>();
            CreateMap<OrdersForUpdateDto, Orders>();

            CreateMap<Offices, OfficesDto>();
            CreateMap<OfficesForCreationDto, Offices>();
            CreateMap<OfficesForUpdateDto, Offices>();

            CreateMap<Employees, EmployeesDto>();
            CreateMap<EmployeesDto, Employees>();
            CreateMap<EmployeesForCreationDto, Employees>();
            CreateMap<EmployeesForUpdateDto, Employees>();

            CreateMap<ProductLines, ProductLinesDto>();
            CreateMap<ProductLinesForCreationDto, ProductLines>();
            CreateMap<ProductLinesForUpdateDto, ProductLines>();

            CreateMap<Payments, PaymentDto>();
            CreateMap<PaymentForCreationDto, Payments>();
            CreateMap<PaymentForUpdateDto, Payments>();

            CreateMap<Products, ProductDto>();
            CreateMap<ProductForCreationDto, Products>();
            CreateMap<ProductForUpdateDto, Products>();

            CreateMap<OrderDetails, OrderDetailsDto>();
            CreateMap<OrderDetailsForCreationDto, OrderDetails>();
            CreateMap<OrderDetailsForUpdateDto, OrderDetails>();

        }
    }
}
