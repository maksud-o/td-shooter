using System.Collections;
using TDS.Architecture;
using TDS.Architecture.States;
using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(PlayerAttack), typeof(PlayerMovement))]
    public class PlayerHealth : Health
    {
        #region Variables

        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private float _restartDelay = 5f;

        private PlayerAttack _attack;
        private PlayerMovement _movement;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _attack = GetComponent<PlayerAttack>();
            _movement = GetComponent<PlayerMovement>();
        }

        #endregion

        #region Protected methods

        protected override void Die()
        {
            _playerAnimator.SetIsDead();

            _attack.enabled = false;
            _movement.enabled = false;

            StartCoroutine(RestartDelay());
        }

        #endregion

        #region Private methods

        private IEnumerator RestartDelay()
        {
            yield return new WaitForSeconds(_restartDelay);
            ServiceLocator.Instance.Get<StateMachine>().Enter<GameOverState>();
        }

        #endregion
    }
}