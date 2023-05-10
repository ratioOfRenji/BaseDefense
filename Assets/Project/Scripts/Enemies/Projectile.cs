using System.Collections;
using UnityEngine;

namespace StarterAssets
{
    public class Projectile : MonoBehaviour
    {
        private void OnEnable()
        {
            StartCoroutine(Deactivate());
        }
        IEnumerator Deactivate()
        {
            yield return new WaitForSeconds(3);
            this.gameObject.SetActive(false);
        }
        void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.gameObject.SetActive(false);
                StopAllCoroutines();
                this.gameObject.SetActive(false);

            }
        }
    }
}