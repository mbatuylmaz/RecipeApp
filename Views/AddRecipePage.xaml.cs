using RecipeApp.ViewModels;

namespace RecipeApp.Views;


public partial class AddRecipePage : ContentPage
{
    public AddRecipePage(AddRecipeViewModel viewModel)
    {
        InitializeComponent();//Bu satır XAML tasarımını yükleyen koddur.

        // Sayfanın veri kaynağını (ViewModel) bağlıyoruz
        BindingContext = viewModel;
    }
}