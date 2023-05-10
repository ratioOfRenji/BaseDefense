namespace StarterAssets
{
    public class PreparationState : BaseState
    {
        public delegate void EnterPrepStage();
        public static event EnterPrepStage OnEnterPrepStage;
        public bool playerIsReady;
        public override void EnterState(StateManager stateManager)
        {
            OnEnterPrepStage();
        }

        public override void UpdateState(StateManager stateManager)
        {
            if (playerIsReady)
            {
                stateManager.SwichState(stateManager.waitingState);
            }
        }
    }
}