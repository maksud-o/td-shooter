using System.Collections;
using TDS.Architecture;
using TDS.Architecture.States;
using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Health), typeof(PlayerAttack), typeof(PlayerMovement))]
    public class PlayerDeath : Death
    {
        #region Variables

        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private float _restartDelay = 5f;

        private PlayerAttack _attack;
        private Health _health;
        private PlayerMovement _movement;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _attack = GetComponent<PlayerAttack>();
            _movement = GetComponent<PlayerMovement>();
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.OnZeroHealth += Die;
        }

        private void OnDisable()
        {
            _health.OnZeroHealth -= Die;
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