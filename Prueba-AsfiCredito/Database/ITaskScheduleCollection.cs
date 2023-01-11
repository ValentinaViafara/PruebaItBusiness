using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_AsfiCredito.Database
{
    interface ITaskScheduleCollection
    {
        Task InsertTask(TaskSchedule task);
        Task UpdateTask(TaskSchedule task);
        Task DeleteTask(String idClient, String idArea, String idActivity, String idDateTask);
        Task<List<TaskSchedule>> getAllTasks();
    }
}
