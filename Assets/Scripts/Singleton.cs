using UnityEngine;

namespace BeardTwins.TO
{
    public class Singleton<T>: MonoBehaviour where T : class, new()
    {
        static protected T instance = new T();

        static public T Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
