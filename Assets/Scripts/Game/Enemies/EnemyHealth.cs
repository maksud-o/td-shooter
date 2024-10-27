using TDS.Game.Enemies.Base;
using TDS.Game.Enemies.Gunner;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyHealth : Health
    {
        #region Variables

        // private EnemyBehaviour[] behaviours;
        private GunnerAttack _attack;
        private Collider2D _collider;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _attack = GetComponent<GunnerAttack>();
            _collider = GetComponent<Collider2D>();
        }

        #endregion

        #region Protected methods

        protected override void Die()
        {
            // _gunnerAnimator.SetIsDead();

            _attack.enabled = false;
            _collider.enabled = false;
        }

        #endregion
    }
}