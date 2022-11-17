using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Plants.Infrastructure.DBSettings;
using Plants.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Services.Services
{
    internal class UserService
    {
        private readonly IMongoCollection<Users> _users;

        public UserService(IOptions<PlantsDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);    
        }

    }
}
