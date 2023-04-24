using AxGrid;
using AxGrid.Base;
using UnityEngine;

namespace TaskWorker
{
    public class WorkerPlace : MonoBehaviourExtBind
    {
        public string placeKey;
        [OnAwake]
        private void AddPositionsToModel()
        {
            Settings.Model.Set(placeKey, transform.position);
        }
    }
}
