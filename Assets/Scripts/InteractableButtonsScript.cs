using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class InteractableButtonsScript : MonoBehaviour
{
    public SectionManagementScript SectionManagement;
    private TrashScript _trashScript;
    private MinionScript _minionScript;
    public int ShopItemLevelNumber;
    public int ShopItemNumber;
    public int Cost;

    private void Awake()
    {
        _minionScript = SectionManagement.transform.GetChild(1).GetComponent<MinionScript>();
        _trashScript = SectionManagement.transform.GetChild(0).GetComponent<TrashScript>();
    }


    private void Update()
    {
        CheckCost();   
    }
    public void BuyItem()
    {        
        SectionManagement.money -= Cost;
        SectionManagement.saves[ShopItemNumber] = ShopItemLevelNumber;
        if(ShopItemNumber == 0)
        {
            SectionManagement.saves[2] = ShopItemLevelNumber -1;
            SectionManagement.saves[3] = ShopItemLevelNumber -1;
        }
        _trashScript.setAllValues();
        _minionScript.setAllValues();
        Cost *= 3;
        ShopItemLevelNumber++;
    }
    public void CheckCost()
    {
        if (Cost <= SectionManagement.money)
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
        else if(Cost > SectionManagement.money)      
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
