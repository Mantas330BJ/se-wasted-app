﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        IQueryable<Reservation> GetByFoodAndCustomer(string foodId, string customerId);
    }
}
