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
    /// Interaction logic for IngredientPieceControl.xaml
    /// </summary>
    public partial class IngredientPieceControl : UserControl
    {
        Ingredient ingredient;
        public IngredientPieceControl(Ingredient ingredient)
        {
            this.ingredient = ingredient;
            InitializeComponent();
            this.IngredientName.Text = ingredient.name;
            this.IngredientQuantity.Text = ingredient.amount + "";
            this.IngredientMeasurement.Text = ingredient.measure;
        }
    }
}
