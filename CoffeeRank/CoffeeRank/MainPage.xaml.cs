using CoffeeRank.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CoffeeRank
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static List<CoffeeType> coffeeTypes;
        public MainPage()
        {
            InitializeComponent();

            coffeeTypes = XMLParser.GetCoffeeTypesList();
            coffeeList.ItemsSource = coffeeTypes;
        }

        async void OnCoffeeList_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CoffeeType coffeeType = ((ListView)sender).SelectedItem as CoffeeType;
                await Navigation.PushAsync(new CoffeeTypePage(coffeeType));
            }
        }
    }
}
