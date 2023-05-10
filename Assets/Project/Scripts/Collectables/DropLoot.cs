using UnityEngine;

namespace StarterAssets
{
    public class DropLoot : MonoBehaviour
    {
        [SerializeField]
        private GameObject coinPrefab;
        [SerializeField]
        private GameObject speedBuffPrefab;
        [SerializeField]
        private GameObject shieldPrefab;
        public void DropItem()
        {

            float rand = Random.value;
            if (rand < 0.5f) // 50% chance
            {
                return;
            }
            else if (rand >= 0.5f && rand < 0.8f) // 30% chance
            {
                Instantiate(coinPrefab, transform.position + Vector3.up, Quaternion.identity);
            }
            else if (rand >= 0.8f) // 20% chance
            {
                float rand2 = Random.value;
                if (rand2 < 0.5f)
                    Instantiate(speedBuffPrefab, transform.position + Vector3.up, Quaternion.identity);
                else
                    Instantiate(shieldPrefab, transform.position + Vector3.up, Quaternion.identity);
            }
        }
        private void OnDisable()
        {
            DropItem();
        }
    }
}