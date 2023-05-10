using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class StateManager : MonoBehaviour
    {
        BaseState currentState;

        public WaitingState waitingState = new WaitingState();
        public PreparationState preparationState = new PreparationState();
        public FightState fightState = new FightState();
        public GameOverState gameOverState = new GameOverState();
        public WinLevelState winLevelState = new WinLevelState();


        public List<ChasingEnemy> _enemies;
        public Transform _playerTransform;
        public GameObject _player;
        public EnemyList _enemyList;

        public IntValue _totalEnemiesToSpawn;
        public IntValue _enemiesSpawned;
        public IntValue _hp;
        public IntValue _maxHp;
    void Start()
        {
            currentState = preparationState;
            currentState.EnterState(this);
        }


        void Update()
        {
            currentState.UpdateState(this);
        }

        public void SwichState(BaseState state)
        {
            currentState = state;
            state.EnterState(this);
        }
    }
}