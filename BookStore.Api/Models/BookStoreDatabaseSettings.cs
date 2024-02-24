namespace BookStore.Api.Models;

public class BookStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BooksCollectionName { get; set; } = null!;

    public List<DtabaseCollectionSetting> Collections { get; set; } = new List<DtabaseCollectionSetting>();
}

public class DtabaseCollectionSetting {
    public string EntityName { get; set; } = null!;
    public string DocumentName { get; set; } = null!;
}