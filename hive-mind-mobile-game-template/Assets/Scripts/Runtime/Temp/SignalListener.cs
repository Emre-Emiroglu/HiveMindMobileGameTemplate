﻿using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Interfaces;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp
{
    public abstract class SignalListener : ISignalListenable
    {
        #region ReadonlyFields
        protected readonly SignalBus SignalBus;
        #endregion

        #region Constructor
        protected SignalListener(SignalBus signalBus) => SignalBus = signalBus;
        #endregion

        #region Core
        public virtual void Initialize() => SetSubscriptions(true);
        public virtual void Dispose() => SetSubscriptions(false);
        protected abstract void SetSubscriptions(bool isSubscribed);
        #endregion
    }
}