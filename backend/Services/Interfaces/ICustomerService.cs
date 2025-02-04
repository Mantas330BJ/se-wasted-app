﻿using Contracts.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICustomerService : IAuthService<CustomerRegisterRequest>
    {
        string GetCustomerIdFromMail(Mail mail);
        IEnumerable<FoodResponse> GetReservedFoodFromCustomerId(string customerId);
        CustomerDto GetCustomerDtoById(string id);
    }
}
