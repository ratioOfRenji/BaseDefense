namespace StarterAssets
{
    public class WinLevelState : BaseState
    {
        public delegate void WinLevelStage();
        public static event WinLevelStage OnEnterWinLevelStage;
        public override void EnterState(StateManager stateManager)
        {
            OnEnterWinLevelStage();
        }

        public override void UpdateState(StateManager stateManager)
        {
           
        }
    }
}