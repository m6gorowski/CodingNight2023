using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    private SectionManagementScript _sectionScript;
    private float _walkSpeed;
    private float _workEff;
    private TrashScript _trashScript;
    private float workEffeciency;
    public float TopY = 3.75f;
    private float BottomY = -8.3f;
    private SpriteRenderer _sprite;

    public bool isWorking;
    public bool isCollectingTrash;
    void Awake()
    {
        _sectionScript = transform.parent.GetComponent<SectionManagementScript>();
        _trashScript = transform.parent.GetChild(0).GetComponent<TrashScript>();
        _sprite = GetComponent<SpriteRenderer>(); 
        setAllValues(0);
    }
    private void Start()
    {
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (isWorking == false && isCollectingTrash == true)
        {            
            transform.position = new Vector3(transform.position.x, transform.position.y + _walkSpeed, transform.position.z); 
            if(transform.position.y >= TopY)
            {
                isCollectingTrash = false;
            }
        }
        if (isWorking == false && isCollectingTrash == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - _walkSpeed, transform.position.z);
            if (transform.position.y <= BottomY)
            {
                isWorking = true;
            }
        }
    }
    void Update()
    {

    }
    private void setAllValues(int i)
    {
        _workEff = _sectionScript.MinionWorkEff[i];
        _walkSpeed = _sectionScript.MinionMovementSpeed[i];
    }

    
    private void OnMouseDown()
    {
        if (isWorking == true)
        {
            _trashScript.trashWorkValue -= _workEff;
            if (_trashScript.trashWorkValue <= 0)
            {
                if (_trashScript._trashSprite.sprite == _sectionScript.TrashSprites[0])
                {
                    _trashScript._trashSprite.sprite = _sectionScript.TrashSprites[1];
                }
                else
                {
                    Debug.Log("Recykling");
                    _trashScript.transform.position = new Vector3(_trashScript.transform.position.x, _trashScript.TopSpawnY, _trashScript.transform.position.z);
                    _trashScript.IsBeingCollected = false;
                    _trashScript.IsBeingRecycled = false;
                    isWorking = false;
                    isCollectingTrash = true;
                    _sectionScript.money += _trashScript.trashWorth;
                }
            }
        }
    }
    
}
