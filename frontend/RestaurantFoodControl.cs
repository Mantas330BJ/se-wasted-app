﻿using backend.Controller;
using backend.Controller.DTOs;
using backend.Controller.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using wasted_app.Utilities;

namespace wasted_app
{
    public partial class RestaurantFoodControl : UserControl
    {
        private RestaurantDto LoggedRestaurant { get; set; }
        private IEnumerable<Food> Foods { get; set; }
        private readonly ServicesController services = ServicesController.Instance;
        public RestaurantFoodControl(RestaurantDto restaurant)
        {
            LoggedRestaurant = restaurant;
            InitializeComponent();
            InitializeComboBoxItems();
            GetRestaurantFoodItems();
            SortFoodByDate();
            ListRestaurantFoodItems(Foods);
        }

        private void GetRestaurantFoodItems()
        {
            Foods = FoodUtilities.GetFoodByRestaurantId(LoggedRestaurant.Id);
        }

        private void ListRestaurantFoodItems(IEnumerable <Food> foods)
        {
            foodPanel.Controls.Clear();
            var foodTypes = services.TypeOfFoodService.GetAllTypesOfFood();
            var foodListItems = foods.GroupJoin(
                foodTypes,
                food => food.IdTypeOfFood,
                type => type.Id,
                (food, typesCollection) =>
                    new
                    FoodListItem(
                        food.Name,
                        typesCollection.First().Name,
                        food.Price.ToString()
                    )
            );

            foreach (var food in foodListItems)
            {
                var foodItem = new FoodControl(food);
                foodPanel.Controls.Add(foodItem);
            }
        }

        private void InitializeComboBoxItems()
        {
            var foodTypesNames = FoodUtilities.GetAllFoodTypesNames();
            foreach (var foodTypeName in foodTypesNames)
            {
                typeComboBox.Items.Add(foodTypeName);
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

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            addFoodPanel.Visible = true;
        }

        private void AddFoodConfirmButton_Click(object sender, EventArgs e)
        {
            var id = FoodUtilities.GetFirstAvailableFoodId();
            var dateTime = DateTime.Now;
            var restaurantId = LoggedRestaurant.Id;
            var name = nameInput.Text;
            var price = decimal.Parse(priceInput.Text);
            var type = FoodUtilities.GetFoodTypeIdByName(typeComboBox.SelectedItem.ToString());
            
            var newFood = new Food(id, name, price, restaurantId, type);
            ServicesController.Instance.FoodService.RegisterFood(newFood);
            GetRestaurantFoodItems();
            ListRestaurantFoodItems(Foods);

            addFoodPanel.Visible = false;
            nameInput.Text = "";
            priceInput.Text = "";
            typeComboBox.SelectedIndex = -1;
        }

        private void PriceInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
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
            ListRestaurantFoodItems(Foods);
        }
    }
}