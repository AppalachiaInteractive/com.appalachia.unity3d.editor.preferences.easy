using System;
using Appalachia.Utility.Editor.Preferences.Easy.Base;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Utility.Editor.Preferences.Easy
{
    public class EnumEditorPref<T> : EasyEditorPref<T>
        where T : Enum
    {
        private readonly Func<T, string> _postfixer;

        public EnumEditorPref(
            string path,
            string key,
            string label,
            T defaultValue = default,
            SettingsScope scope = SettingsScope.User,
            int order = 0,
            Func<bool> drawIf = null,
            Func<bool> enableIf = null,
            Action actionButton = null,
            string actionLabel = "Action",
            Func<T, string> postfixer = null) : base(
            path,
            key,
            label,
            defaultValue,
            scope,
            order,
            drawIf,
            enableIf,
            actionButton,
            actionLabel
        )
        {
            _postfixer = postfixer;
        }

        public override T Value
        {
            get
            {
                if (!EditorPrefs.HasKey(key))
                {
                    EditorPrefs.SetInt(key, (int) (object) defaultValue);
                }

                return (T) (object) EditorPrefs.GetInt(key, (int) (object) defaultValue);
            }
            set => EditorPrefs.SetInt(key, (int) (object) value);
        }

        protected override T Draw()
        {
            if (_postfixer != null)
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    var labelWidth = EditorGUIUtility.labelWidth;

                    var value = (T) EditorGUILayout.EnumPopup(label, Value);

                    var postfix = _postfixer(value);

                    var size = EditorStyles.label.CalcSize(new GUIContent(postfix));

                    EditorGUIUtility.labelWidth = 2 * size.x;
                    EditorGUILayout.LabelField(
                        postfix,
                        EditorStyles.boldLabel,
                        GUILayout.Width(2 * size.x)
                    );

                    EditorGUIUtility.labelWidth = labelWidth;
                    return value;
                }
            }

            return (T) EditorGUILayout.EnumPopup(label, Value);
        }

        protected override T DrawDelayed()
        {
            return Draw();
        }
    }
}
