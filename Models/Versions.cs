using Google.Cloud.Firestore;

namespace IdentityScan_Server.Models

{
    [FirestoreData]
    public class AppVersions 
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Versions { get; set; }

        [FirestoreProperty]
        public string Changes { get; set; }

        public AppVersions(){}
        

            public AppVersions(string Id , string Versions , string Changes)
            {
                Id = Id;
                Versions = Versions;
                Changes = Changes;

            }
            
        
    }
}