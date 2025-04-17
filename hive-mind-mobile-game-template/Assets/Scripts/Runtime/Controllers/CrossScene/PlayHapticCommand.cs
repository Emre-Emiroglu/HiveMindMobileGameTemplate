using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class PlayHapticCommand : Command<PlayHapticSignal>
    {
        #region ReadonlyFields
        private readonly HapticModel _hapticModel;
        #endregion

        #region Constructor
        public PlayHapticCommand(HapticModel hapticModel) => _hapticModel = hapticModel;
        #endregion

        #region Executes
        public override void Execute(PlayHapticSignal signal)
        {
            if (_hapticModel.IsHapticMuted)
                return;

            HapticPatterns.PlayPreset(signal.HapticType);
        }
        #endregion
    }
}
