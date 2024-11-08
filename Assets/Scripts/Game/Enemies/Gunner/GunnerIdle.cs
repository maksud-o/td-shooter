using System.Collections;
using TDS.Game.Enemies.Base;
using UnityEngine;

namespace TDS.Game.Enemies.Gunner
{
    [RequireComponent(typeof(EnemyMovement))]
    public class GunnerIdle : EnemyIdle
    {
        #region Variables

        [SerializeField] private float _pauseBetweenPoints = 3f;
        [SerializeField] private Transform[] _patrolPoints;

        private EnemyMovement _movement;
        private Coroutine _patrolCoroutine;
        private int _patrolIndex;

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
            var waitUntil = new WaitUntil(() => transform.position == _patrolPoints[_patrolIndex].position);
            var waitForSeconds = new WaitForSeconds(_pauseBetweenPoints);

            while (true)
            {
                if (_patrolPoints.Length <= 1)
                {
                    break;
                }

                _movement.SetTarget(_patrolPoints[_patrolIndex]);
                yield return waitUntil;
                _movement.SetTarget(null);
                yield return waitForSeconds;
                _patrolIndex = (_patrolIndex + 1) % _patrolPoints.Length;
            }
        }

        #endregion
    }
}