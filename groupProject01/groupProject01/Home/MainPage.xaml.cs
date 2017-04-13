﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace groupProject01
{
	public partial class MainPage : ContentPage
	{
        ICredentials service;
        GlobalData _gd;
		public MainPage(GlobalData gd)
		{
            _gd = gd;
            //error on iphone
			InitializeComponent();

            service = DependencyService.Get<ICredentials>();
		}

        async void OnRetrieve(object sender, EventArgs e)
        {
            try
            {
                ListItemObject l = new ListItemObject();
                l.Name = "Test";
                l.ID = 0;
                l.Type = 0;
                //RestService r = new RestService();
                string test = await (ServerHandeler.sendList(l));
                dynamic jsonDe = JsonConvert.DeserializeObject(test);
                textField.Text = jsonDe.name;
            }
            catch (Exception ex)
            {
                textField.Text = ex.Message;
            }
           

        }
        void OnSave(object sender, EventArgs e)
        {
            service.setPrefs("test", textField.Text);
            
        }
        async void OnSetting(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new groupProject01.SettingsPage());

        }
        async void OnList(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new groupProject01.ListsPage(_gd)));

        }
        async void OnCalendar(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new groupProject01.CalendarPage(_gd));

        }
        async void OnMessaging(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new groupProject01.MessagingPage(_gd));

        }
    }
}
