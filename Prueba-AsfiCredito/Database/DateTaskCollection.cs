using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace Prueba_AsfiCredito.Database
{
    public class DateTaskCollection : IDateTaskCollection
    {

        internal MyDbContext dbContext = new MyDbContext();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        

        public async Task DeleteDateTask(String id)
        {
            await dbContext.Database.EnsureCreatedAsync();
            DateTask filter = dbContext.DatesTask.Single(a=> a.Id == id);
            try {
                dbContext.DatesTask.RemoveRange(filter);
                logger.Info("Info: The dateTask has been deleted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The dateTask could not be deleted, Error: " + e);
            }
        }

         public async Task<List<DateTask>> getAllDatesTask()
         {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                List<DateTask> dateTasks = dbContext.DatesTask.ToList();
                logger.Info("Info: The dateTasks have been obtained successfully");
                return dateTasks;
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The dateTasks could not be obtained successfully, Error: " + e);
                return null;
            }
        }

        public async Task<DateTask> getByString()
         {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                DateTask dateTask = dbContext.DatesTask.Single();
                // DateTask dateTask = dbContext.DatesTask.Single(e => e.StringDate == time);
                logger.Info("Info: The dateTask have been obtained successfully");
                return dateTask;
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The dateTasks could not be obtained successfully, Error: " + e);
                return null;
            }
        }

        public async Task InsertDateTask(DateTask dateTask)
        {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                dbContext.Add<DateTask>(dateTask);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The dateTask was inserted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The dateTask was not inserted, Error: " + e);
            }
        }

        public async Task UpdateDateTask(DateTask dateTask)
        {
            await dbContext.Database.EnsureCreatedAsync();
            var filter = dbContext.DatesTask.Single(a=> a.Id == dateTask.Id);
            try
            {
                dbContext.DatesTask.Update(dateTask);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The dateTask was updated");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The dateTask was not updated, Error: " + e);
            }
        }

        public async Task InsertDateTaskTemporal()
        {
            try
            {
                var dates = DateOnly.FromDateTime(DateTime.Now);
                List<DateTask> dateTasks = new List<DateTask>(){
                    new DateTask(){StringDate= dates, Day= dates.Day, Month= dates.Month, Year= dates.Year, Enable= true},
                    new DateTask(){StringDate= dates.AddDays(1), Day= dates.AddDays(1).Day, Month= dates.AddDays(1).Month, Year= dates.AddDays(1).Year, Enable= true},
                    new DateTask(){StringDate= dates.AddDays(2), Day= dates.AddDays(2).Day, Month= dates.AddDays(2).Month, Year= dates.AddDays(2).Year, Enable= true},
                    new DateTask(){StringDate= dates.AddDays(3), Day= dates.AddDays(3).Day, Month= dates.AddDays(3).Month, Year= dates.AddDays(3).Year, Enable= true},
                    new DateTask(){StringDate= dates.AddDays(4), Day= dates.AddDays(4).Day, Month= dates.AddDays(4).Month, Year= dates.AddDays(4).Year, Enable= true},
                };
                await dbContext.Database.EnsureCreatedAsync();
                await dbContext.DatesTask.AddRangeAsync(dateTasks);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The area was inserted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The area was not inserted, Error: " + e);
            }
        }
    }
}
