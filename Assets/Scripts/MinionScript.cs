using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    private SectionManagementScript _sectionScript;
    private float _walkSpeed;
    private float _workSpeed;
    private bool _workFinished = false;
    private Animator _animator;
    void Awake()
    {
        _sectionScript = transform.parent.GetComponent<SectionManagementScript>();
        _animator = GetComponent<Animator>();
        setAllValues(0);
    }

    void Update()
    {
        
    }
    private void setAllValues(int i)
    {
        _workSpeed = _sectionScript.MinionWorkSpeed[i];
        _walkSpeed = _sectionScript.MinionMovementSpeed[i];
        _animator.speed = _walkSpeed;
    }

    private void goAndGetTrash()
    {
        if (_workFinished)
        {
            //play animation for movement up to retrieve the trash
        }
    }
    private void workOnTrash()
    {
        //check when player clicks on minion and decrease the trashWorkValue
    }
    private void goBackWithTrash()
    {
        //play the animation of minion coming back to the desk with trash in hands
    }
}
