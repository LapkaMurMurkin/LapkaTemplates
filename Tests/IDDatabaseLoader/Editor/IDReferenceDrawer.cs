using System.Linq;

using Templates.Editor;

using UnityEditor;

using UnityEngine;

namespace Templates.IDDatabaseLoader.Editor
{
    [CustomPropertyDrawer(typeof(IDReference))]
    public class IDReferenceDrawer : PropertyDrawer
    {
        private IDDatabaseLoaderSettings GetSettings()
        {
            string[] guids = AssetDatabase.FindAssets("t:IDDatabaseLoaderSettings");
            if (guids.Length == 0)
                return null;

            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            return AssetDatabase.LoadAssetAtPath<IDDatabaseLoaderSettings>(path);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty databaseNameProp = property.FindPropertyRelative("DatabaseName");
            SerializedProperty selectedIDProp = property.FindPropertyRelative("SelectedID");

            IDDatabaseLoaderSettings settings = GetSettings();

            if (settings == null || settings.CFGFile == null || settings.CFGFile.Count == 0)
            {
                EditorGUI.LabelField(position, "No settings");
                return;
            }

            Rect dbRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            Rect idRect = new Rect(position.x, position.y + 22, position.width, EditorGUIUtility.singleLineHeight);

            // Database dropdown
            string[] dbNames = settings.CFGFile
                .Where(x => x != null)
                .Select(x => x.name)
                .ToArray();

            int dbIndex = Mathf.Max(0, System.Array.IndexOf(dbNames, databaseNameProp.stringValue));
            int newDbIndex = EditorGUI.Popup(dbRect, "Database", dbIndex, dbNames);
            databaseNameProp.stringValue = dbNames[newDbIndex];

            // Get selected file
            TextAsset file = settings.CFGFile.FirstOrDefault(x => x.name == databaseNameProp.stringValue);

            if (file == null)
                return;

            string[] ids = IDDatabaseCache.GetIDs(file);

            // Searchable popup button
            if (GUI.Button(idRect, $"ID: {selectedIDProp.stringValue}"))
            {
                PopupWindow.Show(
                    idRect,
                    new SearchablePopupWindow(ids, selected =>
                    {
                        selectedIDProp.stringValue = selected;
                        selectedIDProp.serializedObject.ApplyModifiedProperties();
                    }));
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 44;
        }
    }
}