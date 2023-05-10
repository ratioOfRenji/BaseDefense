using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace StarterAssets
{
    public class ButtonsMethods : MonoBehaviour
    {
        [SerializeField]
        GameObject _startLevelButtn;
        [SerializeField]
        GameObject _restartLevelButton;
        [SerializeField]
        StateManager _stateManager;
        [SerializeField]
        EnemySpawner _spawner;
        [SerializeField]
        Player _player;
        [SerializeField]
        private GameObject _winUi;
        [SerializeField]
        private TMP_Text _enemyCounter;
        [SerializeField]
        private IntValue _coins;
        [SerializeField]
        private TMP_Text _coinsText;
        [SerializeField]
        private IntValue _totalEnemiesToSpawn;
        [SerializeField]
        private IntValue _enemiesSpawned;
        [SerializeField]
        private IntValue _maxHp;
        [SerializeField]
        private IntValue _hp;
        [SerializeField]
        private IntValue _enemiesDefeated;
        private void OnEnable()
        {
            _enemiesSpawned.Value = 0;
            _enemiesDefeated.Value = 0;
            GameOverState.OnEnterGameOverStage += () => { _restartLevelButton.gameObject.SetActive(true); };
            WaitingState.OnEnterWaitStage += () => { _startLevelButtn.gameObject.SetActive(false); _restartLevelButton.gameObject.SetActive(false); _spawner.gameObject.SetActive(true); };
           PreparationState.OnEnterPrepStage += () => { _startLevelButtn.gameObject.SetActive(true);};
            WinLevelState.OnEnterWinLevelStage += () => { WinLevelAnimation(); };
        }
        private void OnDisable()
        {
            WaitingState.OnEnterWaitStage -= () => { _startLevelButtn.gameObject.SetActive(false); _restartLevelButton.gameObject.SetActive(false); _spawner.gameObject.SetActive(true); };
            PreparationState.OnEnterPrepStage -= () => { _startLevelButtn.gameObject.SetActive(true); _restartLevelButton.gameObject.SetActive(true); };
            WinLevelState.OnEnterWinLevelStage -= () => { WinLevelAnimation(); };
            _coins.Value = 0;
        }
        private void Update()
        {
            _enemyCounter.text = _enemiesDefeated.Value.ToString()+ "/"+ _totalEnemiesToSpawn.Value.ToString();
            _coinsText.text = _coins.Value.ToString();
        }
        public void StartLevel()
        {
            _stateManager.preparationState.playerIsReady = true;
        }
        public void RestartLevel()
        {
            _player.gameObject.transform.position = Vector3.zero;
            _player.gameObject.SetActive(true);
            _hp = _maxHp;
            _stateManager.gameOverState.reload = true;
        }

        public void WinLevelAnimation()
        {
            _winUi.SetActive(true);
            StartCoroutine(DisableWinUi());
        }
        IEnumerator DisableWinUi()
        {
            yield return new WaitForSeconds(2.3f);
            _winUi.SetActive(false);
        }
    }
}