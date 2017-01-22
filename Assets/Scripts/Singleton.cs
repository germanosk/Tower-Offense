using UnityEngine;

namespace BeardTwins.TO
{
    public class Singleton<T>: MonoBehaviour where T : MonoBehaviour
    {
        static protected T instance;
        
        static public T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                }
                return instance;
            }
        }
    }
}
