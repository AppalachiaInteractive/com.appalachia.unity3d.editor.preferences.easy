using UnityEditor;

namespace Appalachia.Editor.Preferences.Easy.Base
{
    public abstract class EasyEditorPrefBase
    {
        public readonly string path;
        public readonly string key;
        public readonly string label;
        public readonly int order;

        protected EasyEditorPrefBase(string path, string key, string label, SettingsScope scope, int order)
        {
            this.path = path;
            this.key = key;
            this.label = label;
            this.order = order;

            EditorPrefCollection.Register(path, scope, this);
        }

        public abstract void DrawUI();

        public abstract void DrawDelayedUI();
    }
}
