using api.Utility.Firestore;
using Google.Cloud.Firestore;

namespace api.Entities
{
    [FirestoreData]
    [CollectionName("transaction")]
    public class UserTransaction
    {
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public DateTime PaymentDate { get; set; }

        public UserTransaction()
        {
            Description = string.Empty;
        }
    }
}
