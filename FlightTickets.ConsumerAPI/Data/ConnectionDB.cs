using FlightTickets.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlightTickets.ConsumerAPI.Data
{
    public class ConnectionDB
    {
        private readonly IMongoCollection<Ticket> TicketApprovedCollection;
        private readonly IMongoCollection<Ticket> TicketDeniedCollection;


        public ConnectionDB(IOptions<MongoDbSettings> mongoDbSettings)
        {
            MongoClient client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            TicketApprovedCollection = database.GetCollection<Ticket>(mongoDbSettings.Value.ApprovedCollection);
            TicketDeniedCollection = database.GetCollection<Ticket>(mongoDbSettings.Value.DeniedCollection);
        }


        public IMongoCollection<Ticket> GetMongoApprovedCollection()
        {
            return TicketApprovedCollection;

        }

        public IMongoCollection<Ticket> GetMongoDeniedCollection()
        {
            return TicketDeniedCollection;
        }

    }
}
