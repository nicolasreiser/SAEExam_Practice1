using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemSO itemScriptableObject;

    string ItemName;
    float Weight;
    float Value;
    string Description;
    Category Category;


    // Start is called before the first frame update
    void Start()
    {
        SetCharasteristics();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetCharasteristics()
    {
        if(itemScriptableObject == null)
        {
            Debug.LogError("The scriptable object is not setup");
        }

        ItemName = itemScriptableObject.ItemName;
        Weight = itemScriptableObject.Weight;
        Value = itemScriptableObject.Value;
        Description = itemScriptableObject.Description;
        Category = itemScriptableObject.Category;

    }
}
