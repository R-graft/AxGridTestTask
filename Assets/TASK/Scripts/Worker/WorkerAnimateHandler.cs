using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;

namespace TaskWorker
{
    public class WorkerAnimateHandler : MonoBehaviourExtBind
    {
        [SerializeField] private Transform _worker;

        public float WorkerPathDuration = 1;

        [Bind(EventKeys.workerToStartPos)]
        private void SetWorkerOnStartPosition()
        {
            _worker.position = Vector3.zero;
        }

        [Bind(EventKeys.workerNextPlace)]
        private void GetNewDirection()
        {
            string direction = Settings.Model.GetString(ModelKeys.workerDirection);

            Vector3 targetPosition = (Vector3)Settings.Model.Get(direction);

            PathToNextPlace(targetPosition);
        }

        private void PathToNextPlace(Vector2 target)
        {
            Path
            .EasingLinear(WorkerPathDuration, 0, 1, (f) => _worker.position = Vector3.MoveTowards(_worker.position, target, WorkerPathDuration / 2))
            .Action(() => Settings.Fsm.Change(Model.GetString(ModelKeys.targetState))).Action(()=> print(1)); 
        }
    }
}
