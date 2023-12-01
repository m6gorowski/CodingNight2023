using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    private SectionManagementScript _sectionScript;
    private string _trashName;
    private float _trashWorth;
    private float _trashWorkValue;
    private float _movementSpeed;
    private SpriteRenderer _trashSprite;
    private Animator _animator;
    void Awake()
    {
        _sectionScript = transform.parent.GetComponent<SectionManagementScript>();
        _animator = GetComponent<Animator>();
        _trashSprite = GetComponent<SpriteRenderer>();
        _trashSprite.sprite = _sectionScript.TrashSprites[0];
    }

    void Update()
    {
        
    }
    private void setAllValues(int i)
    {
        _trashName = _sectionScript.TrashName[i];
        _trashWorth = _sectionScript.TrashWorth[i];
        _trashWorkValue = _sectionScript.TrashWorkValue[i];
        _movementSpeed = _sectionScript.MinionMovementSpeed[i];
    }

    private void finishedProduct()
    {
        //when workValue <= 0, change the prefab to finished product,
        if(_trashWorkValue <= 0)
        {
            _trashSprite.sprite = _sectionScript.TrashSprites[1];
        }
        
    }
    private void OnMouseDown()
    {
        if(_trashWorkValue <= 0)
        {
            _trashSprite.sprite = _sectionScript.TrashSprites[0];

        }
    }

}
