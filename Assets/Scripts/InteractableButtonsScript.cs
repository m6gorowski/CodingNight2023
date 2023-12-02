using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class InteractableButtonsScript : MonoBehaviour
{
    public TMP_Dropdown section;
    private int sectionId;
    private SectionManagementScript SectionManagement;
    private TrashScript _trashScript;
    private MinionScript _minionScript;
    public int ShopItemLevelNumber;
    public int ShopItemNumber;
    public int Cost;
    public TextMeshProUGUI Cost1;
    private bool canBebought = true;

    private MoneyManagementScript _moneyManagementScript;

    private void Awake()
    {

        _moneyManagementScript = FindObjectOfType<MoneyManagementScript>();
    }

    private void Update()
    {
        if(section.options[section.value].text == "Sekcja 1")
        {
            sectionId = 0;
            SectionManagementScript[] sections = FindObjectsOfType<SectionManagementScript>();
            foreach(SectionManagementScript section in sections)
            {
                if(section.Id == sectionId)
                {
                    SectionManagement = section;
                    _minionScript = SectionManagement.transform.GetChild(1).GetComponent<MinionScript>();
                    _trashScript = SectionManagement.transform.GetChild(0).GetComponent<TrashScript>();
                }
            }
            
        }
        else if(section.options[section.value].text == "Sekcja 2")
        {
            sectionId = 1;
            SectionManagementScript[] sections = FindObjectsOfType<SectionManagementScript>();
            foreach (SectionManagementScript section in sections)
            {
                if (section.Id == sectionId)
                {
                    SectionManagement = section;
                    _minionScript = SectionManagement.transform.GetChild(1).GetComponent<MinionScript>();
                    _trashScript = SectionManagement.transform.GetChild(0).GetComponent<TrashScript>();
                }
            }
        }
        CheckCost();   
    }
    public void BuyItem()
    {
        _moneyManagementScript.money -= Cost;
        SectionManagement.saves[ShopItemNumber] = ShopItemLevelNumber;
        if(ShopItemNumber == 0)
        {
            SectionManagement.saves[2] = ShopItemLevelNumber -1;
            SectionManagement.saves[3] = ShopItemLevelNumber -1;
            
        }
        _trashScript.setAllValues();
        _minionScript.setAllValues();
        Cost *= 3;
        Cost1.text = Cost.ToString() + "$";
        ShopItemLevelNumber++;
        if(SectionManagement.saves[ShopItemNumber] == null)
        {
            Button[] buttons = FindObjectsOfType<Button>();
            foreach (Button btn in buttons)
            {
                if (btn.name == this.name)
                {
                    btn.interactable = false;
                    canBebought = false;
                    Cost1.text = "MAX";
                }
            }
        }
    }
    public void CheckCost()
    {
        if (Cost <= _moneyManagementScript.money && canBebought)
        {
            Button[] buttons = FindObjectsOfType<Button>();
            foreach(Button btn in buttons)
            {
                if(btn.name == this.name)
                {
                    btn.interactable = true;
                }
            }
            
        }
        else if(Cost > _moneyManagementScript.money && canBebought)      
        {
            Button[] buttons = FindObjectsOfType<Button>();
            foreach (Button btn in buttons)
            {
                if (btn.name == this.name)
                {
                    btn.interactable = false;
                }
            }
        }
    }
}
