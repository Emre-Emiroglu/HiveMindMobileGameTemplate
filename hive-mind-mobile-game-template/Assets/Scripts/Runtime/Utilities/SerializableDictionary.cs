using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
    {
        #region Fields
        public List<TKey> keys = new();
        public List<TValue> values = new();
        public Dictionary<TKey, TValue> MyDictionary = new();
        #endregion

        #region SerializationCallbacks
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            
            foreach (KeyValuePair<TKey, TValue> kvp in MyDictionary)
            {
                keys.Add(kvp.Key);
                values.Add(kvp.Value);
            }
        }
        public void OnAfterDeserialize()
        {
            MyDictionary = new Dictionary<TKey, TValue>();
            
            for (int i = 0; i != Math.Min(keys.Count, values.Count); i++)
                MyDictionary.Add(keys[i], values[i]);
        }
        #endregion
    }
}