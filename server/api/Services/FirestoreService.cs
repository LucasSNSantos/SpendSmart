using api.Utility.Firestore;
using Google.Cloud.Firestore;
using System.Reflection;

namespace api.Services
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreService(IConfiguration configuration)
        {
            var projectId = configuration["GoogleCloud:ProjectId"]; ;
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<List<T>> GetAllDocumentsAsync<T>(string collectionName) where T : class
        {
            var collection = _firestoreDb.Collection(collectionName);
            var snapshot = await collection.GetSnapshotAsync();
            var list = snapshot.Documents.Select(doc => doc.ConvertTo<T>()).ToList();
            return list;
        }

        public async Task<List<T>> GetAllDocumentsAsync<T>() where T : class
        {
            var collectionName = typeof(T).GetCustomAttribute<CollectionNameAttribute>()
                ?? throw new NotImplementedException("This entity has not defined a Collection Name attribute!");
            var collection = _firestoreDb.Collection(collectionName.Name);
            var snapshot = await collection.GetSnapshotAsync();
            var list = snapshot.Documents.Select(doc => doc.ConvertTo<T>()).ToList();
            return list;
        }

        public async Task AddDocumentAsync<T>(string collectionName, T document) where T : class
        {
            var collection = _firestoreDb.Collection(collectionName);
            await collection.AddAsync(document);
        }

        public async Task AddDocumentAsync<T>(T document) where T : class
        {
            var collectionName = document.GetType().GetCustomAttribute<CollectionNameAttribute>() 
                ?? throw new NotImplementedException("This entity has not defined a Collection Name attribute!");
            var collection = _firestoreDb.Collection(collectionName.Name);
            await collection.AddAsync(document);
        }
    }
}
