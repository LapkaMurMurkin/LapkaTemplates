using System;
using System.Linq;

using UnityEditor;

using UnityEngine;

namespace Templates.Editor
{
    public class SearchablePopupWindow : PopupWindowContent
    {
        private string[] options;
        private string searchText = "";
        private Vector2 scroll;
        private Action<string> onSelect;

        public SearchablePopupWindow(string[] options, Action<string> onSelect)
        {
            this.options = options;
            this.onSelect = onSelect;
        }

        public override Vector2 GetWindowSize()
        {
            return new Vector2(250, 300);
        }

        public override void OnGUI(Rect rect)
        {
            GUILayout.Label("Search", EditorStyles.boldLabel);

            GUI.SetNextControlName("SearchField");
            searchText = EditorGUILayout.TextField(searchText);

            var filtered = options
                .Where(x => string.IsNullOrEmpty(searchText) ||
                            x.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToArray();

            scroll = EditorGUILayout.BeginScrollView(scroll);

            foreach (var item in filtered)
            {
                if (GUILayout.Button(item, EditorStyles.miniButton))
                {
                    onSelect?.Invoke(item);
                    editorWindow.Close();
                }
            }

            EditorGUILayout.EndScrollView();

            EditorGUI.FocusTextInControl("SearchField");
        }
    }
}