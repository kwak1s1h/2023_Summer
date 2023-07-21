using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdate
{
    public static class UpdateManager
    {
        class UpdateManagerInnerMonoBehaviour : MonoBehaviour
        {
            private void Update()
            {
                foreach(ManagedMover mover in _updateHashs)
                {
                    mover.UpdateManager_Update();
                }
            }
        }

        private static UpdateManagerInnerMonoBehaviour _innerBehaviour;
        private static HashSet<ManagedMover> _updateHashs = new HashSet<ManagedMover>();

        static UpdateManager()
        {
            GameObject obj = new GameObject();
            _innerBehaviour = obj.AddComponent<UpdateManagerInnerMonoBehaviour>();
        }

        public static void Add(ManagedMover mover)
        {
            _updateHashs.Add(mover);
        }

        public static void Remove(ManagedMover mover)
        {
            _updateHashs.Remove(mover);
        }
    }
}
