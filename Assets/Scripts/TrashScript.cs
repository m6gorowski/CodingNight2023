using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    private SectionManagementScript _sectionScript;
    void Awake()
    {
        _sectionScript = transform.parent.GetComponent<SectionManagementScript>();
    }

    void Update()
    {
        
    }
}
