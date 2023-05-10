namespace StarterAssets
{
    public class WaitingState : BaseState
    {
        public bool fidhtAreaEntered;
        public delegate void EnterPrepStage();
        public static event EnterPrepStage OnEnterWaitStage;
        public override void EnterState(StateManager stateManager)
        {
            //stateManager._attackEnemies.enabled = false;
            foreach (ChasingEnemy enemy in stateManager._enemies)
            {
                enemy.agred = false;
            }
            OnEnterWaitStage();
        }

        public override void UpdateState(StateManager stateManager)
        {
            if (stateManager._playerTransform.position.z >= 3.6f)
            {
                stateManager.SwichState(stateManager.fightState);
            }
        }
    }
}