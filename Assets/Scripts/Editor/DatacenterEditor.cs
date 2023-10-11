using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;


public class DatacenterEditor : OdinMenuEditorWindow
{
    [MenuItem("Tools/Data Center")]
    private static void OpenWindow()
    {
        GetWindow<DatacenterEditor>().Show();
    }

    private CreateNewMob newMob;

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        tree.Add("Create New", new CreateNewMob());
        tree.AddAllAssetsAtPath("NewMob", "Assets/Scripts/Enemy/Objects", typeof(CreatMob));


        return tree;
    }

    public class CreateNewMob
    {
        public CreateNewMob()
        {
            mobData = ScriptableObject.CreateInstance<CreatMob>();
            mobData.enemyName = "New Mob Data";
        }

        [InlineEditor(objectFieldMode: InlineEditorObjectFieldModes.Hidden)]
        public CreatMob mobData;

        [Button("Add New Mob")]
        private void NewMob()
        {
            AssetDatabase.CreateAsset(mobData, "Assets/Scripts/Enemy/Objects/" + mobData.enemyName);
            AssetDatabase.SaveAssets();

            mobData = ScriptableObject.CreateInstance<CreatMob>();
            mobData.enemyName = "New Mob Data";
        }
    }
}
