using DG.Tweening;
using UnityEngine;

namespace StarterAssets
{
    public class Coin : BaseCollectable
    {
        [SerializeField]
        private IntValue _coins;

        
        public override void ActivateBuff()
        {
            StopAllCoroutines();
            this.gameObject.transform.position = new Vector3(100, 100, 100);
            transform.DOKill();
            _coins.Value++;
        }
        
    }
}