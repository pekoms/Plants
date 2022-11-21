using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Plants.Api.Services;
using Plants.Infrastructure.DBSettings;
using Plants.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Services.Services
{
    public class UserService:IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IOptions<PlantsDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _users = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<User>(options.Value.UsersCollectionName);
        }

        public async Task<List<User>> GetAllUsers() =>
            await _users.Find(_ => true).ToListAsync();
        public async Task<User> Get(string id) =>
            await _users.Find(m => m.Id == id).FirstOrDefaultAsync();
        public async Task Create(User newUser) =>
            await _users.InsertOneAsync(newUser);
        public async Task Update(string id, User updateUser) =>
            await _users.ReplaceOneAsync(m => m.Id == id, updateUser);
        public async Task Remove(string id) =>
            await _users.DeleteOneAsync(m => m.Id == id);

        
    }
}
