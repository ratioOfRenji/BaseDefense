using UnityEngine;
using UnityEngine.UI;
namespace StarterAssets
{
    public class HpUi : MonoBehaviour
    {
        Camera mainCamera;
        [SerializeField]
        private Image fill;
        [SerializeField]
        private IntValue _maxHp;
        [SerializeField]
        private IntValue _hp;
        private float previousHealthValue;
        void Start()
        {
            mainCamera = Camera.main;
            previousHealthValue = _hp.Value;
        }

        public void UpdateHealthUi(float maxHelth, float health)
        {
            fill.fillAmount = health / maxHelth;
        }
        void LateUpdate()
        {
            if (previousHealthValue != _hp.Value)
            {
                UpdateHealthUi(_maxHp.Value, _hp.Value);
                previousHealthValue = _hp.Value;
            }
            transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);

        }
    }
}