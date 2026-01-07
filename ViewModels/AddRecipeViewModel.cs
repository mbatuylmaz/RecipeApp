using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeApp.Models;
using RecipeApp.Services;
//Bu kod yeni tarif Ekrana yeni tarif girdiğimizde DB ye ekleyen koddur.
namespace RecipeApp.ViewModels;

public partial class AddRecipeViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    // Formdaki her bir kutucuk için bir "ObservableProperty" tanımladım.
    // [ObservableProperty] etiketi sayesinde kutuya bir şey yazdığında ViewModel bunu hemen anlıyor.
    [ObservableProperty] string title = string.Empty;
    [ObservableProperty] string category = string.Empty;
    [ObservableProperty] string ingredients = string.Empty;
    [ObservableProperty] string instructions = string.Empty;

    public AddRecipeViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [RelayCommand]
    public async Task SaveRecipe()
    {
        // Yukardaki kutucklardakş bilgileri alıp yeni bir newRecipe objesi oluşturuyoruz
        var newRecipe = new Recipe
        {
            Title = Title,
            Category = Category,
            Ingredients = Ingredients,
            Instructions = Instructions
        };

        // DatabaseService e gidip Bu newRecipe'yi  Tabloya eklettiriyoruz.
        await _databaseService.SaveRecipeAsync(newRecipe);

        // Kaydedince anasayfaya geri dönüyoruz.
        await Shell.Current.GoToAsync("..");
    }
}