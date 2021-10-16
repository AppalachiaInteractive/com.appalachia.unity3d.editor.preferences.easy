using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Appalachia.Utility.Editor.Preferences.Easy.Base
{
    public abstract class EasyEditorPref<T> : EasyEditorPrefBase,
                                              IEquatable<EasyEditorPref<T>>,
                                              IEquatable<T>
    {
        public readonly T defaultValue;

        protected EasyEditorPref(
            string path,
            string key,
            string label,
            T defaultValue,
            SettingsScope scope,
            int order,
            Func<bool> drawIf,
            Func<bool> enableIf,
            Action actionButton,
            string actionLabel) : base(
            path,
            key,
            label,
            scope,
            order,
            drawIf,
            enableIf,
            actionButton,
            actionLabel
        )
        {
            this.defaultValue = defaultValue;
        }

        public abstract T Value { get; set; }

        public bool Equals(EasyEditorPref<T> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return (key == other.key) && EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public bool Equals(T other)
        {
            return !ReferenceEquals(null, other) &&
                   EqualityComparer<T>.Default.Equals(Value, other);
        }

        public override void DrawUI()
        {
            DrawInternal(Draw);
        }

        public override void DrawDelayedUI()
        {
            DrawInternal(DrawDelayed);
        }

        private void DrawInternal(Func<T> drawAction)
        {
            if ((drawIf != null) && !drawIf())
            {
                return;
            }

            var guiEnabled = GUI.enabled;
            if (enableIf != null)
            {
                GUI.enabled = enableIf();
            }

            EditorGUI.BeginChangeCheck();

            T value;
            using (new EditorGUILayout.HorizontalScope())
            {
                value = drawAction();

                if (actionButton != null)
                {
                    EditorGUILayout.Space(1.0f, false);
                    var l = new GUIContent(actionLabel ?? "   ");

                    var width = EditorStyles.miniButton.CalcSize(l).x;
                    if (GUILayout.Button(
                        l,
                        EditorStyles.miniButton,
                        GUILayout.Width(width + 10f)
                    ))
                    {
                        actionButton();
                    }
                }
            }

            if (EditorGUI.EndChangeCheck())
            {
                Value = value;
            }

            GUI.enabled = guiEnabled;
        }

        protected abstract T Draw();
        protected abstract T DrawDelayed();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((EasyEditorPref<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((key != null ? key.GetHashCode() : 0) * 397) ^
                       EqualityComparer<T>.Default.GetHashCode(Value);
            }
        }

        public static bool operator ==(EasyEditorPref<T> left, EasyEditorPref<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EasyEditorPref<T> left, EasyEditorPref<T> right)
        {
            return !Equals(left, right);
        }

        public static bool operator ==(EasyEditorPref<T> left, T right)
        {
            if (left == null)
            {
                return false;
            }

            return Equals(left.Value, right);
        }

        public static bool operator !=(EasyEditorPref<T> left, T right)
        {
            if (left == null)
            {
                return false;
            }

            return !Equals(left.Value, right);
        }

        public static implicit operator T(EasyEditorPref<T> wrapper)
        {
            return wrapper.Value;
        }
    }
}
