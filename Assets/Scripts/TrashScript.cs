using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    private SectionManagementScript _sectionScript;
    private string TrashName;
    private float TrashWorth;
    private float TrashWorkValue;
    void Awake()
    {
        _sectionScript = transform.parent.GetComponent<SectionManagementScript>();
    }

    void Update()
    {
        
    }
    private void setAllValues(int i)
    {
        TrashName = _sectionScript.TrashName[i];
        TrashWorth = _sectionScript.TrashWorth[i];
        TrashWorkValue = _sectionScript.TrashWorkValue[i];
    }

    private void finishedProduct()
    {
        //when workValue <= 0, change the prefab to finished product,
        
    }
    private void sellPRoduct()
    {
        //when clicked, sell the product and inform the minion
    }

}
