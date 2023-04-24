using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TaskWorker
{
    [State("OnWork")]
    public class WorkState : FSMState
    {

        [Enter]
        private void EnterThis()
        {
            Settings.Invoke("ViewCurrentState", $"{Parent.CurrentStateName}");

            Model.Set("cash", 10);
            Model.EventManager.Invoke("cash", 10);
        }

        [Loop(1f)]
        private void LoopThis()
        {
            Model.Inc("cashCount", 1);
        }

        [Bind("sendWorker")]
        private void SendWorkerToNextPlace()
        {
            Settings.Fsm.Change("OnWayState");
        }
    }
}
