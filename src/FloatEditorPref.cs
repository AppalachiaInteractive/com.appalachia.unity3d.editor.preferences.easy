using Appalachia.Editor.Preferences.Easy.Base;
using UnityEditor;

namespace Appalachia.Editor.Preferences.Easy
{
    public class FloatEditorPref : EasyEditorPref<float>
    {
        public FloatEditorPref(
            string path,
            string key,
            string label,
            float defaultValue = default,
            SettingsScope scope = SettingsScope.User,
            int order = 0) : base(path, key, label, defaultValue, scope, order)
        {
        }

        public override float Value
        {
            get
            {
                if (!EditorPrefs.HasKey(key))
                {
                    EditorPrefs.SetFloat(key, defaultValue);
                }

                return EditorPrefs.GetFloat(key, defaultValue);
            }
            set => EditorPrefs.SetFloat(key, value);
        }

        protected override float Draw()
        {
            return EditorGUILayout.FloatField(label, Value);
        }

        protected override float DrawDelayed()
        {
            return EditorGUILayout.DelayedFloatField(label, Value);
        }
    }
}
