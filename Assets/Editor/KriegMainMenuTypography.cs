#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;

public static class KriegMainMenuTypography
{
    const string ScenePath = "Assets/Scenes/MainMenu.unity";
    const string TtfPath = "Assets/Fonts/Orbitron-Variable.ttf";
    const string SdfPath = "Assets/Fonts/Orbitron SDF.asset";

    [MenuItem("Krieg/Fonts/Use Orbitron On Main Menu (creates SDF if missing)")]
    public static void ApplyOrbitronToMainMenu()
    {
        var sourceFont = AssetDatabase.LoadAssetAtPath<Font>(TtfPath);
        if (sourceFont == null)
        {
            EditorUtility.DisplayDialog("Krieg", "Missing font: " + TtfPath, "OK");
            return;
        }

        var fontAsset = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(SdfPath);
        if (fontAsset == null)
        {
            fontAsset = TMP_FontAsset.CreateFontAsset(sourceFont);
            AssetDatabase.CreateAsset(fontAsset, SdfPath);
            AssetDatabase.SaveAssets();
            fontAsset = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(SdfPath);
        }

        if (fontAsset == null)
        {
            EditorUtility.DisplayDialog("Krieg", "Could not create or load Orbitron SDF.", "OK");
            return;
        }

        StyleOutlineMaterial(fontAsset.material);

        var scene = EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
        foreach (var tmp in Object.FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.None))
        {
            Undo.RecordObject(tmp, "Krieg menu font");
            tmp.font = fontAsset;
            tmp.fontSharedMaterial = fontAsset.material;
        }

        EditorUtility.SetDirty(fontAsset);
        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene);
        AssetDatabase.SaveAssets();
        EditorUtility.DisplayDialog("Krieg", "Main Menu TMP texts now use Orbitron SDF with outline.", "OK");
    }

    static void StyleOutlineMaterial(Material m)
    {
        if (m == null) return;
        m.EnableKeyword("OUTLINE_ON");
        m.SetFloat("_OutlineWidth", 0.16f);
        m.SetFloat("_OutlineSoftness", 0.02f);
        m.SetColor("_OutlineColor", new Color(0.02f, 0.09f, 0.07f, 1f));
        EditorUtility.SetDirty(m);
    }
}
#endif
