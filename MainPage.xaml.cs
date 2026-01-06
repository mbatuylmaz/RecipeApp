namespace RecipeApp;

using RecipeApp.ViewModels;

public partial class MainPage : ContentPage
{
	// Constructor (Kurucu Metot)
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();

		// KRİTİK SATIR: Bu sayfanın verileri nereden alacağını bağlıyoruz.
		// Bu satır olmazsa XAML dosyan ViewModel'deki listeyi göremez.
		BindingContext = viewModel;
	}
}