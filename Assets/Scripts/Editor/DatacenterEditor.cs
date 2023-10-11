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
    private CreateNewTurret newTurret;

    protected override void OnDestroy()
    {
        base.OnDestroy();

        if (newMob != null)
            DestroyImmediate(newMob.mobData);

        if (newTurret != null)
            DestroyImmediate(newTurret.turretData);
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        
        //Button to create a new Mob
        tree.Add("Create New Mob", newMob);

        //button to create a new Turret
        tree.Add("Create New Turret", newTurret);
        
        //Files of Mobs Storage
        tree.AddAllAssetsAtPath("Mobs Stats", "Assets/Scripts/Enemy/Objects", typeof(CreatMob));

        //Files of Turrets Storage
        tree.AddAllAssetsAtPath("Turrets Stats", "Assets/Scripts/Turrets/Objects", typeof(CreatTurret));

        return tree;
    }

    /*protected override void OnBeginDrawEditors()
    {
        OdinMenuTreeSelection selected = this.MenuTree.Selection;

        SirenixEditorGUI.EndHorizontalToolbar();
        {
            GUILayout.FlexibleSpace();

            if(SirenixEditorGUI.ToolbarButton("Delete Current"))
            {
                CreatMob asset = selected.SelectedValue as CreatMob;
                //string path = asset.
            }
        }
    }*/

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
            string assetPath = "Assets/Scripts/Enemy/Objects/" + mobData.enemyName + ".asset";
            AssetDatabase.CreateAsset(mobData, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh(); // Refresh the asset database to see changes in the Editor.

            mobData = ScriptableObject.CreateInstance<CreatMob>();
            mobData.enemyName = "New Mob Data";
        }
    }

    public class CreateNewTurret
    {
        public CreateNewTurret()
        {
            turretData = ScriptableObject.CreateInstance<CreatTurret>();
            turretData.turretName = "New Turret Data";
        }

        [InlineEditor(objectFieldMode: InlineEditorObjectFieldModes.Hidden)]
        public CreatTurret turretData;

        [Button("Add New Turret")]
        private void NewTurret()
        {
            string assetPath = "Assets/Scripts/Turrets/Objects/" + turretData.turretName + ".asset";
            AssetDatabase.CreateAsset(turretData, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh(); // Refresh the asset database to see changes in the Editor.

            turretData = ScriptableObject.CreateInstance<CreatTurret>();
            turretData.turretName = "New Turret Data";
        }
    }
}
