using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMove : MonoBehaviour
{
	public float speed = 10f;
	public float dashSpeed = 10f;
	public float dashTime = 0.1f;
	public float dashCooldown = 2f;
	public float gravity = 10f;
	public float jumpSpeed = 2.0f;
	public bool canMove = true;

	private CapsuleCollider coll;
	private float timer;
	private CharacterController charContr;
	private Vector3 jumpVect = Vector3.zero;
	private Vector3 moveDir = Vector3.zero;

	// Use this for initialization
	void Start()
	{
		coll = GetComponent<CapsuleCollider>();
		timer = 0;
		charContr = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		float h = Input.GetAxis("Horizontal"); // Gets input axis
		float v = Input.GetAxis("Vertical");

		Vector3 forward = transform.forward * v * speed * Time.deltaTime; // Vector3 for movement
		Vector3 sideways = transform.right * h * speed * Time.deltaTime;
		Vector3 grav = new Vector3(0, -0.1f, 0); // Gravity

		moveDir = new Vector3(h, 0, v);
		moveDir = transform.TransformDirection(moveDir);
		moveDir *= dashSpeed;

		if (canMove)
		{
			if (charContr.isGrounded) // On ground
			{
				jumpVect.y = 0;
				charContr.Move(forward + sideways + grav); // Moves object (player)
			}

			if (!charContr.isGrounded) // In air
			{
				charContr.Move(forward + sideways + (jumpVect * Time.deltaTime));
				
				jumpVect.y -= gravity * Time.deltaTime;
			}

			if (charContr.isGrounded && Input.GetKeyDown(KeyCode.Space)) // On ground, presses space
			{
				jumpVect.y = jumpSpeed;
				charContr.Move(forward + sideways + (jumpVect * Time.deltaTime));
			}

			if (timer <= 0 && Input.GetKeyDown(KeyCode.LeftShift)) // Presses shift (dash)
			{
				StartCoroutine(DashCoroutine());
				timer = dashCooldown;
			}

			if (Input.GetKey(KeyCode.LeftControl)) // Left control (crouch)
			{
				coll.height = 1;
				charContr.height = 1;
			}
			else
			{
				coll.height = 2;
				charContr.height = 2;
			}
		}
		if (timer >= 0) timer -= Time.deltaTime;

		if (!canMove) charContr.Move(new Vector3(0, 0, 0)); // Stops movement
	}
	private IEnumerator DashCoroutine()
    {
		float start = Time.time;
		while (Time.time < start + dashTime)
        {
			charContr.Move(moveDir * Time.deltaTime);
			yield return null;
        }
    }
}
