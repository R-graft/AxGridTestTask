using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TaskWorker
{
    [State("InitState")]
    public class InitState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Settings.Model.EventManager.Invoke("OnSetStartPos");

            Parent.Change("OnHome");
        }
    }
}
