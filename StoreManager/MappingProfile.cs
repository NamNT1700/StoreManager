using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.OfficesDTO;
using Entities.DataTransferObjects.OrdersDTO;
using Entities.DataTransferObjects.EmployeesDTO;
using Entities.DataTransferObjects.ProductLinesDTO;
using Entities.DataTransferObjects.PaymentDTO;
using Entities.DataTransferObjects.ProductDTO;
using Entities.DataTransferObjects.OrdersDetailsDTO;

namespace StoreManager
{
    public class MappingProfile: Profile
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
