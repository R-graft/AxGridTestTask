using AxGrid;
using AxGrid.FSM;

namespace Test
{
    [State("StateTwo")]
    public class StateTwo : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Settings.Model.Set("count", 50);

            Settings.Model.EventManager.Invoke("NewStateEvent");
        }

        [Loop(2f)]
        private void LoopThis()
        {
            Settings.Model.Set("count", Settings.Model.GetInt("count") + 1);

            Settings.Model.EventManager.Invoke("NewStateEvent");
        }
    }
}
