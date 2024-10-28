using TDS.Architecture;
using UnityEngine;

namespace TDS.Game.Enemies.Base
{
    [RequireComponent(typeof(EnemyAttack))]
    public class EnemyAttackAggro : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        private EnemyAttack _attack;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _attack = GetComponent<EnemyAttack>();
            _attack.Deactivate();
        }

        private void OnEnable()
        {
            _triggerObserver.OnEnter += TriggerEnter2DCallback;
            _triggerObserver.OnExit += TriggerExit2DCallback;
        }

        private void OnDisable()
        {
            _triggerObserver.OnEnter -= TriggerEnter2DCallback;
            _triggerObserver.OnExit -= TriggerExit2DCallback;
        }

        #endregion

        #region Private methods

        private void TriggerEnter2DCallback(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER))
            {
                return;
            }

            _attack.Activate();
        }

        private void TriggerExit2DCallback(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER))
            {
                return;
            }

            _attack.Deactivate();
        }

        #endregion
    }
}