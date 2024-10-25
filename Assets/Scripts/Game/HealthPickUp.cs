using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game
{
    public class HealthPickUp : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _healAmount = 25;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerHealth health))
            {
                health.ChangeHealth(_healAmount);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}