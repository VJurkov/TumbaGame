﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
	// ====== ENEMY MOVEMENT ========
	public float speed;
	public float timeToChange;
	public bool horizontal;

	public GameObject smokeParticleEffect;
	public ParticleSystem fixedParticleEffect;

	public AudioClip hitSound;
	public AudioClip fixedSound;
	
	Rigidbody2D rigidbody2d;
	float remainingTimeToChange;
	Vector2 direction = Vector2.right;
	bool repaired = false;
	
	// ===== ANIMATION ========
	Animator animator;
	
	// ================= SOUNDS =======================
	AudioSource audioSource;
	
	void Start ()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		remainingTimeToChange = timeToChange;

		direction = horizontal ? Vector2.right : Vector2.down;

		animator = GetComponent<Animator>();

		audioSource = GetComponent<AudioSource>();
	}
	
	void Update()
	{
		if(repaired)
			return;
		
		remainingTimeToChange -= Time.deltaTime;

		if (remainingTimeToChange <= 0)
		{
			remainingTimeToChange += timeToChange;
			direction *= -1;
		}
		
		rigidbody2d.MovePosition(rigidbody2d.position + direction * speed * Time.deltaTime);
		
		animator.SetFloat("ForwardX", direction.x);
		animator.SetFloat("ForwardY", direction.y);
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if(repaired)
			return;

		TumbaController controller = other.collider.GetComponent<TumbaController>();
       

        //if(controller != null)
            //ScoreTextScript.coinAmout += 1;
        //controller.ChangeHealth(-1);
    }

	public void Fix()
	{
		animator.SetTrigger("Fixed");
		repaired = true;
        //kad pogodim neprijatelja +5 bodova
        ScoreTextScript.coinAmout += 5;
        smokeParticleEffect.SetActive(false);

		Instantiate(fixedParticleEffect, transform.position + Vector3.up * 0.5f, Quaternion.identity);

		//we don't want that enemy to react to the player or bullet anymore, remove its reigidbody from the simulation
		rigidbody2d.simulated = false;
		
		audioSource.Stop();
		audioSource.PlayOneShot(hitSound);
		audioSource.PlayOneShot(fixedSound);
	}
}
