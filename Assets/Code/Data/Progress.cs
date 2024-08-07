using Firebase.Firestore;

namespace Code.Data
{
    [FirestoreData]
    public class Progress
    {
        private int _clickCount;
        private float _bestTime;

        [FirestoreProperty]
        public int ClickCount
        {
            get => _clickCount;
            set => _clickCount = value;
        }

        [FirestoreProperty]
        public float BestTime
        {
            get => _bestTime;
            set => _bestTime = value;
        }
    }
}