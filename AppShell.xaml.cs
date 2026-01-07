namespace RecipeApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.AddRecipePage), typeof(Views.AddRecipePage)); // Bununla sayfanın ismini ve hangi sınıf olduğunu eşleştiriyoruz
		Routing.RegisterRoute(nameof(Views.RecipeDetailPage), typeof(Views.RecipeDetailPage));
	}
}
