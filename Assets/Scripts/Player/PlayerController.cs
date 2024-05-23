using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float GravityModifier = 1f;
    public float SpeedModifier = 1;
    public float JumpModifier = 1;
    public float WalkingSpeed = 1;
    public float RunningSpeed = 1.75f;

    private float _fallVelocity = 0;

    private Vector3 _moveVector;

    private CharacterController _charCont;
    private AudioSource _audio;
    private bool _audioPlays;

    private void Start()
    {
        _charCont = GetComponent<CharacterController>();

        LockCursor();

        _audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        PositionFixedUpdate();

        GravityUpdate();
    }

    private void Update()
    {
        MovementUpdate();

        JumpUpdate();
    }

    void GravityUpdate()
    {
        _fallVelocity += GravityModifier * 9.81f * Time.fixedDeltaTime;
        _charCont.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_charCont.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

    void PositionFixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            _charCont.Move(_moveVector * WalkingSpeed * 15 * SpeedModifier * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _charCont.Move(_moveVector * RunningSpeed * 15 * SpeedModifier * Time.fixedDeltaTime);
        }

        _moveVector = Vector3.zero;
    }

    void MovementUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if (_audioPlays == false && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            _audioPlays = true;
            _audio.Play();
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) == false)
        {
            _audioPlays = false;
            _audio.Pause();
        }

        _moveVector.Normalize();
    }

    void JumpUpdate()
    {
        if (_charCont.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _fallVelocity = -JumpModifier * 5;
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
