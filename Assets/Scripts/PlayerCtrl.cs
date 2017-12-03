﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Prime31;

public class PlayerCtrl : MonoBehaviour 
{
	[Header("Settings")]
	public float walkSpeed = 6f;
	public float jumpSpeed = 8f;
	public float gravity = 20f;

	[SerializeField] bool isGrounded;
	[SerializeField] bool isJumping;

	// public LayerMask layerMask;
	// public float slopeSlideSpeed = 4f;
	// [SerializeField] bool isSlopeSliding;

	[Header("Ability: Double Jump")]
	public bool canDoubleJump;
	public float doubleJumpSpeed = 6f;
	[SerializeField] bool hasDoubleJumped;

    [Header("Ability: Wall Jump")]
	public bool canWallJump;
	public Vector2 wallJumpAmount = new Vector2(0.5f, 0.5f);
	public float wallJumpWait = 0.5f;
	[SerializeField] bool hasWallJumped;
	[SerializeField] bool lastJumpWasLeft;

    [Header("Ability: Wall Run")]	
	public bool canWallRun;
	public float wallRunAmount;
	[SerializeField] bool isWallRunning;

	// privates
	Vector3 moveDirection = Vector3.zero;
	CharacterController2D.CharacterCollisionState2D flags;
 	CharacterController2D charCtrl2D;
	float slopeAngle;
	Vector3 slopeGradient;

    void Awake ()
    {
		charCtrl2D = GetComponent<CharacterController2D>();
    }

	void DebugPane ()
	{
        if (GameObject.Find("Dbl Jump").GetComponent<Toggle>().isOn)
        {
            canDoubleJump = true;
        } else {
			canDoubleJump = false;
		}
	}
	
	void Update () 
	{
		//DebugPane();

		if (!hasWallJumped)
		{
			moveDirection.x = Input.GetAxis("Horizontal");
			moveDirection.x *= walkSpeed; // multiply by walkspeed
		}

		// RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, 2f, layerMask);
		// if (hit)
		// {
		// 	slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
		// 	slopeGradient = hit.normal;

		// 	if (slopeAngle > charCtrl2D.slopeLimit)
		// 	{
		// 		isSlopeSliding = true;
		// 	} 
		// 	else
		// 	{
		// 		isSlopeSliding = false;
		// 	}
		// }

		if (isGrounded)
		{
			// is on the ground
			moveDirection.y = 0;
			
			isJumping = false;
			hasDoubleJumped = false;

			// if (isSlopeSliding)
			// {
			// 	moveDirection = new Vector3 (slopeGradient.x * slopeSlideSpeed, -slopeGradient.y * slopeSlideSpeed, 0);
			// }

			// jump management
			if (Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpSpeed;
				isJumping = true;

				isWallRunning = true;
			}
		} 
		else 
		{
			// jump button held
			if (Input.GetButtonUp("Jump"))
			{
				if (moveDirection.y > 0)
				{
					moveDirection.y = moveDirection.y * 0.5f;
				}
			}

			// Ability : Double Jump
            if (Input.GetButtonDown("Jump"))
            {
                if (canDoubleJump && !hasDoubleJumped)
                {
                    moveDirection.y = doubleJumpSpeed;
					hasDoubleJumped = true;
                }
            }
		}

        // direction management
        if (moveDirection.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveDirection.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

		// fall rate
		moveDirection.y -= gravity * Time.deltaTime;

		// moving left or right (or jump or fall)
		charCtrl2D.move(moveDirection * Time.deltaTime);
		// report what is around us
		flags = charCtrl2D.collisionState;

		// check if we are on the ground
		isGrounded = flags.below;

		// check if we hit our head
		if (flags.above)
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}

		if (flags.left || flags.right)
		{
            // Ability : Wall Run
			if (canWallRun)
			{
				if (Input.GetAxis("Vertical") > 0 && isWallRunning)
				{
					moveDirection.y = jumpSpeed / wallJumpAmount.y;
					StartCoroutine(WallRunWaiter(0.05f));
				}
			}
			
			// Ability : Wall Jump
			if (canWallJump)
            {
				if (Input.GetButtonDown("Jump") && !hasWallJumped && !isGrounded)
				{
					if (moveDirection.x < 0)
					{
						moveDirection.x = jumpSpeed * wallJumpAmount.x;
						moveDirection.y = jumpSpeed * wallJumpAmount.y;
						transform.eulerAngles = new Vector3(0, 0, 0);
						lastJumpWasLeft = false;
					} 
					else if (moveDirection.x > 0)
					{
						moveDirection.x = -jumpSpeed * wallJumpAmount.x;
						moveDirection.y = jumpSpeed * wallJumpAmount.y;
						transform.eulerAngles = new Vector3(0, 180, 0);
						lastJumpWasLeft = true;
					}

					StartCoroutine(HasWallJumpedTimer(wallJumpWait));
				}
			}
		}
	}

	IEnumerator HasWallJumpedTimer (float _waitTime)
	{
		hasWallJumped = true;
		yield return new WaitForSeconds(_waitTime);
		hasWallJumped = false;
	}

	IEnumerator WallRunWaiter (float _waitTime)
	{
		isWallRunning = true;
		yield return new WaitForSeconds(_waitTime);
		isWallRunning = false;
	}
}
