using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_AsfiCredito.Database
{
    interface IActivityCollection
    {
        Task InsertActivity(Activity activity);
        Task UpdateActivity(Activity activity);
        Task DeleteActivity(String id);
        Task<List<Activity>> getAllActivities();
        Task InsertActivityTemporal();
    }
}
