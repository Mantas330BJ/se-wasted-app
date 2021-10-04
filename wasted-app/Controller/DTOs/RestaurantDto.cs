﻿using console_wasted_app.Controller.Entities;

namespace console_wasted_app.Controller.DTOs
{
    public class RestaurantDto : BaseDto
    {
        public Coords Coords { get; set; }

        public RestaurantDto
        (
            string id,
            string name,
            Coords coords
        )
            : base(id, name)
        {
            Coords = coords;
        }

        public static RestaurantDto FromEntity(Restaurant restaurant)
        {
            return new RestaurantDto
            (
                restaurant.Id,
                restaurant.Name,
                restaurant.Coords
            );
        }
    }
}