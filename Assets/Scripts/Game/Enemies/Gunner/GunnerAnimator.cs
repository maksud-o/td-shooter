using UnityEngine;

namespace TDS.Game.Enemies.Gunner
{
    public class GunnerAnimator : AnimatorMonoBehaviour
    {
        #region Variables

        private readonly int _isDead = Animator.StringToHash("IsDead");
        private readonly int _moveSpeed = Animator.StringToHash("MoveSpeed");
        private readonly int _shot = Animator.StringToHash("Shot");

        #endregion

        #region Public methods

        public void SetIsDead()
        {
            Animator.SetTrigger(_isDead);
        }

        public void SetMoveSpeed(float speed)
        {
            Animator.SetFloat(_moveSpeed, speed);
        }

        public void SetShot()
        {
            Animator.SetTrigger(_shot);
        }

        #endregion
    }
}