﻿
namespace wasted_app
{
    partial class RestaurantViewFoodControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.filterButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.foodPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.filterButton);
            this.panel1.Controls.Add(this.sortButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 451);
            this.panel1.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.backButton.Location = new System.Drawing.Point(166, 419);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(94, 29);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(90, 71);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(94, 29);
            this.filterButton.TabIndex = 4;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(90, 36);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(94, 29);
            this.sortButton.TabIndex = 3;
            this.sortButton.Text = "Sort";
            this.sortButton.UseVisualStyleBackColor = true;
            // 
            // foodPanel
            // 
            this.foodPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foodPanel.AutoScroll = true;
            this.foodPanel.Location = new System.Drawing.Point(266, 0);
            this.foodPanel.Name = "foodPanel";
            this.foodPanel.Size = new System.Drawing.Size(534, 451);
            this.foodPanel.TabIndex = 2;
            // 
            // RestaurantViewFoodControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.foodPanel);
            this.Controls.Add(this.panel1);
            this.Name = "RestaurantViewFoodControl";
            this.Size = new System.Drawing.Size(800, 451);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.FlowLayoutPanel foodPanel;
    }
}