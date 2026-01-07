using System.Collections.ObjectModel; // Liste işlemleri için
using CommunityToolkit.Mvvm.ComponentModel; // MVVM'in temel araçları için
using CommunityToolkit.Mvvm.Input; // Buton komutları için
using RecipeApp.Models;
using RecipeApp.Services;
//MVVM yani Model-View-ViewModel kullandım. View yani arayüz ile veri mantığını yani ViewModel birbirinden ayırmak için.
//Model Recipe.cs yani veri modeli
//ViewModel YANİ BU KOD, Arayüz için verileri hazırlayan yer.
//View arayüz yani MainPage.xaml olacak
namespace RecipeApp.ViewModels;

public partial class MainViewModel : ObservableObject //ObservableO ile bu sınıfta her veri değiştiğinde arayüz (xaml) kendini güncelliyor. partial ile kodların diğer kısmını (yani burdaki RelayCommand) kendi tamamlıyor commtoolkit kütüphanesi sayesinde. bundan partial yazıyoruz yazmazsak relaycommand çalışmaz
{
    private readonly DatabaseService _databaseService; // başka database olmasın okumasın diye readonly sabitliyor yani databasei değişmez. DatabaseService türü oluyo int gibi diğeri özel isim

    public ObservableCollection<Recipe> Recipes { get; } = new(); //Burası verilerin konulduğu bir Recipes adında koleksiyon liste görevi görüyor. list yerine observableC çünkü normal bir listeye veri eklersen ekran bunu fark etmiyo. ObservableC ise listeye bir şey eklendiği veya silindiği anda arayüzü (xaml) otomatik olarak yeniliyor. 

    public MainViewModel(DatabaseService databaseService) //MainViewModel yaratmak için bir databaseService'e erişiyor.
    {
        _databaseService = databaseService;
    }

    [RelayCommand] //arayüzdeki (XAML) bir butona basıldığında bu metod çalışıyor getrecipes. binding getrecipescommand
    public async Task GetRecipes()
    {
        var recipes = await _databaseService.GetRecipesAsync(); //DB'deki tüm tarifleri getir
        Recipes.Clear();//ekrandaki eski verileri temizle
        foreach (var recipe in recipes) //yeni gelen her bir tarifi tek tek ekrandaki listeye ekle
        {
            Recipes.Add(recipe);
        }
    }

    [RelayCommand] // arayüzdeki binding gotoaddrecipecommand
    public async Task GoToAddRecipe()
    {
        await Shell.Current.GoToAsync(nameof(Views.AddRecipePage));
    }

    [RelayCommand]//Binding GoToDetailsCommand
    public async Task GoToDetails(Recipe selectedRecipe) //binding selecteditem buraya geliyor
    {
        if (selectedRecipe == null) return;

        // Detay sayfasına git ve yanına seçilen tarifi de al!
        await Shell.Current.GoToAsync(nameof(Views.RecipeDetailPage), true, new Dictionary<string, object>
        {
            { "Recipe", selectedRecipe }
        });
        SelectedRecipe = null;//seçimi sıfırlama, bu sayede geri döndüğünde tekrar basabiliyorsun
    }
    [ObservableProperty]
    Recipe? selectedRecipe; // "?" koyuyoruz çünkü başta hiçbiri seçili olmuyor. binding selectedrecipe
}