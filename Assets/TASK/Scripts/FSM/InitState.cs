using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TaskWorker
{
    [State(StateKeys.initState)]
    public class InitState : FSMState
    {
        private const int defaultCahsCount = 100;

        [Enter]
        private void EnterThis()
        {
            Settings.Model.EventManager.Invoke(EventKeys.workerToStartPos);

            Model.Set(ModelKeys.cash, defaultCahsCount);
        }
    }
}
