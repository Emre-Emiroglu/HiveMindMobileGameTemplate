#if PRIME_TWEEN_INSTALLED
using PrimeTween;
using UnityEngine;

namespace PrimeTweenDemo {
    public abstract class Clickable : MonoBehaviour {
        public virtual void OnClick() {}
    }

    public abstract class Animatable : Clickable {
        public abstract Sequence Animate(bool toEndValue);
    }

    #if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(Clickable), true), UnityEditor.CanEditMultipleObjects]
    internal class InspectorWithButton : UnityEditor.Editor {
        GUIStyle boldButtonStyle;

        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            GUILayout.Space(8);
            if (boldButtonStyle == null) {
                boldButtonStyle = new GUIStyle(GUI.skin.button) { fontStyle = FontStyle.Bold };
            }
            if (GUILayout.Button("Play Animation", boldButtonStyle)) {
                foreach (var t in targets) {
                    (t as Clickable).OnClick();
                }
            }
        }
    }
    #endif
}
#endif
