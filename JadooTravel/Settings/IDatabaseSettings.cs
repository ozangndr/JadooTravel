namespace JadooTravel.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString          { get; set; }
        public string DatabaseName              { get; set; }
        public string CategoryCollectionName    { get; set; }
        public string DestinationCollectionName { get; set; }
        public string PartnerCollectionName { get; set; }
        public string ReservationCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string UserCollectionName { get; set; }
    }
}
