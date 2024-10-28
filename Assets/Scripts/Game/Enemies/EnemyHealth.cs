namespace TDS.Game.Enemies
{
    public class EnemyHealth : Health
    {
        #region Protected methods

        protected override void Die()
        {
            // _gunnerAnimator.SetIsDead();
            gameObject.SetActive(false);
        }

        #endregion
    }
}