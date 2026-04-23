using System;

using UnityEngine;

namespace Templates.IDDatabaseLoader
{
    [Serializable]
    public class IDReference
    {
        [field: SerializeField] private string DatabaseName;
        [field: SerializeField] private string SelectedID;
    }
}