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

        [Bind("OnSetStartPos")]
        private void SetWorkerOnStartPosition()
        {
            var defaultPos = (Vector3)Model.Get("ToHome");

            Path
            .EasingLinear(2f, 0, 1, (f) => _worker.position = Vector3.Lerp(_worker.position, defaultPos, f));
        }

        [Bind("workerNextPlace")]
        private void GetNewDirection()
        {
            string direction = Settings.Model.GetString("workerDirection");

            Vector3 targetPosition = (Vector3)Settings.Model.Get(direction);

            PathToNextPlace(targetPosition);
        }

        private void PathToNextPlace(Vector2 target)
        {
            Path
            .EasingLinear(0.5f, 0, 1, (f) => _worker.position = Vector3.MoveTowards(_worker.position, target, 0.5f))
            .Action(() => Settings.Fsm.Change(Model.GetString("targetState")));  
        }
    }
}
