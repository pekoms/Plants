using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants.Infrastructure.DBSettings
{
    public class PlantsDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string UsersCollectionName { get; set; } = string.Empty;
        public string PlantsCollectionName { get; set; } = string.Empty;
        public string PlantsRecordsCollectionName { get; set; } = string.Empty;

    }
}
