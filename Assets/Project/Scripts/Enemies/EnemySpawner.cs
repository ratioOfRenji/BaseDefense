using System.Collections;
using UnityEngine;

namespace StarterAssets
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyList _enemiesPool;
        [SerializeField]
        private int initialSpawnAmmount;
        [SerializeField]
        private float SpawnDelay;
        [SerializeField]
        private IntValue _totalEnemisToSpawn;
        [SerializeField]
        private IntValue _enemiesSpawned;

        private void Awake()
        {
            _enemiesSpawned.Value = 0;
            _enemiesPool.value.Clear();
            Enemy[] temp = GetComponentsInChildren<Enemy>(true);
            for (int i = 0; i < temp.Length; i++)
            {
                _enemiesPool.value.Add(temp[i]);
            }
           
            for (int i = 0; i < initialSpawnAmmount; i++)
            {
                Spawn();
            }
        }
        private void OnEnable()
        {
            FightState.OnEnterFightStage += () => { StartCoroutine(SpawnEnemy()); };
            WaitingState.OnEnterWaitStage += () => { StopAllCoroutines(); };
            GameOverState.OnEnterGameOverStage += () => { StopAllCoroutines(); };
        }
        private void OnDisable()
        {
            FightState.OnEnterFightStage -= () => { StartCoroutine(SpawnEnemy()); };
            WaitingState.OnEnterWaitStage -= () => { StopAllCoroutines(); };
            GameOverState.OnEnterGameOverStage -= () => { StopAllCoroutines(); };
        }

        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(SpawnDelay);
            Spawn();
            StartCoroutine(SpawnEnemy());
        }

        private void Spawn()
        {
            if (_totalEnemisToSpawn.Value > _enemiesSpawned.Value)
            {
                for (int i = 0; i < _enemiesPool.value.Count; i++)
                {
                    if (!_enemiesPool.value[i].gameObject.activeInHierarchy)
                    {
                        float xPos = Random.Range(-5.5f, 2.91f);
                        float zPos = Random.Range(4, 28);
                        Vector3 spawnPos = new Vector3(xPos, 0.43f, zPos);
                        _enemiesPool.value[i].transform.position = spawnPos;
                        _enemiesPool.value[i].gameObject.SetActive(true);
                        _enemiesSpawned.Value++;
                        return;
                    }
                }

            }

        }
    }
}