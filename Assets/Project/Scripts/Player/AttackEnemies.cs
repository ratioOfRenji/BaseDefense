using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class AttackEnemies : MonoBehaviour
    {

        [SerializeField]
        private GameObject _projectilePrefab;
        [SerializeField]
        private float projectileSpeed;
        [SerializeField]
        private EnemyList _enemies;
        [SerializeField]
        private Transform _bulletStartPos;
        [SerializeField]
        Enemy _closestEnemy;
        [SerializeField]
        private List<Projectile> _bulletsPool;
        private void OnEnable()
        {
            FightState.OnEnterFightStage += () => { StopAllCoroutines(); StartCoroutine(Shoot()); };
            WaitingState.OnEnterWaitStage += () => { StopAllCoroutines(); };
            GameOverState.OnEnterGameOverStage += () => { StopAllCoroutines(); };
        }
        IEnumerator Shoot()
        {
            ShootEnemy();
            float closestDistance = Mathf.Infinity;
            for (int i = 0; i < _enemies.value.Count; i++)
            {
                if (_enemies.value[i].gameObject.activeInHierarchy)
                {
                    float distance = Vector3.Distance(_enemies.value[i].transform.position, transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        _closestEnemy = _enemies.value[i];
                    }
                }

            }
            yield return new WaitForSeconds(2);
            StartCoroutine(Shoot());
            
        }
        private void ShootEnemy()
        {
            _closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            for (int i = 0; i < _enemies.value.Count; i++)
            {
                if (_enemies.value[i].gameObject.activeInHierarchy)
                {
                    float distance = Vector3.Distance(_enemies.value[i].transform.position, transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        _closestEnemy = _enemies.value[i];
                    }
                }

            }
            if (_closestEnemy != null)
            {
                Vector3 startPosition = new Vector3(_bulletStartPos.position.x, _bulletStartPos.position.y, _bulletStartPos.position.z);
                // create a new projectile GameObject
                GameObject projectile = Instantiate(_projectilePrefab, startPosition, Quaternion.identity);

                // calculate the direction to shoot in
                Vector3 direction = (_closestEnemy.transform.position - startPosition);
                Vector3 finDirection = new Vector3(direction.x, -0.2f, direction.z).normalized;

                // add a force to the projectile to make it move in that direction
                projectile.GetComponent<Rigidbody>().AddForce(finDirection * projectileSpeed, ForceMode.Impulse);
            }
        }
        private void OnDisable()
        {
            FightState.OnEnterFightStage -= () => { StartCoroutine(Shoot()); };
            WaitingState.OnEnterWaitStage -= () => { StopCoroutine(Shoot()); };
            GameOverState.OnEnterGameOverStage -= () => { StopAllCoroutines(); };
        }
    }
}