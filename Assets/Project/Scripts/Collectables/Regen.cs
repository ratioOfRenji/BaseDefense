using DG.Tweening;
using UnityEngine;

namespace StarterAssets
{
    public class Regen : BaseCollectable
    {
        [SerializeField]
        private IntValue _hp;
        [SerializeField]
        private IntValue _maxHp;




        public override void ActivateBuff()
        {
            StopAllCoroutines();
            this.gameObject.transform.position = new Vector3(100, 100, 100);
            transform.DOKill();
            if(_hp.Value< _maxHp.Value)
            {
                _hp.Value++;
            }
            Destroy(this.gameObject);
        }

    }
}
