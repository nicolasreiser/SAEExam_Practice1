using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]

public class ItemSO : ScriptableObject
{

    public string ItemName;
    public float Weight;
    public float Value;
    public string Description;
    public Category Category;
 }

public enum Category
{
    Tool,
    Collectable,
    Food,
    Environment
}
