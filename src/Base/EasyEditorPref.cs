using System;
using System.Collections.Generic;
using UnityEditor;

namespace Appalachia.Editor.Preferences.Easy.Base
{
    public abstract class EasyEditorPref<T> : EasyEditorPrefBase, IEquatable<EasyEditorPref<T>>, IEquatable<T>
        where T : IConvertible
    {
        public readonly T defaultValue;

        protected EasyEditorPref(
            string path,
            string key,
            string label,
            T defaultValue,
            SettingsScope scope,
            int order) : base(path, key, label, scope, order)
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
            return !ReferenceEquals(null, other) && EqualityComparer<T>.Default.Equals(Value, other);
        }

        public override void DrawUI()
        {
            EditorGUI.BeginChangeCheck();

            var value = Draw();

            if (EditorGUI.EndChangeCheck())
            {
                Value = value;
            }
        }

        protected abstract T Draw();

        public override void DrawDelayedUI()
        {
            EditorGUI.BeginChangeCheck();

            var value = DrawDelayed();

            if (EditorGUI.EndChangeCheck())
            {
                Value = value;
            }
        }

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
                return ((key != null ? key.GetHashCode() : 0) * 397) ^ EqualityComparer<T>.Default.GetHashCode(Value);
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
