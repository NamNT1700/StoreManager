using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Entities.DataTransferObjects;

namespace StoreManager
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Customers, CustomersDto>();
            CreateMap<Orders, OrdersDto>();
        }
    }
}
