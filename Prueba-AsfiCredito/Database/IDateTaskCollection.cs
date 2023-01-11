using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_AsfiCredito.Database
{
    interface IDateTaskCollection
    {
        Task InsertDateTask(DateTask client);
        Task UpdateDateTask(DateTask client);
        Task DeleteDateTask(String id);
        Task<List<DateTask>> getAllDatesTask();
        Task<DateTask> getByString();
        // Task<DateTask> getByString(DateOnly time);
        Task InsertDateTaskTemporal();
    }
}
