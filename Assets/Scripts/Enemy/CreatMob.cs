using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "NewMob", menuName = "Create/Enemy")]
public class CreatMob : ScriptableObject
{
    
    [HorizontalGroup("Game data", 75)]
    [PreviewField(75)]
    [HideLabel]
    public GameObject enemyModel;
    
    [VerticalGroup("Game data/Stats")]
    [LabelWidth(100)]
    [Range(1,500)]
    [GUIColor(0.5f, 1, 0.5f)]
    public int hp = 1;

    [VerticalGroup("Game data/Stats")]
    [LabelWidth(100)]
    [Range(.5f, 100)]
    [GUIColor(0.3f, 0.5f, 1f)]
    public float speed = .5f;

    [VerticalGroup("Game data/Stats")]
    [LabelWidth(100)]
    [Range(1,100)]
    [GUIColor(0.8f, 0.4f, 0.4f)]
    public int dmg = 1;

    [BoxGroup("Details")]
    [LabelWidth(100)]
    public string enemyName;

    [BoxGroup("Details")]
    [LabelWidth(100)]
    [TextArea]
    public string description;
}
