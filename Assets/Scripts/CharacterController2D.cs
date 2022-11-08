using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class CharacterController2D : MonoBehaviour
{
	[Range(0, .3f)] [SerializeField] float movementSmoothing = .05f;
	[SerializeField] float jumpForce = 400f;
	[SerializeField] float dashSideForce = 700f;
	[SerializeField] float dashDownForce = 700f;
	[SerializeField] bool airControl = false;
	[SerializeField] LayerMask whatIsGround;
	[SerializeField] Transform groundCheck;
	[SerializeField] Transform ceilingCheck;
	ParticleSystem dashPS;

	[SerializeField] AudioClip dashAudioClip, jumpAudioClip;
	AudioSource audioSource;
	bool hasPlayed;

	const float groundedRadius = .2f;
	bool grounded;
	const float ceilingRadius = .2f;
	Rigidbody2D rb;
	bool facingRight = true;
	Vector3 velocity = Vector3.zero;
	public UnityEvent OnLandEvent;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		dashPS = GetComponentInChildren<ParticleSystem>();
		Time.timeScale = 1;
		rb = GetComponent<Rigidbody2D>();
		if (OnLandEvent == null) { OnLandEvent = new UnityEvent(); }
	}

	private void FixedUpdate()
	{
		bool wasGrounded = grounded;
		grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject) { grounded = true; if (!wasGrounded) { OnLandEvent.Invoke(); } }
		}
	}


	public void Move(float move, bool jump, bool dashDown, bool dashLeft, bool dashRight)
		{
		if (grounded || airControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
			if (move > 0 && !facingRight) { Flip(); }
			else if (move < 0 && facingRight) { Flip(); }
			if (dashLeft) { rb.AddForce(new Vector2(-dashSideForce, 0f)); dashPS.Play(); if (!hasPlayed) { StartCoroutine(PlayDashAudio()); } }
            if (dashRight) { rb.AddForce(new Vector2(dashSideForce, 0f)); dashPS.Play(); if (!hasPlayed) { StartCoroutine(PlayDashAudio()); } }

		}
		if (grounded && jump)
		{
			grounded = false;
			audioSource.PlayOneShot(jumpAudioClip);
			rb.AddForce(new Vector2(0f, jumpForce));
		}
		if (!grounded && dashDown) { rb.AddForce(new Vector2(0f, -dashDownForce)); }
	}

	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator PlayDashAudio()
    {
		audioSource.PlayOneShot(dashAudioClip); hasPlayed = true;
		yield return new WaitForSeconds(0.5f); hasPlayed = false;
	}
}
