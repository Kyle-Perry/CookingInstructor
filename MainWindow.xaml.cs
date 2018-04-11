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
        public List<Recipe> recipes;
        public Serializer serializer;
        public Grid last;

        public MainWindow()
        {
            recipes = null;
            serializer = new Serializer("recipes.xml");
            target = null;
            InitializeComponent();
            recipes = serializer.Read();
            if (recipes == null)
            {
                recipes = new List<Recipe>();
                for (int i = 1; i <= 10; i++)
                {
                    Recipe recipe = new Recipe("Recipe " + i, "Main", "pasta.jpg", new List<Ingredient>(), new List<Instruction>());
                    recipe.ingredients.Add(new Ingredient("Liquid", "ml", 250 ));
                    recipe.ingredients.Add(new Ingredient("Dry", "tsp", 2));
                    recipe.instructions.Add(new Instruction("Do a thing", "pasta.jpg"));
                    recipe.instructions.Add(new Instruction("Do another thing", "pasta.jpg"));
                    RecipeTileControl a = new RecipeTileControl(recipe);
                    recipes.Add(recipe);
                    Recipe_Grid.Children.Add(a);

                    a.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
                }
            }
            else
            {
                foreach(Recipe recipe in recipes)
                {
                    RecipeTileControl a = new RecipeTileControl(recipe);
                    Recipe_Grid.Children.Add(a);

                    a.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
                    if(recipe.isFavorite)
                    {
                        RecipeTileControl b = new RecipeTileControl(recipe);
                        Recipe_Grid_Copy.Children.Add(b);

                        b.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
                    }
                }
            }

            HomePage_Grid.Visibility = Visibility.Visible;
            last = HomePage_Grid;
            Favorites_Grid.Visibility = Visibility.Hidden;
            AddRecipe_Grid.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
            StepGridFirst.Visibility = Visibility.Hidden;
            StepGridMiddle.Visibility = Visibility.Hidden;
            StepGridEnd.Visibility = Visibility.Hidden;

        }

        private void ViewRecipeBack_Button_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
            last.Visibility = Visibility.Visible;
        }

        private void AddRecipeBack_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Visible;
            last = HomePage_Grid;
            AddRecipe_Grid.Visibility = Visibility.Hidden;
        }

        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            target = (sender as RecipeTileControl).recipe;
            RecipeName.Text = target.recipeName;
            RecipeInstructionList1.Text = "";
            IngredientsList.Children.Clear();
            foreach(Ingredient ingredient in target.ingredients)
            {
                IngredientPieceControl piece = new IngredientPieceControl(ingredient);
                IngredientsList.Children.Add(piece);
            }
            int i = 1;
            foreach(Instruction instruction in target.instructions)
            {
                RecipeInstructionList1.Text += i + ".) " + instruction.info + "\n";
                i++;
            }
            HomePage_Grid.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Visible;
            Favorites_Grid.Visibility = Visibility.Hidden;
        }

        private void ForwardArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Visible;
            Favorites_Grid.Visibility = Visibility.Hidden;
            last = HomePage_Grid;
        }

        private void Favorites_Button_Click(object sender, MouseButtonEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Hidden;
            Favorites_Grid.Visibility = Visibility.Visible;
            last = Favorites_Grid;

        }

        private void AddRecipe_Click(object sender, MouseButtonEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Hidden;
            Favorites_Grid.Visibility = Visibility.Hidden;
            AddRecipe_Grid.Visibility = Visibility.Visible;
        }

        private void Recipe_Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
            last.Visibility = Visibility.Visible;
        }

        private void AddRecipe_Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddRecipe_Grid.Visibility = Visibility.Hidden;
            HomePage_Grid.Visibility = Visibility.Visible;
            last = HomePage_Grid;
        }

        private void StartCooking_Click(object sender, MouseButtonEventArgs e)
        {
            StepGridFirst.Visibility = Visibility.Visible;
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
        }

        private void BackArrowLast_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StepGridMiddle.Visibility = Visibility.Visible;
            StepGridEnd.Visibility = Visibility.Hidden;
        }

        private void ForwardArrowFirst_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StepGridFirst.Visibility = Visibility.Hidden;
            StepGridMiddle.Visibility = Visibility.Visible;
        }

        private void BackArrowMiddle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StepGridFirst.Visibility = Visibility.Visible;
            StepGridMiddle.Visibility = Visibility.Hidden;
        }

        private void ForwardArrowMiddle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StepGridMiddle.Visibility = Visibility.Hidden;
            StepGridEnd.Visibility = Visibility.Visible;
        }

        private void StopCookingMiddle_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StepGridMiddle.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Visible;
        }

        private void StopCookingFirst_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StepGridFirst.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Visible;
        }

        private void StopCookingEnd_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StepGridEnd.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Visible;
        }
        
        private void Favorites_Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomePage_Grid.Visibility = Visibility.Visible;
            Favorites_Grid.Visibility = Visibility.Hidden;
            last = HomePage_Grid;
        }

        private void Search_Back_Press(object sender, MouseButtonEventArgs e)
        {
            Search_Grid.Visibility = Visibility.Hidden;
            HomePage_Grid.Visibility = Visibility.Visible;
            last = HomePage_Grid;
        }

        private void SearchButton_Press(object sender, MouseButtonEventArgs e)
        {
            Search_Grid.Visibility = Visibility.Visible;
            HomePage_Grid.Visibility = Visibility.Hidden;
            last = Search_Grid;
        }

        private void AddToFav_Button_Click(object sender, RoutedEventArgs e)
        {
            if (target.isFavorite == false)
            {
                target.isFavorite = true;
                RecipeTileControl addFav = new RecipeTileControl(target);
                addFav.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);

                Recipe_Grid_Copy.Children.Add(addFav);
            }
            serializer.WriteRecipes(recipes);

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

        private void AddRecipe_AddButton_Click(object sender, MouseButtonEventArgs e)
        {
            List<Ingredient> rIngredients = new List<Ingredient>();
            List<Instruction> rInstructions = new List<Instruction>();

            foreach(RecipeInstructionControl i in InstructionList.Children)
            {
                Instruction newInstruction = new Instruction(i.StepInstruction.Text, i.PhotoFilepath.Text);
                rInstructions.Add(newInstruction);
            }

            foreach(IngredientInfoControl i in IngredientList.Children)
            {
                Ingredient newIngredient = new Ingredient();
                newIngredient.name = i.IngredientName.Text;
                newIngredient.measure = i.QuantitySelector.Text;
                double measure = Convert.ToDouble(i.IngredientQuantity);
                rIngredients.Add(newIngredient);
            }

            Recipe recipe = new Recipe(NameBox.Text, CategoryBox.Text, "pasta.jpg", rIngredients, rInstructions);
            RecipeTileControl addNew = new RecipeTileControl(recipe);
            addNew.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
            
            Recipe_Grid.Children.Add(addNew);
            recipes.Add(recipe);
            serializer.WriteRecipes(recipes);

        }

    }
}
