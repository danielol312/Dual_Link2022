using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float doubleTapTime = 0.2f;
    float lastTapTime;

    Animator animator;

    public CharacterController2D controller;
    [SerializeField] int color = 0; //0 - Red   1 - Blue
    string horizontalAxis, jumpAxis, dashDownAxis, dashLeftAxis, dashRightAxis; 
    bool jump = false, dashDown = false, dashLeft = false, dashRight = false;

    public float movementSpeed = 10f;
    float horizontalMovement = 0f;


    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        if (color == 0) { jumpAxis = "JumpRed"; horizontalAxis = "HorizontalRed"; dashDownAxis = "DashDownRed"; dashLeftAxis = "DashLeftRed"; dashRightAxis = "DashRightRed"; }
        if (color == 1) { jumpAxis = "JumpBlue"; horizontalAxis = "HorizontalBlue"; dashDownAxis = "DashDownBlue"; dashLeftAxis = "DashLeftBlue"; dashRightAxis = "DashRightBlue"; }
    }

    void Update()
    {
        horizontalMovement = Input.GetAxis(horizontalAxis) * movementSpeed;

        if (horizontalMovement != 0) { animator.SetBool("isMoving", true); }
        else { animator.SetBool("isMoving", false); }

        if (Input.GetButtonDown(jumpAxis)) { jump = true; }
        if (Input.GetButtonDown(dashDownAxis)) { dashDown = true; }

        if (Input.GetButton(dashLeftAxis) && Input.GetButton(dashDownAxis)) { dashLeft = true; }
        if (Input.GetButton(dashRightAxis) && Input.GetButton(dashDownAxis)) { dashRight = true; }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, jump, dashDown, dashLeft, dashRight);
        jump = false; dashDown = false; dashLeft = false; dashRight = false;
    }
}
