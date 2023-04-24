using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TaskWorker
{
    [State("OnHome")]
    public class HomeState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Settings.Invoke("ViewCurrentState", $"{Parent.CurrentStateName}");
        }
    }
}
