using System.Collections;
using UnityEngine;

namespace StarterAssets
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private IntValue _maxHp;
        [SerializeField]
        private IntValue _hp;
        [SerializeField]
        private FloatValue _initialPlayerSpeed;
        [SerializeField]
        private FloatValue _playerSpeed;
        bool knocked;
        Vector3 knockback;
        public float knockBackDuration = 1f;
        public float knockBackForce = 5f;
        public CharacterController controller;
        public ThirdPersonController thirdPersonController;
        Animator _playerAnimator;
        void Start()
        {
            _playerAnimator = GetComponent<Animator>();
            _hp.Value = _maxHp.Value;
            controller = GetComponent<CharacterController>();
            thirdPersonController = GetComponent<ThirdPersonController>();
            
        }
        private void OnEnable()
        {
            _playerSpeed.Value = _initialPlayerSpeed.Value;
        }
        private void OnDisable()
        {
            StopAllCoroutines();
            thirdPersonController.enabled = true;
            _hp.Value = _maxHp.Value;
            knocked = false;
            
        }
        void Update()
        {
            if (knocked)
            {
                controller.Move(knockback * Time.fixedDeltaTime);
            }

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Enemy>() != null && !knocked)
            {
                knocked = true;
                thirdPersonController.enabled = false;
                _playerAnimator.SetBool("Jump", true);
                Vector3 hitDIrection = transform.position - other.gameObject.transform.position;
                Hit(new Vector3(hitDIrection.x, 0, hitDIrection.z).normalized);
            }
        }

        private void Hit(Vector3 direction)
        {
            Vector3 knockBackDirection = (direction + new Vector3(0, 1.5f, 0)).normalized;
            knockback = direction * knockBackForce;

            StartCoroutine(KnockBackTimer());
            _hp.Value--;
        }
        IEnumerator KnockBackTimer()
        {
            yield return new WaitForSeconds(0.4f);
            knocked = false;
            thirdPersonController.enabled = true;
        }
    }
}