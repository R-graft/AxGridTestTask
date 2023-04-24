using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class StateMain : MonoBehaviourExtBind
    {
        [SerializeField] private Text _interface;

        private string currentText;

        private int currentCount;

        [OnAwake]
        private void AwakeMain()
        {
            currentText = "StateMain Awake";

            Settings.Fsm = new FSM();

            Settings.Fsm.Add(new StateOne());

            Settings.Fsm.Add(new StateTwo());
        }

        [OnStart]
        private void StartThis()
        {
            Settings.Fsm.Start("StateOne");
        }

        [OnRefresh(1f)]
        private void Refresh()
        {
            currentText = currentCount.ToString();
            _interface.text = currentText;
        }

        [OnDelay(5f)]
        private void Delay()
        {
            Settings.Fsm.Change("StateTwo");
        }

        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }

        [Bind("NewStateEvent")]
        private void BindEventTwo()
        {
            currentCount = Settings.Model.GetInt("count");
        }
    }
}