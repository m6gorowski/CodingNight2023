using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagementScript : MonoBehaviour
{
    private SectionManagementScript _sectionScript;
    public TextMeshProUGUI MoneyText;

    private void Awake()
    {
        _sectionScript = FindObjectOfType<SectionManagementScript>();
    }
    private void Update()
    {
        MoneyText.text = "$: " + _sectionScript.money.ToString();
    }
}
