﻿namespace MongoDBTesting.Models;

public class BookStoreDabaseSettings
{
    public string ConnectionString { get; set; } = null;
    public string DatabaseName { get; set; } = null;
    public string BooksCollectionName { get; set; } = null;
}
