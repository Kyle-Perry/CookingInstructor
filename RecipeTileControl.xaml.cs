using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectD2
{
    /// <summary>
    /// Interaction logic for RecipeTileControl.xaml
    /// </summary>
    public partial class RecipeTileControl : UserControl
    {
        public Recipe recipe;
        public RecipeTileControl(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            this.Recipe_Name.Text = this.recipe.recipeName;
            if (recipe.photoPath != null)
            {
                try
                {
                    //FileStream imgSrc = new FileStream(this.recipe.photoPath, FileMode.Open, FileAccess.Read);
                    Uri imgSrc = new Uri(this.recipe.photoPath, UriKind.Absolute);
                    BitmapImage src = new BitmapImage();
                    //src.StreamSource = imgSrc;
                    src.UriSource = imgSrc;
                    src.CacheOption = BitmapCacheOption.OnLoad;
                    BeginInit();
                    this.Recipe_Image.Source = src;
                    EndInit();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                    
            }
        }
    }

}
