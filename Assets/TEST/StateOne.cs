using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;

namespace Test
{
    [State("StateOne")]
    public class StateOne : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Settings.Model.Set("count", 12);

            Settings.Model.EventManager.Invoke("NewStateEvent");
        }

        [One(2f)]
        private void LoopThis()
        {
            Settings.Model.Set("count", 20);

            Settings.Model.EventManager.Invoke("NewStateEvent");
        }

        [Exit]
        private void ExitThis()
        {
            Settings.Model.Set("count", 25);

            Settings.Model.EventManager.Invoke("NewStateEvent");
        }
    }
}