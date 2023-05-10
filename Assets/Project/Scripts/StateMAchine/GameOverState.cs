namespace StarterAssets
{
    public class GameOverState : BaseState
    {
        public bool reload;
        public delegate void EnterFightStage();
        public static event EnterFightStage OnEnterGameOverStage;
        public override void EnterState(StateManager stateManager)
        {
            OnEnterGameOverStage();
        }

        public override void UpdateState(StateManager stateManager)
        {
            if (reload)
            {
                reload = false;
                stateManager.SwichState(stateManager.waitingState);
            }
        }
    }
}