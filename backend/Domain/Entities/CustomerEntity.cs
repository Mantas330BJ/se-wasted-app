﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CustomerEntity : Entity
    {
        public CustomerEntity()
        {
            Reservations = new HashSet<ReservationEntity>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<ReservationEntity> Reservations { get; set; }
    }
}
