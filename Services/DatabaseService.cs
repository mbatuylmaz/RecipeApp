using SQLite;
using RecipeApp.Models;

namespace RecipeApp.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection _database;

    async Task Init()
    {
        if (_database is not null)
            return;

        // Veri tabanı dosyasının macOS/iOS/Android'de nereye kaydedileceğini belirler
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Recipes.db3");

        _database = new SQLiteAsyncConnection(dbPath);
        await _database.CreateTableAsync<Recipe>();
    }

    public async Task<List<Recipe>> GetRecipesAsync()
    {
        await Init();
        return await _database.Table<Recipe>().ToListAsync();
    }

    public async Task<int> SaveRecipeAsync(Recipe recipe)
    {
        await Init();
        if (recipe.Id != 0)
            return await _database.UpdateAsync(recipe);
        else
            return await _database.InsertAsync(recipe);
    }

    public async Task<int> DeleteRecipeAsync(Recipe recipe)
    {
        await Init();
        return await _database.DeleteAsync(recipe);
    }
}