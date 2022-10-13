using UnityEngine;
namespace Scripts.Utils.DesignPatterns { 
    public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
    {
        private Singleton<T> Instance;
        private void Awake()
        {
            if(Instance != null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
