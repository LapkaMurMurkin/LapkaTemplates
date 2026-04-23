using System.Collections.Generic;

using UnityEngine;

namespace Templates.IDDatabaseLoader
{
    public static class IDDatabaseCache
    {
        private static readonly Dictionary<TextAsset, string[]> cache = new();

        public static string[] GetIDs(TextAsset file)
        {
            if (file == null)
                return new string[0];

            if (cache.TryGetValue(file, out string[] ids))
                return ids;

            ids = file.text.Split(
                new[] { '\r', '\n' },
                System.StringSplitOptions.RemoveEmptyEntries);

            cache[file] = ids;
            return ids;
        }

        public static void Clear()
        {
            cache.Clear();
        }
    }
}