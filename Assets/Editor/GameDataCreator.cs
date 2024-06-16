using UnityEditor;
using UnityEngine;

namespace InnovecsTest
{
    public class GameDataCreator
    {
        [MenuItem("Assets/Create/GameData Object")]
        public static void CreateMyAsset()
        {
            GameData asset = ScriptableObject.CreateInstance<GameData>();

            AssetDatabase.CreateAsset(asset, "Assets/Resources/GameData.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}
