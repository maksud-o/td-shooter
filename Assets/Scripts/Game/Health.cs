using UnityEngine;

namespace TDS.Game
{
    public abstract class Health : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected int HealthAmount;

        #endregion

        #region Public methods

        public void ChangeHealth(int damage)
        {
            HealthAmount += damage;
            if (HealthAmount <= 0)
            {
                Die();
            }
        }

        #endregion

        #region Protected methods

        protected abstract void Die();

        #endregion
    }
}