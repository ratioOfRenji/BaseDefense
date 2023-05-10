namespace StarterAssets
{
    public class FightState : BaseState
    {
        public delegate void EnterFightStage();
        public static event EnterFightStage OnEnterFightStage;

        public bool enemiesDefeated;
        public bool inArea;
        public int playerHealth;
        public override void EnterState(StateManager stateManager)
        {
            foreach(ChasingEnemy enemy in stateManager._enemies)
            {
                enemy.agred = true;
            }
            OnEnterFightStage();
        }

        public override void UpdateState(StateManager stateManager)
        {
            if (stateManager._playerTransform.position.z < 3.6f)
            {
                stateManager.SwichState(stateManager.waitingState);
            }
            if (stateManager._hp.Value <= 0)
            {
                stateManager.SwichState(stateManager.gameOverState);
                stateManager._player.SetActive(false);
                foreach (ChasingEnemy enemy in stateManager._enemies)
                {
                    enemy.movementUpdateTimer = 0;
                    enemy.agred = false;
                }

            }
            if (stateManager._enemiesSpawned.Value >= stateManager._totalEnemiesToSpawn.Value)
            {
                if (stateManager._enemyList.value.Count ==0)
                    stateManager.SwichState(stateManager.winLevelState);
            }

        }
    }
}