using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Path;
using AxGrid.Model;
using UnityEngine;

namespace TaskWorker
{
    [State(StateKeys.onWayState)]
    public class OnWayState : FSMState
    {
        private Transform _worker;

        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.stateView, StateKeys.onWayState);

            Model.Set(ModelKeys.enabledButton, false);
        }

        [One(0)]
        private void SendWorkerToTarget()
        {
            Model.EventManager.Invoke(EventKeys.workerNextPlace);
        }

        [Exit]
        private void ExitThis()
        {
            Model.Set(ModelKeys.enabledButton, true);
        }
    }
}
