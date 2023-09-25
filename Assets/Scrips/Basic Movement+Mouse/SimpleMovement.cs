using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private CharacterController _charContr;

    public float _movementSpd = 5f;
    
    public bool _EnableGravity = true;
    public float _gravity = 0.5f;
    
    public bool _EnableJumping = true;
    public float _jumpSpeed = 0.3f;

    Vector3 _completeMovement; //Including Y(Height) Value

    void Start()
    {
        _charContr = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        float horiAxisInput = Input.GetAxis("Horizontal");
        float verAxisInput = Input.GetAxis("Vertical");

        Vector3 moveInDirection = transform.right * horiAxisInput + transform.forward * verAxisInput;
        Vector3 flatMovement = moveInDirection* Time.deltaTime *_movementSpd;

        _completeMovement = new Vector3(flatMovement.x,_completeMovement.y,flatMovement.z);

        HandleHeightValue();
        
        _charContr.Move(_completeMovement);
        
        
    }

    private void HandleHeightValue()
    {
        if(PlayerJumped && _EnableJumping)
        {
            _completeMovement.y = _jumpSpeed;
        }
        else if(_charContr.isGrounded || !_EnableGravity )
        {
            _completeMovement.y = 0f;
        }
        else 
        {
            _completeMovement.y -= _gravity * Time.deltaTime;
        }
    }
    private bool PlayerJumped => _charContr.isGrounded && Input.GetKey(KeyCode.Space);

    public void SetEnableJumping(bool x)
    {
        _EnableJumping = x;
    }

    public void SetGravity(bool x)
    {
        _EnableGravity = x;
    }

    public bool GetGravity()
    {
        return _EnableGravity;
    }

    public void SetPosition(Vector3 _newPosition)
    {
        _charContr.enabled = false;
        _charContr.transform.position = _newPosition;
        _charContr.enabled = true;
    }

    public void SetRotation(Quaternion _newRotation)
    {
        _charContr.enabled = false;
        _charContr.transform.rotation = _newRotation;
        _charContr.enabled = true;
    }

    public void SetEnableGravity(bool x)
    {
        _EnableGravity = x;
    }


    public bool GetIsGrounded()
    {
        return _charContr.isGrounded;
    }

}
