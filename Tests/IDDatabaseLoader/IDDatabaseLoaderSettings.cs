using System.Collections.Generic;

using UnityEngine;

namespace Templates.IDDatabaseLoader
{
    [CreateAssetMenu(menuName = "ScriptableObjects/IDDatabaseLoaderSettings")]
    public class IDDatabaseLoaderSettings : ScriptableObject
    {
        [field: SerializeField] public List<TextAsset> CFGFile { get; private set; }
    }
}