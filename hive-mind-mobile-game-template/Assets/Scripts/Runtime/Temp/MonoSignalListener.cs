﻿using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Interfaces;
using UnityEngine;

namespace HiveMindMobileGameTemplate.Runtime.Temp
{
    public abstract class MonoSignalListener : MonoBehaviour, ISignalListenable
    {
        #region Fields
        protected SignalBus SignalBus;
        #endregion

        #region PostConstruct
        protected virtual void PostConstruct(SignalBus signalBus) => SignalBus = signalBus;
        #endregion

        #region Core
        public virtual void Initialize() => SetSubscriptions(true);
        public virtual void Dispose() => SetSubscriptions(false);
        protected abstract void SetSubscriptions(bool isSubscribed);
        #endregion
    }
}