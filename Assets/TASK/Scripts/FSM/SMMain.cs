using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TaskWorker
{
    public class SMMain : MonoBehaviourExtBind
    {
        [OnAwake]
        private void AwakeThis()
        {
            Settings.Fsm = new FSM();

            Settings.Fsm.Add(new InitState());
            Settings.Fsm.Add(new OnWayState());
            Settings.Fsm.Add(new StoreState());
            Settings.Fsm.Add(new WorkState());
            Settings.Fsm.Add(new HomeState());
        }

        [OnStart]
        private void StartThis()
        {
            Settings.Fsm.Start("InitState");
        }

        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }

        [OnRefresh(0.1f)]
        private void RefreshThis()
        {
            Debug.Log(1);
        }

        [Bind("sendWorker")]
        private void SendWorkerToNextPlace(string direction, string state)
        {
            Model.Set("workerDirection", direction);
            Model.Set("targetState", state);
            Settings.Fsm.Change("OnWayState");
        }
    }
}
