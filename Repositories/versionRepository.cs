using Google.Cloud.Firestore;
using IdentityScan_Server.Models;
using System.Threading.Tasks;

namespace IdentityScan_Server.Repositories 

{
    public class VersionRepository
    {
        private readonly FirestoreDb _firestoreDb;

        public VersionRepository(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

         public async Task AddVersion(AppVersions version , string AppName = "IdentityScan")
        {
            DocumentReference docRef = _firestoreDb.Collection("AppVersions").Document(AppName);
            await docRef.SetAsync(version);
        }

        public async Task<AppVersions> GetAppVersion(string AppName = "IdentityScan")
        {
            DocumentReference docRef = _firestoreDb.Collection("AppVersions").Document(AppName);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if(snapshot.Exists){
                return snapshot.ConvertTo<AppVersions>();
            }
            return null;

        }
    }
}