using UnityEngine;

namespace Code.Infrastucture
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private Bootstrap _bootstrapPrefab;
        
        private void Awake()
        {
            Bootstrap bootstrap = FindObjectOfType<Bootstrap>();

            if (bootstrap == null)
                Instantiate(_bootstrapPrefab);
            
            DontDestroyOnLoad(this);
        }
    }
}