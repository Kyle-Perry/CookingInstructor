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
using System.Windows.Forms;
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
        public int instructionIndex;
        public Brush background;
        public Brush foreground;

        public MainWindow()
        {
            recipes = null;
            serializer = new Serializer("recipes.xml");
            target = null;
            instructionIndex = 0;
            InitializeComponent();
            recipes = serializer.Read();
            if (recipes == null)
            {
                recipes = new List<Recipe>();
                for (int i = 1; i <= 10; i++)
                {
                    Recipe recipe = new Recipe("Pasta " + i, "Main", "pasta.jpg", new List<Ingredient>(), new List<Instruction>());
                    recipe.ingredients.Add(new Ingredient("Tomato Sauce", "ml", 1000));
                    recipe.ingredients.Add(new Ingredient("Pasta", "g", 200));
                    recipe.instructions.Add(new Instruction("Boil tomato sauce.", "boilSauce.jpg"));
                    recipe.instructions.Add(new Instruction("Boil pasta after water has been boiled.", "boilPasta.jpg"));
                    recipe.instructions.Add(new Instruction("Put pasta on plate and pour sauce over it. Serve Hot.", "pasta.jpg"));
                    RecipeTileControl a = new RecipeTileControl(recipe);
                    recipes.Add(recipe);
                    a.Recipe_Image.BeginInit();
                    a.Recipe_Image.Source = LoadImage(recipe.photoPath);
                    a.Recipe_Image.EndInit();

                    Recipe_Grid.Children.Add(a);

                    a.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);

                }
            }
            else
            {
                foreach (Recipe recipe in recipes)
                {
                    RecipeTileControl a = new RecipeTileControl(recipe);

                    a.Recipe_Image.BeginInit();
                    a.Recipe_Image.Source = LoadImage(recipe.photoPath);
                    a.Recipe_Image.EndInit();

                    Recipe_Grid.Children.Add(a);

                    a.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
                    if (recipe.isFavorite)
                    {
                        RecipeTileControl b = new RecipeTileControl(recipe);
                        b.Recipe_Image.BeginInit();
                        b.Recipe_Image.Source = LoadImage(recipe.photoPath);
                        b.Recipe_Image.EndInit();
                        Recipe_Grid_Copy.Children.Add(b);

                        b.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
                    }

                }
            }

            background = AddToFav_Button.Background;
            foreground = AddToFav_Button.Foreground;

            HomePage_Grid.Visibility = Visibility.Visible;
            last = HomePage_Grid;
            Favorites_Grid.Visibility = Visibility.Hidden;
            AddRecipe_Grid.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
            StepGrid.Visibility = Visibility.Hidden;
            Search_Grid.Visibility = Visibility.Hidden;

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
            LoadRecipe(target);
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

            var confirmResult = System.Windows.Forms.MessageBox.Show("Leave without saving progress?",
                                     "Exiting Add Recipe",
                                     MessageBoxButtons.YesNoCancel);
            if (confirmResult == System.Windows.Forms.DialogResult.Yes)
            {
                AddRecipe_Grid.Visibility = Visibility.Hidden;
                HomePage_Grid.Visibility = Visibility.Visible;
                last = HomePage_Grid;


                NameBox.Text = "";
                CategoryBox.Text = "";
                IngredientList.Children.Clear();
                InstructionList.Children.Clear();
            }
            else if (confirmResult == System.Windows.Forms.DialogResult.No)
            {
                AddRecipe_Grid.Visibility = Visibility.Hidden;
                HomePage_Grid.Visibility = Visibility.Visible;
                last = HomePage_Grid;
            }
        }

        private void StartCooking_Click(object sender, MouseButtonEventArgs e)
        {
            StepGrid.Visibility = Visibility.Visible;
            ViewRecipe_Grid.Visibility = Visibility.Hidden;
            StepDescription.Text = target.instructions.ElementAt(instructionIndex).info;
            StepNumber.Text = "Step " + (instructionIndex + 1) + " of " + target.instructions.Count;
            BackArrow.Visibility = Visibility.Hidden;
            ForwardArrow.Visibility = Visibility.Visible;
            StepHelperImage.Source = LoadImage(target.instructions[0].photoPath);
            if (target.instructions.Count == 1)
            {
                ForwardArrow.Visibility = Visibility.Hidden;
            }
        }

        private void ForwardArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            instructionIndex++;
            StepDescription.Text = target.instructions.ElementAt(instructionIndex).info;
            StepNumber.Text = "Step " + (instructionIndex + 1) + " of " + target.instructions.Count;
            StepHelperImage.Source = LoadImage(target.instructions[instructionIndex].photoPath);

            if (target.instructions.Count > (instructionIndex + 1))
            {
                ForwardArrow.Visibility = Visibility.Visible;
            }
            else
            {
                ForwardArrow.Visibility = Visibility.Hidden;
            }
            if (instructionIndex > 0)
            {
                BackArrow.Visibility = Visibility.Visible;
            }
            else
            {
                BackArrow.Visibility = Visibility.Hidden;
            }
        }

        private void BackArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            instructionIndex--;
            StepDescription.Text = target.instructions.ElementAt(instructionIndex).info;
            StepNumber.Text = "Step " + (instructionIndex + 1) + " of " + target.instructions.Count;
            StepHelperImage.Source = LoadImage(target.instructions[instructionIndex].photoPath);

            if (target.instructions.Count > (instructionIndex + 1))
            {
                ForwardArrow.Visibility = Visibility.Visible;
            }
            else
            {
                ForwardArrow.Visibility = Visibility.Hidden;
            }
            if (instructionIndex > 0)
            {
                BackArrow.Visibility = Visibility.Visible;
            }
            else
            {
                BackArrow.Visibility = Visibility.Hidden;
            }
        }

        private void StopCooking_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StepGrid.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Visible;
            instructionIndex = 0;
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
            Search_Scroller_Grid.Children.Clear();
            last = HomePage_Grid;
        }

        private void SearchButton_Press(object sender, MouseButtonEventArgs e)
        {
            Search_Grid.Visibility = Visibility.Visible;
            HomePage_Grid.Visibility = Visibility.Hidden;
            this.Search.Text = "Search results for \"" + Search_Box.Text + "\"";
            foreach (Recipe recipe in recipes)
            {
                if (!Search_Box.Text.Equals(""))
                {
                    if (recipe.recipeName.IndexOf(Search_Box.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        RecipeTileControl c = new RecipeTileControl(recipe);
                        Search_Scroller_Grid.Children.Add(c);
                        c.Recipe_Image.BeginInit();
                        c.Recipe_Image.Source = LoadImage(recipe.photoPath);
                        c.Recipe_Image.EndInit();
                        c.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
                    }
                }
            }
            Search_Box.Text = "";
            last = Search_Grid;
        }

        private void AddToFav_Button_Click(object sender, RoutedEventArgs e)
        {
            if (target.isFavorite == false)
            {
                AddToFav_Button.Foreground = background;
                AddToFav_Button.Background = foreground;
                target.isFavorite = true;
                RecipeTileControl addFav = new RecipeTileControl(target);
                addFav.Recipe_Image.BeginInit();
                addFav.Recipe_Image.Source = LoadImage(target.photoPath);
                addFav.Recipe_Image.EndInit();
                addFav.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
                Recipe_Grid_Copy.Children.Add(addFav);
            }
            else
            {
                target.isFavorite = false;
                foreach (RecipeTileControl tile in Recipe_Grid_Copy.Children)
                {
                    if (tile.recipe == target)
                    {
                        Recipe_Grid_Copy.Children.Remove(tile);
                        break;
                    }
                }
                AddToFav_Button.Foreground = foreground;
                AddToFav_Button.Background = background;
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
            bool hasBadIngredient = false;
            try
            {
                Recipe recipe = new Recipe(NameBox.Text, CategoryBox.Text, "pasta.jpg", new List<Ingredient>(), new List<Instruction>());
                for (int i = 0; i < IngredientList.Children.Count; i++)
                {
                    try
                    {
                        IngredientInfoControl ing = (IngredientInfoControl)IngredientList.Children[i];
                        recipe.ingredients.Add(new Ingredient(ing.IngredientName.Text, ing.QuantitySelector.Text, Convert.ToDouble(ing.IngredientQuantity.Text)));
                        ing.IngredientQuantity.Background = new SolidColorBrush(Colors.White);
                    }
                    catch(FormatException badIngredient)
                    {
                        Console.WriteLine(badIngredient);
                        IngredientInfoControl bad = (IngredientInfoControl)IngredientList.Children[i];
                        bad.IngredientQuantity.Background = new SolidColorBrush(Colors.Pink);
                        hasBadIngredient = true;
                    }

                }
                if (hasBadIngredient) throw (new FormatException());
                for (int i = 0; i < InstructionList.Children.Count; i++)
                {
                    RecipeInstructionControl rec = (RecipeInstructionControl)InstructionList.Children[i];
                    recipe.instructions.Add(new Instruction(rec.StepInstruction.Text, rec.PhotoFilepath.Text));
                }
                RecipeTileControl a = new RecipeTileControl(recipe);
                a.Recipe_Image.Source = LoadImage(recipe.photoPath);
                recipes.Add(recipe);
                Recipe_Grid.Children.Add(a);

                a.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
                NameBox.Text = "";
                CategoryBox.Text = "";
                InstructionList.Children.Clear();
                IngredientList.Children.Clear();

                HomePage_Grid.Visibility = Visibility.Visible;
                AddRecipe_Grid.Visibility = Visibility.Hidden;
                last = HomePage_Grid;
                serializer.WriteRecipes(recipes);
            }
            catch(FormatException exception)
            {
                System.Windows.Forms.MessageBox.Show("One or more ingredients has an invalid value","Add Recipe Error", MessageBoxButtons.OK);
                Console.WriteLine(exception);
            }
        }

        private void Random_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Random rnd = new Random();
            Recipe ranRecipe = recipes[rnd.Next(0, recipes.Count)];
            LoadRecipe(ranRecipe);
        }

        private void LoadRecipe(Recipe aRecipe)
        {
            target = aRecipe;
            if (target.isFavorite == true)
            {
                AddToFav_Button.Foreground = background;
                AddToFav_Button.Background = foreground;
            }
            else
            {
                AddToFav_Button.Foreground = foreground;
                AddToFav_Button.Background = background;
            }
            RecipePhoto.Source = LoadImage(target.photoPath);
            RecipeName.Text = target.recipeName;
            RecipeInstructionList1.Text = "";
            IngredientsList.Children.Clear();
            foreach (Ingredient ingredient in target.ingredients)
            {
                IngredientPieceControl piece = new IngredientPieceControl(ingredient);
                IngredientsList.Children.Add(piece);
            }
            int i = 1;
            foreach (Instruction instruction in target.instructions)
            {
                RecipeInstructionList1.Text += i + ".) " + instruction.info + "\n";
                i++;
            }
            HomePage_Grid.Visibility = Visibility.Hidden;
            ViewRecipe_Grid.Visibility = Visibility.Visible;
            Favorites_Grid.Visibility = Visibility.Hidden;
            Search_Grid.Visibility = Visibility.Hidden;
        }

        public BitmapImage LoadImage(string filepath)
        {

            if (filepath != null)
            {
                try
                {
                    BitmapImage src = new BitmapImage();
                    FileStream imgSrc = new FileStream(filepath, FileMode.Open, FileAccess.Read);

                    src.BeginInit();
                    src.StreamSource = imgSrc;

                    //Uri imgSrc = new Uri(filepath, UriKind.Absolute);
                    //src.UriSource = imgSrc;

                    src.CacheOption = BitmapCacheOption.OnLoad;
                    src.EndInit();
                    
                    src.Freeze();

                    return src;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return new BitmapImage();
                }

            }
            return new BitmapImage();
        }
    }
}
