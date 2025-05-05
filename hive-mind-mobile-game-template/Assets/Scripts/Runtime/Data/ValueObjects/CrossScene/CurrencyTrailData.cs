using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using PrimeTween;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene
{
    public readonly struct CurrencyTrailData
    {
        #region Getters
        public CurrencyTypes CurrencyType { get; }
        public int Amount { get; }
        public float Duration { get; }
        public Ease Ease { get; }
        public Vector3 StartPosition { get; }
        public Vector3 TargetPosition { get; }
        #endregion

        #region Constructor
        public CurrencyTrailData(CurrencyTypes currencyType, int amount, float duration, Ease ease,
            Vector3 startPosition, Vector3 targetPosition)
        {
            CurrencyType = currencyType;
            Amount = amount;
            Duration = duration;
            Ease = ease;
            StartPosition = startPosition;
            TargetPosition = targetPosition;
        }

        #endregion
    }
}