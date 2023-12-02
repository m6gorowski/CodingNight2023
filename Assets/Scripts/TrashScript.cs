using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    private SectionManagementScript _sectionScript;
    private string _trashName;
    private float _trashWorth;
    public float _trashWorkValue;
    private float _movementSpeed;
    public SpriteRenderer _trashSprite;
    private MinionScript _minionScript;

    public float TopSpawnY = 10.5f;
    private float BottomSpawnY = 3.8f;
    private float fallSpeed = 0.01f;

    public bool IsBeingRecycled;
    public bool IsBeingCollected;
    void Awake()
    {
        _sectionScript = transform.parent.GetComponent<SectionManagementScript>();
        _minionScript = transform.parent.GetChild(1).GetComponent<MinionScript>();
        _trashSprite = GetComponent<SpriteRenderer>();
        _trashSprite.sprite = _sectionScript.TrashSprites[0];
        setAllValues(0);
    }
    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        Movement();
    }
    private void setAllValues(int i)
    {
        _trashName = _sectionScript.TrashName[i];
        _trashWorth = _sectionScript.TrashWorth[i];
        _trashWorkValue = _sectionScript.TrashWorkValue[i];
        _movementSpeed = _sectionScript.MinionMovementSpeed[i];
    }

    private void Movement()
    {
        if(IsBeingCollected == false && IsBeingRecycled == false)
        {
            _trashSprite.sortingOrder = -1;
            _trashSprite.sprite = _sectionScript.TrashSprites[0];
            _trashWorkValue = _sectionScript.TrashWorkValue[0];
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed, transform.position.z);
            fallSpeed *= 1.02f;
            if(transform.position.y <= BottomSpawnY)
            {
                transform.position = new Vector3(transform.position.x, BottomSpawnY, transform.position.z);
                IsBeingCollected = true;
            }
        }
        if(IsBeingCollected == true && IsBeingRecycled == false)
        {
            if(_minionScript.isWorking == false && _minionScript.isCollectingTrash == false)
            {
                _trashSprite.sortingOrder = 1;
                transform.position = new Vector3(transform.position.x, _minionScript.transform.position.y - 0.7f, transform.position.z);
            }
            if (_minionScript.isWorking == true)
            {
                _trashSprite.sortingOrder = 1;
                IsBeingCollected = false;
                
                IsBeingRecycled = true;
                transform.position = new Vector3(transform.position.x, -9.75f, transform.position.z);
                fallSpeed = 0.01f;

            }
        }
        
    }

}
