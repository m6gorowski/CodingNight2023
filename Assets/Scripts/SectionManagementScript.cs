using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SectionManagementScript : MonoBehaviour
{
    public int Id = 0;
    [Header("Trash")]
    public Sprite[] TrashSprites;
    public string[] TrashName;
    public float[] TrashWorth;
    public float[] TrashWorkValue;
    [Header("Minion")]
    public float[] MinionWorkEff;
    public float[] MinionMovementSpeed;
    [Header("Other")]
    public float money;
    [Header("SaveUpdates")]
    public int[] saves = new int[6];

    private void Start()
    {
        //set it to player prefs;
        saves[0] = 1;
        saves[1] = 0;
        saves[2] = 0;
        saves[3] = 0;
        saves[4] = 0;
        saves[5] = 0;

    }

}
