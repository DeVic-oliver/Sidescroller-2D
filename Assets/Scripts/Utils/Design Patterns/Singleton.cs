using UnityEngine;
namespace Scripts.Utils.DesignPatterns { 
    public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
    {
        public static T Instance;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = GetComponent<T>();
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
