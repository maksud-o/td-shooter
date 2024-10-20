namespace TDS.Architecture.States
{
    public abstract class AppState : State
    {
        #region Public methods

        public abstract void Enter();

        #endregion
    }
}