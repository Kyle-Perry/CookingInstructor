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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for(int i = 1; i <= 10; i++)
            {
                RecipeTileControl a = new RecipeTileControl();
                a.Recipe_Name.Text += " " + i;
                RecipeTileControl b = new RecipeTileControl();
                b.Recipe_Name.Text += " " + i;
                RecipeTileControl c = new RecipeTileControl();
                c.Recipe_Name.Text += " " + i;

                Favorites_Grid.Children.Add(a);
                Recipe_Grid.Children.Add(b);
                RecommendedList.Children.Add(c);

                IngredientPieceControl ipc = new IngredientPieceControl();
                IngredientsList.Children.Add(ipc);
                
            }

            HomePage_Grid.Visibility = Visibility.Visible;
            Favorites_Grid.Visibility = Visibility.Hidden;
            AddRecipe_Grid.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
            StepGrid.Visibility = Visibility.Hidden;
        }

        private void AddIngredient_Button_Click(object sender, RoutedEventArgs e)
        {
            IngredientInfoControl another = new IngredientInfoControl();
            IngredientList.Children.Add(another);
        }

        private void AddStep_Button_Click(object sender, RoutedEventArgs e)
        {
            RecipeInstructionControl another = new RecipeInstructionControl();
            InstructionList.Children.Add(another);
        }

        private void ViewRecipeBack_Button_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
            HomePage_Grid.Visibility = Visibility.Visible;
        }

        private void AddRecipeBack_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Visible;
            AddRecipe_Grid.Visibility = Visibility.Hidden;
        }

        private void FavoritesBack_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Visible;
            Favorites_Grid.Visibility = Visibility.Hidden;
        }

        private void Favorites_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Hidden;
            Favorites_Grid.Visibility = Visibility.Visible;
        }

        private void AddRecipe_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Hidden;
            AddRecipe_Grid.Visibility = Visibility.Visible;
        }

        private void BackArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Recipe_Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Visible;
        }

        private void StartCooking_Button_Click(object sender, RoutedEventArgs e)
        {
            StepGrid.Visibility = Visibility.Visible;
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
        }

        private void ViewRecipeBack_Button_Copy_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipe_Grid.Visibility = Visibility.Visible;
            StepGrid.Visibility = Visibility.Hidden;
        }

        private void ForwardArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Visible;
            Favorites_Grid.Visibility = Visibility.Hidden;
        }
    }
}
