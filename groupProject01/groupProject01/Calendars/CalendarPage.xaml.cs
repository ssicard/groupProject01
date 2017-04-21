﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;

namespace groupProject01
{

        public partial class CalendarPage : ContentPage                           //begins the CalendarPage class
        {

            public CalendarPage()
        {
            InitializeComponent();
        }
        #region BottomBarStuff

        public void OnHome(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void OnList(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void OnCalendar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void OnMessaging(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void OnSetting(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
       
            public ObservableCollection<CalendarOptionObject> calendar { get; set; } //declares calendars ObservableCollection that will notify when calendars are added, removed, and refreshed
            private GlobalData _gd;                                              //declares global variable GlobalData to store the global data

            public CalendarPage(GlobalData gd)                                  //CalendarPage constructor
            {
                InitializeComponent();                                          //initializes UI objects with values provided, initializes elements
                _gd = gd;                                                        //sets private instance of global data
                calendar = _gd.CalendarDataInstance.options;                    //gets the calendar data from the data file
                calView.ItemsSource = calendar;                                  //sets the source of items to template and display
            }

            async void OnTap(object sender, ItemTappedEventArgs e)                    //Lister that fires when a calendar item is tapped
            {
                int index = ((CalendarOptionObject)e.Item).ID;                           //gets the ID of the calendar item
                await Navigation.PushAsync(new groupProject01.EventPage(index, _gd)); //opens the event page as current page continues to run
            }



            /* METHODS TO ADD:
             * createNewEvent
             * scheduleNewGuest(s)
             * scheduleChore
             * reserveLaundryMachines
             * reserveQuiettime
             */
        }
    }
