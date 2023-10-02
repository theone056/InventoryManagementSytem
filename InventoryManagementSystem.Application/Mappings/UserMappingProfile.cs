﻿using AutoMapper;
using InventoryManagementSystem.Application.Models;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegistrationModel, User>();
        }
    }
}