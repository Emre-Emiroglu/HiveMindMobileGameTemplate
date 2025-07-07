using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Application;

namespace HiveMindMobileGameTemplate.Runtime.Models.Application
{
    public sealed class ApplicationModel : Model<ApplicationSettings>
    {
        #region Constructor
        public ApplicationModel(ApplicationSettings settings) : base(settings) { }
        #endregion
        
        #region Executes
        public override void LoadData() { }
        public override void SaveData() { }
        #endregion
    }
}
