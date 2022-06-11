using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class SO_Manager : MonoBehaviour
{
    [FoldoutGroup("Arrays")] public GameObject[] ProduceButtonsArray;
    [FoldoutGroup("Arrays")] public Text[] StockTextsArray;
    [FoldoutGroup("Arrays")] public Animator[] AnimatorsArray;


    public List<SO_MaterialUI> objectsList = new List<SO_MaterialUI>();
    [FoldoutGroup("ScriptableObject")] public SO_MaterialUI WoodObject, TimberObject, TableObject, PaintedObject, IronOreObject, IronIngotObject, NailObject, GearObject;

}
