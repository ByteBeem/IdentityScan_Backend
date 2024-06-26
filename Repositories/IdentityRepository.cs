using Google.Cloud.Firestore;
using IdentityScan_Server.Models;
using System.Threading.Tasks;

namespace IdentityScan_Server.Repositories
{
    public class IdentityRepository
    {
        private readonly FirestoreDb _firestoreDb;

        public IdentityRepository(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task AddIdentity(Identity identity)
        {
            DocumentReference docRef = _firestoreDb.Collection("identities").Document(identity.Id);
            await docRef.SetAsync(identity);
        }

        public async Task<Identity> GetIdentity(string id)
        {
            DocumentReference docRef = _firestoreDb.Collection("identities").Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Identity>();
            }
            return null;
        }
    }
}
