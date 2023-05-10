using UnityEngine;
using UnityEngine.AI;

namespace StarterAssets
{
    public class ChasingEnemy : Enemy
    {
        public NavMeshAgent agent;
        public Animator enemyAnimator;
        public float movingRadius = 15f;
        public float movementUpdateDuration = 3f;

        
        public bool agred;

        private Vector3 initialPosition;
        public float movementUpdateTimer;
        private Vector3 enemyAnimatorOriginalPosition;
        private Vector3 previousPosition;

        private Player _player;
        private Transform _playerTransform;
        
        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _playerTransform = _player.gameObject.GetComponent<Transform>();
            previousPosition = transform.position;
            enemyAnimatorOriginalPosition = enemyAnimator.transform.localPosition;
        }
        
        void Start()
        {
            initialPosition = transform.position;
            movementUpdateTimer = movementUpdateDuration;
            MoveAroundStart();
        }
        void Update()
        {
            if (agred)
            {
                SearchPlayer();
            }
            else
            {
                movementUpdateTimer -= Time.deltaTime;
                if (movementUpdateTimer <= 0)
                {
                    movementUpdateTimer = movementUpdateDuration;
                    MoveAroundStart();
                }
            }

           
            if (agent.velocity.magnitude > 0)
            {
                enemyAnimator.SetFloat("Forward", 0.6f);
            }
            if (Vector3.Distance(transform.position, previousPosition) < 0.003f)
            {
                enemyAnimator.SetFloat("Forward", 0.0f);
            }
            previousPosition = transform.position;
        }

        void LateUpdate()
        {
            enemyAnimator.transform.localPosition = enemyAnimatorOriginalPosition;
        }
        void MoveAroundStart()
        {
            agent.SetDestination(initialPosition + new Vector3(
                Random.Range(-movingRadius, movingRadius),
                0,
                Random.Range(-movingRadius, movingRadius)
                ));

        }
        void SearchPlayer()
        {
            agent.SetDestination(_playerTransform.transform.position);
        }
    }
}