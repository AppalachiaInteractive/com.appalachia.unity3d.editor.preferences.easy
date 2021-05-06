using Appalachia.Editor.Preferences.Easy.Base;
using UnityEditor;

namespace Appalachia.Editor.Preferences.Easy
{
    public class IntEditorPref : EasyEditorPref<int>
    {
        public IntEditorPref(
            string path,
            string key,
            string label,
            int defaultValue = default,
            SettingsScope scope = SettingsScope.User,
            int order = 0) : base(path, key, label, defaultValue, scope, order)
        {
        }

        public override int Value
        {
            get
            {
                if (!EditorPrefs.HasKey(key))
                {
                    EditorPrefs.SetInt(key, defaultValue);
                }

                return EditorPrefs.GetInt(key, defaultValue);
            }
            set => EditorPrefs.SetInt(key, value);
        }

        protected override int Draw()
        {
            return EditorGUILayout.IntField(label, Value);
        }

        protected override int DrawDelayed()
        {
            return EditorGUILayout.DelayedIntField(label, Value);
        }
    }
}
