﻿using backend.Controller.DTOs;
using backend.Controller.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using wasted_app.Utilities;

namespace wasted_app
{
    public partial class RestaurantViewFoodControl : UserControl
    {
        private RestaurantDto LoggedRestaurant { get; set; }
        private IEnumerable<Food> Foods { get; set; }

        public RestaurantViewFoodControl(RestaurantDto restaurant)
        {
            InitializeComponent();
            LoggedRestaurant = restaurant;
            GetRestaurantFoodItems();
            SortFoodByDate();
            ListRestaurantFoodItems();
        }

        private void GetRestaurantFoodItems()
        {
            Foods = FoodUtilities.GetFoodByRestaurantId(LoggedRestaurant.Id);
        }

        private void ListRestaurantFoodItems()
        {
            foreach (var food in Foods)
            {
                var foodItem = new FoodControl(new FoodListItem(food.Name, FoodUtilities.GetFoodTypeNameById(food.IdTypeOfFood), food.Price.ToString("0.00")));
                foodPanel.Controls.Add(foodItem);
            }
        }

        private void SortFoodByPrice()
        {
            Foods = Foods.SortByPrice();
        }

        private void SortFoodByDate()
        {
            Foods = Foods.SortByNew();
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            MainForm.mainForm.panel.Controls.Remove(this);
        }

        private void SortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foodPanel.Controls.Clear();
            GetRestaurantFoodItems();
            if (SortComboBox.SelectedIndex == 0)
            {
                SortFoodByPrice();
            }
            else
            {
                SortFoodByDate();
            }
            ListRestaurantFoodItems();
        }
    }
}