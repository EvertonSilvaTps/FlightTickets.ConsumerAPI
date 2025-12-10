namespace FlightTickets.ConsumerAPI.Data
{
    public class MongoDbSettings
    {
        public string ConnectionURI { get; set; }
        public string DatabaseName { get; set; }
        public string ApprovedCollection { get; set; }
        public string DeniedCollection { get; set; }
    }
}
