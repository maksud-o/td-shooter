using System;
using UnityEngine;

namespace TDS.Game
{
    public class Health : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _healthAmount;

        #endregion

        #region Events

        public event Action OnZeroHealth;

        #endregion

        #region Public methods

        public void ChangeHealth(int damage)
        {
            _healthAmount += damage;
            if (_healthAmount <= 0)
            {
                OnZeroHealth?.Invoke();
            }
        }

        #endregion
    }
}