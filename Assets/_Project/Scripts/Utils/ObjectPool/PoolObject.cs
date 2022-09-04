using System;
using UnityEngine;

namespace Game.Helpers
{
    public class PoolObject : MonoBehaviour, IPoolable<PoolObject>
    {
        private Action<PoolObject> _returnAction;
        private void OnDisable()
        {
            ReturnToPool();
        }

        public void Initialize(Action<PoolObject> returnAction) => _returnAction = returnAction;
        public void ReturnToPool() => _returnAction?.Invoke(this);
    }
}