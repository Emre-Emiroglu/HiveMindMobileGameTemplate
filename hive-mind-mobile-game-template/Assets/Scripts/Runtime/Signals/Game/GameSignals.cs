namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game
{
    public readonly struct InitializeGameSignal { }
    public readonly struct PlayGameSignal { }
    public readonly struct GameOverSignal
    {
        #region Properities
        public bool IsSuccess { get; }
        #endregion

        #region Constructor
        public GameOverSignal(bool isSuccess) => IsSuccess = isSuccess;
        #endregion
    }
    public readonly struct GameExitSignal { }
    public readonly struct SetupGameOverPanelSignal
    {
        #region Properities
        public bool IsSuccess { get; }
        #endregion

        #region Constructor
        public SetupGameOverPanelSignal(bool isSuccess) => IsSuccess = isSuccess;
        #endregion
    }
}
