using Microsoft.Extensions.Options;
using MongoCrud.Data.DataAccess;
using MongoCrud.Data.Model;
using MongoDB.Driver;

namespace MongoCrud.Services
{
    public class MongoService
    {
        private readonly IMongoCollection<Funcionario> _collection;

        public MongoService(IOptions<StoreDatabaseSettings> StoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                StoreDatabaseSettings.Value.ConnectionString);
            var mongoDataBaser = mongoClient.GetDatabase(StoreDatabaseSettings.Value.DatabaseName);

            _collection = mongoDataBaser.GetCollection<Funcionario>(
                StoreDatabaseSettings.Value.FuncionarioCollectionName);
        }

        public async Task<List<Funcionario>> GetAll() =>
            await _collection.Find(_ => true).ToListAsync();
        public async Task<Funcionario> GetById(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Funcionario funcionaio) =>
            await _collection.InsertOneAsync(funcionaio);
        public async Task UpdateAsync(string id, Funcionario funcionario) =>
            await _collection.ReplaceOneAsync(x => x.Id == id,funcionario );
        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);  


    }
}
