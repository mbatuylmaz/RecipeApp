using SQLite;
using RecipeApp.Models;
//Bu kod sayesinde veriyi kaydedecek yeri yani DB'yi ve verileri listeleme kaydetme silme ekleme güncelleme yöntemlerini yazıp kazanıyoruz.
//Kısacası veri tabanı oluşturma ve yönetme kodu burası. Veri tabanı yöneticisi
namespace RecipeApp.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection _database;

    async Task Init() // veritabanına herhangi bir şey sormak veya değiştirmek için bu metodu kullanıyoruz. initialize başlat hazırla gibi bişi
    {
        if (_database is not null) // db varsa hali hazırda bitir diyoruz ve alttaki kısımla yeni db oluşturmuyoruz hafızaya
            return;

        // Veri tabanı dosyasının macOS/iOS/Android'de nereye kaydedileceğini belirler
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Recipes.db3");

        _database = new SQLiteAsyncConnection(dbPath); //_database variable'ını oluşturduğumuz db ye eşitliyoruz
        await _database.CreateTableAsync<Recipe>(); //Recipe model şablonuna uygun tablo oluştur
    }

    public async Task<List<Recipe>> GetRecipesAsync()
    {
        await Init();
        return await _database.Table<Recipe>().ToListAsync(); //tabloyu liste olarak çekme için kullanıyoruz
    }

    public async Task<int> SaveRecipeAsync(Recipe recipe) // ilk büyük R 'li Recipe vereceğim verinin şablonu Recipe şablonu olacak diyorum, ikinci küçük r olan recipe verdiğim veri oluyor. recipler'in ilki vereceğim verinin şablonu 2.si vereceğim veri oluyor yani.
    {
        await Init();
        if (recipe.Id != 0) // eğer fonksiyonda recipe verisinin Id si 0 dan farklıysa yani mevcutsa recipe(yani yeni verilen veri) ile update ediyoruz o veriyi
            return await _database.UpdateAsync(recipe);
        else
            return await _database.InsertAsync(recipe);//eğer recipe nin id'si 0 'sa yani tablomuzda mevcut değilse yeni id oluşturup insert ettiriyoruz bu recipe verisini.
    }

    public async Task<int> DeleteRecipeAsync(Recipe recipe)
    {
        await Init();
        return await _database.DeleteAsync(recipe);// tablodan verdiğimi recipe verisini silmek için kullanıyoruz.
    }
}