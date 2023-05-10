using UnityEngine;
namespace StarterAssets
{
    public class RotationAround : MonoBehaviour
    {
        public float rotationSpeed = 1f;

        void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }
}