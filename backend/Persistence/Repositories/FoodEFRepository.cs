﻿using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;
using Persistence.Utils;
using Services.Mappers;
using System;
using System.Linq;

namespace Persistence.Repositories
{
    public class FoodEFRepository : IFoodRepository
    {
        private readonly DatabaseContext _context;
        public FoodEFRepository(DatabaseContext context)
        {
            _context = context;
        }
        public string Insert(Food food)
        {
            food.Id = IdGenerator.GenerateUniqueId();

            FoodEntity entity = food.ToEntity();

            var typeIds = entity.TypesOfFood.Select(x => x.Id);
            var typesOfFood = _context.TypesOfFood.Where(x => typeIds.Contains(x.Id));

            entity.TypesOfFood = typesOfFood.ToList();

            _context.Foods.Add(entity);
            _context.SaveChanges();
            return food.Id;
        }

        public void Delete(string id)
        {
            FoodEntity entity = GetByIdString(id);
            _context.Foods.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<Food> GetAll()
        {
            return _context.Foods.Include(x => x.TypesOfFood).Include(x => x.Reservations).Select(x => x.ToDomain());
        }

        public Food GetById(string id)
        {
            return GetByIdString(id)?.ToDomain();
        }
        
        public void Update(Food food)  // FIX: cannot update typesOfFood
        {
            if (GetByIdString(food.Id) == null) return;

            FoodEntity local = _context.Foods.Local.FirstOrDefault(x => x.Id == Guid.Parse(food.Id));

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            var entity = food.ToEntity();
            entity.TypesOfFood = null;
            _context.Foods.Update(entity);

            _context.SaveChanges();
        }

        public IQueryable<Food> GetFoodFromRestaurant(string idRestaurant)
        {
            return _context.Foods.Include(x => x.TypesOfFood).Include(x => x.Reservations)
                                 .Where(food => food.RestaurantId == Guid.Parse(idRestaurant))
                                 .Select(x => x.ToDomain());
        }

        private FoodEntity GetByIdString(string id)
        {
            return _context.Foods.Include(x => x.TypesOfFood).Include(x => x.Reservations)
                                 .FirstOrDefault(x => x.Id == Guid.Parse(id));
        }
    }
}
