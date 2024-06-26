using Google.Cloud.Firestore;

namespace IdentityScan_Server.Models
{
    [FirestoreData]
    public class Identity
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Fullname { get; set; }

        [FirestoreProperty]
        public string Contacts { get; set; }

        [FirestoreProperty]
        public string Address { get; set; }

        [FirestoreProperty]
        public string Socials { get; set; }

        
        public Identity() { }

        public Identity(string id, string fullname, string contacts, string address, string socials)
        {
            Id = id;
            Fullname = fullname;
            Contacts = contacts;
            Address = address;
            Socials = socials;
        }
    }
}
