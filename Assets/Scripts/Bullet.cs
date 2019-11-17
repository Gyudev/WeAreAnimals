using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float bulletSpeed = 500f;
	private Rigidbody2D bulletRigidbody;

	private void Start()
	{
		bulletRigidbody = GetComponent<Rigidbody2D>();
		bulletRigidbody.AddForce(new Vector2(bulletSpeed, 0));

		Destroy(gameObject, 2f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Monster")
		{
			Destroy(gameObject);
		}
	}
}