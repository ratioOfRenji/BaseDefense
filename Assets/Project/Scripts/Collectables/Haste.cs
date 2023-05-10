using System.Collections;
using UnityEngine;

namespace StarterAssets
{
    namespace StarterAssets
    {
        public class Haste : BaseCollectable
        {
            [SerializeField]
            private FloatValue _playerSpeed;
            [SerializeField]
            private FloatValue _initialPlayerSpeed;
            [SerializeField]
            private FloatValue _boostedPlayerSpeed;


            public override void ActivateBuff()
            {
                _playerSpeed.Value = _boostedPlayerSpeed.Value;
                StartCoroutine(stopHaste());
            }
            private IEnumerator stopHaste()
            {
                yield return new WaitForSeconds(5f);
                _playerSpeed.Value = _initialPlayerSpeed.Value;
                Destroy(this.gameObject);
            }

        }
    }
}