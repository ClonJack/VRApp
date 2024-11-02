using UnityEngine;

namespace _Project.Code.Common.SimpleBehaviour
{
    public class DontDestroyBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objects;

        private void Awake()
        {
            foreach (GameObject obj in _objects) 
                DontDestroyOnLoad(obj);
        }
    }
}