using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstraper BootstraperPrefab;
        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstraper>();

            if (bootstrapper == null)
                Instantiate(BootstraperPrefab);
        }
    }
}