namespace MongoCrud.Data.DataAccess
{
    public class StoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string FuncionarioCollectionName { get; set; } = null!;
    }
}
