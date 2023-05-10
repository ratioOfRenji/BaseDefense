using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace StarterAssets
{
    public abstract class BaseCollectable : MonoBehaviour, IColletable
    {
        protected Transform startPosition;
        protected Player _player;
        protected Transform endPosition;
        protected float duration = 1f;
        protected float arcHeight = 1f;
        protected float updateInterval = 0.1f;
        protected Vector3 lastEndPosition;

        protected void Start()
        {
            startPosition = this.gameObject.transform;
        }
        protected void ReachedPlayer()
        {
            StopAllCoroutines();
            this.gameObject.transform.position = new Vector3(100, 100, 100);
            transform.DOKill();
            ActivateBuff();
        }
        public abstract void ActivateBuff();

        public virtual void GetCollected()
        {
            lastEndPosition = endPosition.position;
            StartCoroutine(UpdatePath());
        }

        protected IEnumerator UpdatePath()
        {
            while (true)
            {
                yield return new WaitForSeconds(updateInterval);

                if (endPosition.position != lastEndPosition)
                {
                    duration -= 0.05f;
                    Vector3 center = (startPosition.position + (endPosition.position + (Vector3.up * 1))) * 0.5f;
                    if (duration >= 0.5f)
                        center = new Vector3(center.x, center.y * 1.2f, center.z);

                    transform.DOKill();
                    transform.DOPath(new Vector3[] { startPosition.position, center, (endPosition.position + (Vector3.up * 1)) }, duration, PathType.CatmullRom)
                        .SetEase(Ease.Linear)
                        .OnComplete(() => ReachedPlayer());

                    lastEndPosition = endPosition.position;
                }
            }
        }

        protected void OnTriggerEnter(Collider other)
        {
            _player = other.GetComponent<Player>();
            if (_player != null)
            {
                endPosition = _player.gameObject.transform;
                GetCollected();
            }
        }
    }
}