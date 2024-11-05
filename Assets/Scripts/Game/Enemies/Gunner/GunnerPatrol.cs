using System.Collections;
using System.Linq;
using TDS.Game.Enemies.Base;
using UnityEngine;

namespace TDS.Game.Enemies.Gunner
{
    [RequireComponent(typeof(EnemyMovement))]
    public class GunnerPatrol : EnemyIdle
    {
        #region Variables

        [SerializeField] private float _pauseBetweenPoints = 3f;
        [SerializeField] private Transform[] _patrolPoints;

        private EnemyMovement _movement;
        private Coroutine _patrolCoroutine;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
        }

        private void OnEnable()
        {
            _patrolCoroutine = StartCoroutine(Patrol());
            _movement.Activate();
        }

        private void OnDisable()
        {
            StopCoroutine(_patrolCoroutine);
            _movement.SetTarget(null);
            _movement.Deactivate();
        }

        #endregion

        #region Private methods

        private IEnumerator Patrol()
        {
            while (true)
            {
                if (_patrolPoints.Length <= 1)
                {
                    break;
                }

                foreach (Transform point in _patrolPoints)
                {
                    _movement.SetTarget(point);
                    yield return new WaitUntil(() => transform.position == point.position);
                    yield return new WaitForSeconds(_pauseBetweenPoints);
                }

                _patrolPoints = _patrolPoints.Reverse().ToArray();
            }
        }

        #endregion
    }
}