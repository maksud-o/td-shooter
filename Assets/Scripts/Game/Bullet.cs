using System.Collections;
using UnityEngine;

namespace TDS.Game
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _damage = 20;
        [SerializeField] private float _lifetime = 5f;
        [SerializeField] private float _speed = 25f;

        private Rigidbody2D _rb;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * _speed;

            StartCoroutine(DestroyAfterLifetime());
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Health health))
            {
                health.ChangeHealth(-_damage);
            }

            Destroy(gameObject);
        }

        #endregion

        #region Private methods

        private IEnumerator DestroyAfterLifetime()
        {
            yield return new WaitForSeconds(_lifetime);
            Destroy(gameObject);
        }

        #endregion
    }
}