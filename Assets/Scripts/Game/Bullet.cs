using System.Collections;
using UnityEngine;

namespace TDS.Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        #region Variables

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