using UnityEngine;
using UnityEditor;


public class Colorer : EditorWindow
 {
    
    Color color;
    [MenuItem("Window/Color them all")]
    public static void ShowWindow()
    {
      GetWindow<Colorer>("Colorer");
    }

    private void OnGUI()
    {

       GUILayout.Label("Color them all", EditorStyles.boldLabel);

            
        color = EditorGUILayout.ColorField("Color", color);
      
        if (GUILayout.Button("PAINT THEM ALL"))
        {
            ColorThem();

        }

    }

    private void ColorThem()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}