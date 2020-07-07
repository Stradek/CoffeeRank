using CoffeeRank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeRank
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeTypePage : ContentPage
    {
        public static CoffeeType actualCoffeeType;

        uint animationTime = 2000;
        Easing animationType = Easing.SinOut;

        public ICommand _tapCommand => new Command<string>(async (url) => Launcher.OpenAsync(new Uri(url)));

        public CoffeeTypePage(CoffeeType coffeeType)
        {
            InitializeComponent();

            actualCoffeeType = coffeeType;

            coffeeName.Text = coffeeType.name;
            countryName.Text = coffeeType.country;
            flag.Source = ParseFlagName(coffeeType.country);
            score.Text = coffeeType.score;
            price.Text = coffeeType.price;
            websiteLink.Text = coffeeType.website;

            websiteLink.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = _tapCommand,
                CommandParameter = websiteLink.Text
            });

            

            if (isParameterKnown(coffeeType.aroma))
            {
                aromaLabel.Text = coffeeType.aroma;
                setProgressBarAnimation(aromaProgressBar, coffeeType.aroma);
            }
            if (isParameterKnown(coffeeType.acidity))
            {
                acidityLabel.Text = coffeeType.acidity;
                setProgressBarAnimation(acidityProgressBar, coffeeType.acidity);
            }
            if (isParameterKnown(coffeeType.body))
            {
                bodyLabel.Text = coffeeType.body;
                setProgressBarAnimation(bodyProgressBar, coffeeType.body);
            }
            if (isParameterKnown(coffeeType.flavor))
            {
                flavorLabel.Text = coffeeType.flavor;
                setProgressBarAnimation(flavorProgressBar, coffeeType.flavor);
            }
            if (isParameterKnown(coffeeType.aftertaste))
            {
                aftertasteLabel.Text = coffeeType.aftertaste;
                setProgressBarAnimation(aftertasteProgressBar, coffeeType.aftertaste);
            }
        }

        private void setProgressBarAnimation(ProgressBar progressBar, string parameterScore)
        {
            progressBar.ProgressTo(Double.Parse(parameterScore) / 10d, animationTime, animationType);
        }

        private bool isParameterKnown(string parameter)
        {
            if(parameter != "unknown")
            {
                return true;
            }
            else
            {
                return false;
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