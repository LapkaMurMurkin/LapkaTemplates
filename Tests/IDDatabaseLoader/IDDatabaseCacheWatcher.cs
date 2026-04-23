using UnityEditor;

namespace Templates.IDDatabaseLoader
{
    public class IDDatabaseCacheWatcher : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            IDDatabaseCache.Clear();
        }
    }
}