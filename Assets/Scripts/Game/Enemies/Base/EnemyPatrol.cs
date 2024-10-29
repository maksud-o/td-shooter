using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemies.Base
{
    public abstract class EnemyPatrol : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private Transform[] _patrolPoints;

        #endregion

        #region Properties

        protected IReadOnlyList<Transform> PatrolPoints => _patrolPoints;

        #endregion
    }
}