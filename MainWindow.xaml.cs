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
        public Recipe target;

        public MainWindow()
        {
            target = null;
            InitializeComponent();
            for(int i = 1; i <= 10; i++)
            {
                Recipe recipe = new Recipe("Recipe " + i, "Main", "pasta.jpg", new List<Ingredient>(), new List<Instruction>());
                RecipeTileControl a = new RecipeTileControl(recipe);

                Console.Write("made recipe control");
                Recipe_Grid.Children.Add(a);

                a.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);                
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

        private void BackArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            target = (sender as RecipeTileControl).recipe;
            RecipeName.Text = target.recipeName;
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

        private void Favorites_Button_Click(object sender, MouseButtonEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Hidden;
            Favorites_Grid.Visibility = Visibility.Visible;
        }

        private void AddRecipe_Click(object sender, MouseButtonEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Hidden;
            Favorites_Grid.Visibility = Visibility.Hidden;
            AddRecipe_Grid.Visibility = Visibility.Visible;
        }

        private void Favourites_Favorites_Button_Click(object sender, MouseButtonEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Visible;
            Favorites_Grid.Visibility = Visibility.Hidden;
        }

        private void Recipe_Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
            HomePage_Grid.Visibility = Visibility.Visible;
        }
    }
}
