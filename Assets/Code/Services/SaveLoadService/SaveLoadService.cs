using System.Threading.Tasks;
using Code.Data;
using Code.Services.ProgressService;
using Firebase.Firestore;

namespace Code.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private IProgressService _progressService;
        private FirebaseFirestore _firestore;

        public SaveLoadService(IProgressService progressService)
        {
            _progressService = progressService;
            _firestore = FirebaseFirestore.DefaultInstance;
        }

        public void SaveData()
            => _firestore.Document("save_data/data").SetAsync(_progressService.Progress);
        
        public async Task<Progress> LoadData()
            => await _firestore.Document("save_data/data").GetSnapshotAsync().ContinueWith(task => task.Result.ConvertTo<Progress>());
    }
}