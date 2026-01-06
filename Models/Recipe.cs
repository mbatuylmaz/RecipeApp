using SQLite;

//Bu kod sayesinde verilerimiz için veri şablonu(modeli) oluşturduk

namespace RecipeApp.Models;

public class Recipe
{
    [PrimaryKey, AutoIncrement] //Burayla ,SQLite desteği sayesinde, tabloya PK ve AutoIncrement özelliği sağladık
    public int Id { get; set; } //Bu get set ile bu veriyi get ile okuma. set ile veriyi değiştirme özelliği verdik. Field'dan property yapmış olduk bu sayede
    public string Title { get; set; } = string.Empty; //.NET 9 bu değişkenlerin başlangıçta boş olmamasını istiyormuş yoksa hata verdi çalıştırmadı
    public string Category { get; set; } = string.Empty;
    public string Ingredients { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}