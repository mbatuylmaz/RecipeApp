using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeApp.Models;
using RecipeApp.Services;
//MVVM yani Model-View-ViewModel kullandım. View yani arayüz ile veri mantığını yani ViewModel birbirinden ayırmak için.
//Model Recipe.cs yani veri modeli
//ViewModel Arayüz için verileri hazırlayan yer BU KOD OLUYOR
//View arayüz yani MainPage.xaml olacak
namespace RecipeApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    // Ekranda listelenecek tarifler koleksiyonu
    public ObservableCollection<Recipe> Recipes { get; } = new();

    public MainViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [RelayCommand]
    public async Task GetRecipes()
    {
        var recipes = await _databaseService.GetRecipesAsync();
        Recipes.Clear();
        foreach (var recipe in recipes)
        {
            Recipes.Add(recipe);
        }
    }
}