namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task<byte[]> LoadDataFile<T>(string sql);
        Task SaveData<T>(string sql, T parameters);
        Task SaveDataFile<T>(string sql, T parameters);

    }
}