﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HotelManagement.ViewModel.ManagementList;
using Wpf.Ui.Controls;

namespace HotelManagement.View.AddView
{
    /// <summary>
    /// Interaction logic for Addbooking.xaml
    /// </summary>
    public partial class AddBooking : Window
    {
        private void PaymentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Log the selected payment method
            string selectedPaymentMethod = PaymentBox.SelectedItem as string;
            System.Diagnostics.Debug.WriteLine($"Selected Payment Method: {selectedPaymentMethod}");
        }
        private BookingList? Booking => DataContext as BookingList;

        public AddBooking(object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;

            Booking!.GenerateBookingId();
        }

        public AddBooking(string? id, object dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;

            if (id != null)
                Booking!.GetBookingById(id);
        }

        private void AddBooking_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Booking!.RoomIdList.RemoveAt(Booking.RoomIdList.Count - 1);
            this.Close();
        }

        private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddBooking_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (CheckInBox.SelectedDate == null)
            {
                CheckInBox.SelectedDate = DateTime.Now;
            }

            if (CheckOutBox.SelectedDate == null)
            {
                CheckOutBox.SelectedDate = DateTime.Now.AddDays(1);
            }
        }

        private void RoomIdBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            var itemVm = Booking!.CurrentBooking.RoomItem;
            
            if (itemVm.RoomID != null)
            {
                (RoomIdBox.ItemsSource as List<RoomInfo>)!.Add(itemVm);

                var index = -1;

                foreach (var item in (RoomIdBox.ItemsSource as List<RoomInfo>)!.Where(item =>
                             item.RoomID == itemVm.RoomID))
                {
                    index = Booking.RoomIdList.IndexOf(item);
                    break;
                }

                RoomIdBox.SelectedIndex = index;
            }
        }
    }
}