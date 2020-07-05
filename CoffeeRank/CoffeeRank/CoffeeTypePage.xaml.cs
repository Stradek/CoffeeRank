using CoffeeRank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeRank
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeTypePage : ContentPage
    {
        public static CoffeeType actualCoffeeType;
        public CoffeeTypePage(CoffeeType coffeeType)
        {
            InitializeComponent();

            coffeeName.Text = coffeeType.name;
            countryName.Text = coffeeType.country;
            flag.Source = ParseFlagName(coffeeType.country);
            score.Text = coffeeType.score;
            price.Text = coffeeType.price;

            uint animationTime = 2000;
            Easing animationType = Easing.SinOut;

            if (coffeeType.aroma != "unknown")
            {
                aromaLabel.Text = coffeeType.aroma;
                aromaProgressBar.ProgressTo(Double.Parse(coffeeType.aroma) / 10d, animationTime, animationType);
            }
            if (coffeeType.acidity != "unknown")
            {
                acidityLabel.Text = coffeeType.acidity;
                acidityProgressBar.ProgressTo(Double.Parse(coffeeType.acidity) / 10d, animationTime, animationType);
            }
            if (coffeeType.body != "unknown")
            {
                bodyLabel.Text = coffeeType.body;
                bodyProgressBar.ProgressTo(Double.Parse(coffeeType.body) / 10d, animationTime, animationType);
            }
            if (coffeeType.flavor != "unknown")
            {
                flavorLabel.Text = coffeeType.flavor;
                flavorProgressBar.ProgressTo(Double.Parse(coffeeType.flavor) / 10d, animationTime, animationType);
            }
            if (coffeeType.aftertaste != "unknown")
            {
                aftertasteLabel.Text = coffeeType.aftertaste;
                aftertasteProgressBar.ProgressTo(Double.Parse(coffeeType.aftertaste) / 10d, animationTime, animationType);
            }
        }

        private string ParseFlagName(string country_name)
        {
            string flag_file = "";
            string[] words = country_name.ToLower().Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (i + 1 != words.Length)
                {
                    flag_file += words[i] + "_";
                }
                else
                {
                    flag_file += words[i] + "_flag.png";
                }
            }

            return flag_file;
        }
    }
}