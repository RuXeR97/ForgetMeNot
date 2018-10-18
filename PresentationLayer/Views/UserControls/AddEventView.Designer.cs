namespace PresentationLayer.Views.UserControls
{
    partial class AddEventView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonDockableNavigator1 = new ComponentFactory.Krypton.Docking.KryptonDockableNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.endHourKryptonDateTimePicker = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.startHourKryptonDateTimePicker = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.calendarsComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.calendarKryptonLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cancelKryptonButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.confirmKryptonButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.endTimeKryptonDateTimePicker = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.startTimeKryptonDateTimePicker = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.locationKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.descriptionKryptonTextBox = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.endTimeKryptonLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.startTimeKryptonLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.locationKryptonLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.descriptionKryptonLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).BeginInit();
            this.kryptonDockableNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarsComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonDockableNavigator1
            // 
            this.kryptonDockableNavigator1.Location = new System.Drawing.Point(1, 1);
            this.kryptonDockableNavigator1.Name = "kryptonDockableNavigator1";
            this.kryptonDockableNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonDockableNavigator1.SelectedIndex = 0;
            this.kryptonDockableNavigator1.Size = new System.Drawing.Size(635, 452);
            this.kryptonDockableNavigator1.TabIndex = 1;
            this.kryptonDockableNavigator1.Text = "kryptonDockableNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.panel1);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(633, 421);
            this.kryptonPage1.Text = "Event";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "1AD4F24E4F69413334810AAD3B461ECB";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.endHourKryptonDateTimePicker);
            this.panel1.Controls.Add(this.startHourKryptonDateTimePicker);
            this.panel1.Controls.Add(this.calendarsComboBox);
            this.panel1.Controls.Add(this.calendarKryptonLabel);
            this.panel1.Controls.Add(this.cancelKryptonButton);
            this.panel1.Controls.Add(this.confirmKryptonButton);
            this.panel1.Controls.Add(this.endTimeKryptonDateTimePicker);
            this.panel1.Controls.Add(this.startTimeKryptonDateTimePicker);
            this.panel1.Controls.Add(this.locationKryptonTextBox);
            this.panel1.Controls.Add(this.descriptionKryptonTextBox);
            this.panel1.Controls.Add(this.endTimeKryptonLabel);
            this.panel1.Controls.Add(this.startTimeKryptonLabel);
            this.panel1.Controls.Add(this.locationKryptonLabel);
            this.panel1.Controls.Add(this.descriptionKryptonLabel);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 348);
            this.panel1.TabIndex = 0;
            // 
            // endHourKryptonDateTimePicker
            // 
            this.endHourKryptonDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endHourKryptonDateTimePicker.Location = new System.Drawing.Point(424, 195);
            this.endHourKryptonDateTimePicker.Name = "endHourKryptonDateTimePicker";
            this.endHourKryptonDateTimePicker.ShowUpDown = true;
            this.endHourKryptonDateTimePicker.Size = new System.Drawing.Size(107, 25);
            this.endHourKryptonDateTimePicker.TabIndex = 15;
            this.endHourKryptonDateTimePicker.ValueChanged += new System.EventHandler(this.endHourKryptonDateTimePicker_ValueChanged);
            // 
            // startHourKryptonDateTimePicker
            // 
            this.startHourKryptonDateTimePicker.CustomFormat = "Time";
            this.startHourKryptonDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startHourKryptonDateTimePicker.Location = new System.Drawing.Point(424, 153);
            this.startHourKryptonDateTimePicker.Name = "startHourKryptonDateTimePicker";
            this.startHourKryptonDateTimePicker.ShowUpDown = true;
            this.startHourKryptonDateTimePicker.Size = new System.Drawing.Size(107, 25);
            this.startHourKryptonDateTimePicker.TabIndex = 14;
            this.startHourKryptonDateTimePicker.ValueChanged += new System.EventHandler(this.startHourKryptonDateTimePicker_ValueChanged);
            // 
            // calendarsComboBox
            // 
            this.calendarsComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.calendarsComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.calendarsComboBox.DropDownWidth = 260;
            this.calendarsComboBox.Location = new System.Drawing.Point(135, 237);
            this.calendarsComboBox.Name = "calendarsComboBox";
            this.calendarsComboBox.Size = new System.Drawing.Size(260, 25);
            this.calendarsComboBox.TabIndex = 13;
            // 
            // calendarKryptonLabel
            // 
            this.calendarKryptonLabel.Location = new System.Drawing.Point(28, 238);
            this.calendarKryptonLabel.Name = "calendarKryptonLabel";
            this.calendarKryptonLabel.Size = new System.Drawing.Size(75, 24);
            this.calendarKryptonLabel.TabIndex = 12;
            this.calendarKryptonLabel.Values.Text = "Calendar:";
            // 
            // cancelKryptonButton
            // 
            this.cancelKryptonButton.AutoSize = true;
            this.cancelKryptonButton.Location = new System.Drawing.Point(424, 296);
            this.cancelKryptonButton.Name = "cancelKryptonButton";
            this.cancelKryptonButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            this.cancelKryptonButton.Size = new System.Drawing.Size(90, 28);
            this.cancelKryptonButton.TabIndex = 11;
            this.cancelKryptonButton.Values.Text = "Cancel";
            // 
            // confirmKryptonButton
            // 
            this.confirmKryptonButton.AutoSize = true;
            this.confirmKryptonButton.Location = new System.Drawing.Point(298, 296);
            this.confirmKryptonButton.Name = "confirmKryptonButton";
            this.confirmKryptonButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            this.confirmKryptonButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.confirmKryptonButton.Size = new System.Drawing.Size(97, 28);
            this.confirmKryptonButton.TabIndex = 10;
            this.confirmKryptonButton.Values.Text = "Confirm";
            this.confirmKryptonButton.Click += new System.EventHandler(this.confirmKryptonButton_Click);
            // 
            // endTimeKryptonDateTimePicker
            // 
            this.endTimeKryptonDateTimePicker.Location = new System.Drawing.Point(135, 195);
            this.endTimeKryptonDateTimePicker.Name = "endTimeKryptonDateTimePicker";
            this.endTimeKryptonDateTimePicker.Size = new System.Drawing.Size(260, 25);
            this.endTimeKryptonDateTimePicker.TabIndex = 9;
            this.endTimeKryptonDateTimePicker.ValueChanged += new System.EventHandler(this.endTimeKryptonDateTimePicker_ValueChanged);
            // 
            // startTimeKryptonDateTimePicker
            // 
            this.startTimeKryptonDateTimePicker.Location = new System.Drawing.Point(135, 152);
            this.startTimeKryptonDateTimePicker.Name = "startTimeKryptonDateTimePicker";
            this.startTimeKryptonDateTimePicker.Size = new System.Drawing.Size(260, 25);
            this.startTimeKryptonDateTimePicker.TabIndex = 8;
            this.startTimeKryptonDateTimePicker.ValueChanged += new System.EventHandler(this.startTimeKryptonDateTimePicker_ValueChanged);
            // 
            // locationKryptonTextBox
            // 
            this.locationKryptonTextBox.Location = new System.Drawing.Point(135, 110);
            this.locationKryptonTextBox.Name = "locationKryptonTextBox";
            this.locationKryptonTextBox.Size = new System.Drawing.Size(396, 27);
            this.locationKryptonTextBox.TabIndex = 6;
            // 
            // descriptionKryptonTextBox
            // 
            this.descriptionKryptonTextBox.Location = new System.Drawing.Point(135, 26);
            this.descriptionKryptonTextBox.Name = "descriptionKryptonTextBox";
            this.descriptionKryptonTextBox.Size = new System.Drawing.Size(396, 75);
            this.descriptionKryptonTextBox.TabIndex = 5;
            this.descriptionKryptonTextBox.Text = "";
            // 
            // endTimeKryptonLabel
            // 
            this.endTimeKryptonLabel.Location = new System.Drawing.Point(27, 196);
            this.endTimeKryptonLabel.Name = "endTimeKryptonLabel";
            this.endTimeKryptonLabel.Size = new System.Drawing.Size(75, 24);
            this.endTimeKryptonLabel.TabIndex = 3;
            this.endTimeKryptonLabel.Values.Text = "End time:";
            // 
            // startTimeKryptonLabel
            // 
            this.startTimeKryptonLabel.Location = new System.Drawing.Point(27, 153);
            this.startTimeKryptonLabel.Name = "startTimeKryptonLabel";
            this.startTimeKryptonLabel.Size = new System.Drawing.Size(81, 24);
            this.startTimeKryptonLabel.TabIndex = 2;
            this.startTimeKryptonLabel.Values.Text = "Start time:";
            // 
            // locationKryptonLabel
            // 
            this.locationKryptonLabel.Location = new System.Drawing.Point(27, 109);
            this.locationKryptonLabel.Name = "locationKryptonLabel";
            this.locationKryptonLabel.Size = new System.Drawing.Size(73, 24);
            this.locationKryptonLabel.TabIndex = 1;
            this.locationKryptonLabel.Values.Text = "Location:";
            // 
            // descriptionKryptonLabel
            // 
            this.descriptionKryptonLabel.Location = new System.Drawing.Point(27, 26);
            this.descriptionKryptonLabel.Name = "descriptionKryptonLabel";
            this.descriptionKryptonLabel.Size = new System.Drawing.Size(92, 24);
            this.descriptionKryptonLabel.TabIndex = 0;
            this.descriptionKryptonLabel.Values.Text = "Description:";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(439, 367);
            this.kryptonPage2.Text = "Unimplemented";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "390D76CE5CE14952ABBA9DF3764EE80E";
            // 
            // AddEventView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 377);
            this.Controls.Add(this.kryptonDockableNavigator1);
            this.Name = "AddEventView";
            this.Text = "Add event";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).EndInit();
            this.kryptonDockableNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendarsComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Docking.KryptonDockableNavigator kryptonDockableNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton cancelKryptonButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton confirmKryptonButton;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker endTimeKryptonDateTimePicker;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker startTimeKryptonDateTimePicker;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox locationKryptonTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox descriptionKryptonTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel endTimeKryptonLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel startTimeKryptonLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel locationKryptonLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel descriptionKryptonLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox calendarsComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel calendarKryptonLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker endHourKryptonDateTimePicker;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker startHourKryptonDateTimePicker;
    }
}