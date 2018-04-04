using System;
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
            this.recipe = recipe;
            InitializeComponent();
            this.Recipe_Name.Text = this.recipe.recipeName;
            if (recipe.photoPath != null)
            {
                BitmapImage src = new BitmapImage();
                src.UriSource = new Uri(this.recipe.photoPath, UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                this.Recipe_Image.Source = src;
            }
        }
    }
}
