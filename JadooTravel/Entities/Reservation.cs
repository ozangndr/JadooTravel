using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravel.Entities
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReservationId {  get; set; }
        public string NameSurname {  get; set; }
        public string Email {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Description {  get; set; }


    }
}
