
using UnityEditor;

namespace Templates.IDDatabaseLoader.Editor
{
    [CustomEditor(typeof(IDDatabaseLoaderSettings))]
    public class IDDatabaseLoaderSettingsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.HelpBox("Пояснение: CFG файл должен быть в формате UTF-8.", MessageType.Info);
        }
    }
}