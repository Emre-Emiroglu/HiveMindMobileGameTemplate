﻿using HMPool.Runtime;
using VContainer;

namespace HiveMindMobileGameTemplate.Runtime.Utilities.Extensions
{
    public static class PoolServiceContainerBuilderExtension
    {
        #region Executes
        public static void RegisterPoolService(this IContainerBuilder containerBuilder, PoolConfig poolConfig) =>
            containerBuilder.Register<PoolService>(Lifetime.Singleton).WithParameter(poolConfig).AsSelf();
        #endregion
    }
}