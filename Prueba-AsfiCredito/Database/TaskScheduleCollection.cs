using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace Prueba_AsfiCredito.Database
{
    public class TaskScheduleCollection : ITaskScheduleCollection
    {

        internal MyDbContext dbContext = new MyDbContext();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        

        public async Task DeleteTask(String idClient, String idArea, String idActivity, String idDateTask)
        {
            await dbContext.Database.EnsureCreatedAsync();
            TaskSchedule filter = dbContext.TaskSchedules.Single(a=> a.IdClient == idClient & a.IdArea == idArea & a.IdActivity == idActivity & a.IdDateTask == idDateTask);
            try {
                dbContext.TaskSchedules.RemoveRange(filter);
                logger.Info("Info: The taskSchedule has been deleted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The taskSchedule could not be deleted, Error: " + e);
            }
        }

         public async Task<List<TaskSchedule>> getAllTasks()
         {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                List<TaskSchedule> taskSchedules = dbContext.TaskSchedules.ToList();

                taskSchedules.ForEach(e=>{
                    e.Client = dbContext.Clients.Single(a => a.Id == e.IdClient);
                e.Area = dbContext.Areas.Single(a => a.Id == e.IdArea);
                e.Activity = dbContext.Activities.Single(a => a.Id == e.IdActivity);
                e.DateTask = dbContext.DatesTask.Single(a => a.Id == e.IdDateTask);
                });

                Console.WriteLine("DateTask");

                logger.Info("Info: The taskSchedules have been obtained successfully");
                return taskSchedules;
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The taskSchedules could not be obtained successfully, Error: " + e);
                return null;
            }
        }

        public async Task InsertTask(TaskSchedule taskSchedule)
        {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                dbContext.Add<TaskSchedule>(taskSchedule);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The taskSchedule was inserted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: taskSchedule was not inserted, Error: " + e);
            }
        }

        public async Task UpdateTask(TaskSchedule taskSchedule)
        {
            await dbContext.Database.EnsureCreatedAsync();
            var filter = dbContext.TaskSchedules.Single(a=> a.IdClient == taskSchedule.IdClient & a.IdArea == taskSchedule.IdArea & a.IdActivity == taskSchedule.IdActivity & a.IdDateTask == taskSchedule.IdDateTask);
            try
            {
                dbContext.TaskSchedules.Update(taskSchedule);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The taskSchedule was updated");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The taskSchedule was not updated, Error: " + e);
            }
        }
    }
}
