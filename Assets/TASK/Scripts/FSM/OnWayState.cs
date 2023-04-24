using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Path;
using AxGrid.Model;
using UnityEngine;

namespace TaskWorker
{
    [State("OnWayState")]
    public class OnWayState : FSMState
    {
        private Transform _worker;

        [Enter]
        private void EnterThis()
        {
            Settings.Fsm.Invoke("ViewCurrentState", $"{Parent.CurrentStateName}");
        }

        [One(0)]
        private void SendWorker()
        {
            Settings.Model.EventManager.Invoke("workerNextPlace");
        }
    }
}
