using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;

namespace TaskWorker
{
    [State("OnStore")]
    public class StoreState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Settings.Invoke("ViewCurrentState", $"{Parent.CurrentStateName}");
        }

        [Loop(1f)]
        private void LoopThis()
        {
            Model.Dec("cashCount", 1);
        }
    }
}
