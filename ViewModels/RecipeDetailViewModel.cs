using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeApp.Models;
using RecipeApp.Services;
//Bu sayfa hangi tarife tıklandığında çıkacak olan sayfadaki bilgilerin görünmesi için
namespace RecipeApp.ViewModels;

// [QueryProperty]: Bu sayfa açılırken dışarıdan bir "Recipe" objesi geleceğini söyler.
[QueryProperty(nameof(Recipe), "Recipe")]
public partial class RecipeDetailViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;

    // Üzerine tıklanan tarifi burada tutacağız
    [ObservableProperty]
    Recipe recipe;

    public RecipeDetailViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [RelayCommand]
    public async Task DeleteRecipe()
    {
        // Silmeden önce basınca ,emin misin diye sormak
        bool answer = await Shell.Current.CurrentPage.DisplayAlert("Silme Onayı",
            $"{Recipe.Title} tarifini silmek istediğinize emin misiniz?", "Evet", "Hayır");

        if (answer)
        {
            // veri tabanından sil
            await _databaseService.DeleteRecipeAsync(Recipe);

            // bir önceki sayfaya geri dön
            await Shell.Current.GoToAsync("..");
        }
    }
}