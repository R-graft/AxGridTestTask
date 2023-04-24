using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Text;
using UnityEngine;

namespace TaskWorker
{
    [State(StateKeys.homeState)]
    public class HomeState : FSMState
    {
        [Enter]
        private void EnterThis()
        {
            Model.Set(ModelKeys.stateView, StateKeys.homeState);
        }
    }
}
