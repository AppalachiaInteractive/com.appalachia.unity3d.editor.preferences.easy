using Appalachia.Editor.Preferences.Easy.Base;
using UnityEditor;

namespace Appalachia.Editor.Preferences.Easy
{
    public class BoolEditorPref : EasyEditorPref<bool>
    {
        public BoolEditorPref(
            string path,
            string key,
            string label,
            bool defaultValue = default,
            SettingsScope scope = SettingsScope.User,
            int order = 0) : base(path, key, label, defaultValue, scope, order)
        {
        }

        public override bool Value
        {
            get
            {
                if (!EditorPrefs.HasKey(key))
                {
                    EditorPrefs.SetBool(key, defaultValue);
                }

                return EditorPrefs.GetBool(key, defaultValue);
            }
            set => EditorPrefs.SetBool(key, value);
        }

        protected override bool Draw()
        {
            return EditorGUILayout.Toggle(label, Value);
        }

        protected override bool DrawDelayed()
        {
            return EditorGUILayout.Toggle(label, Value);
        }
    }
}
