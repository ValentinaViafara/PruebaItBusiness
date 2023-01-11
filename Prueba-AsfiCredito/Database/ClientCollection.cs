using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace Prueba_AsfiCredito.Database
{
    public class ClientCollection : IClientCollection
    {

        internal MyDbContext dbContext = new MyDbContext();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        

        public async Task DeleteClient(String id)
        {
            await dbContext.Database.EnsureCreatedAsync();
            Client filter = dbContext.Clients.Single(a=> a.Id == id);
            try {
                dbContext.Clients.RemoveRange(filter);
                logger.Info("Info: The client has been deleted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The client could not be deleted, Error: " + e);
            }
        }

         public async Task<List<Client>> getAllClientes()
         {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                List<Client> clients = dbContext.Clients.ToList();
                logger.Info("Info: The clients have been obtained successfully");
                return clients;
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The clients could not be obtained successfully, Error: " + e);
                return null;
            }
        }

         public async Task<Client> getClienteByEmailAndPassword(string email, string password)
         {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                Client client = dbContext.Clients.Where(a => a.Email == email & a.Password == password).First();
                logger.Info("Info: The client login was successful");
                return client;
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The client login was unsuccessful, Error: " + e);
                return null;
            }
         }

         public async Task<Client> getClienteByEmail(string email)
         {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                Client result = dbContext.Clients.Where(a => a.Email == email).First();
                logger.Info("Info: The client login was successful");
                return result;
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The client login was unsuccessful, Error: " + e);
                return null;
            }
         }

        public async Task InsertClient(Client client)
        {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                dbContext.Add<Client>(client);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The client was inserted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The client was not inserted, Error: " + e);
            }
        }

        public async Task UpdateClient(Client client)
        {
            await dbContext.Database.EnsureCreatedAsync();
            var filter = dbContext.Clients.Single(a=> a.Id == client.Id);
            try
            {
                dbContext.Clients.Update(client);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The client was updated");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The client was not updated, Error: " + e);
            }
        }
    }
}
