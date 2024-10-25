using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAnimator : AnimatorMonoBehaviour
    {
        #region Variables

        private readonly int _isDead = Animator.StringToHash("IsDead");
        private readonly int _shot = Animator.StringToHash("Shot");

        #endregion

        #region Public methods

        public void SetIsDead()
        {
            Animator.SetTrigger(_isDead);
        }

        public void SetShot()
        {
            Animator.SetTrigger(_shot);
        }

        #endregion
    }
}