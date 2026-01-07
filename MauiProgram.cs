using Microsoft.Extensions.Logging;
using RecipeApp.Services;
using RecipeApp.ViewModels;
using RecipeApp.Views;

namespace RecipeApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<DatabaseService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddTransient<AddRecipePage>();//her açıldığında temiz sıfırdan gelsin diye transient kullanıyoz
		builder.Services.AddTransient<AddRecipeViewModel>();
		builder.Services.AddTransient<RecipeDetailPage>();
		builder.Services.AddTransient<RecipeDetailViewModel>();
		return builder.Build();
	}
}
