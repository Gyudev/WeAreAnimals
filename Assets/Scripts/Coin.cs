using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	private GameManager gameManager;

	private Rigidbody2D coinRigid;

	private float timer = 0f;
	private float waitingTimer = 1f;

	private void Awake()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void Start()
	{
		coinRigid = GetComponent<Rigidbody2D>();
		if (gameObject.tag == "Coin")
		{
			int randomForceX = Random.Range(-60, 61);
			coinRigid.AddForce(new Vector2(randomForceX, 100));
		}
		else if(gameObject.tag == "Stone")
		{
			int randomForceX = Random.Range(-60, 61);
			coinRigid.AddForce(new Vector2(randomForceX, 100));		
		}
		timer = 0f;
}

	private void FixedUpdate()
	{
		timer += Time.deltaTime;

		if(waitingTimer <= timer)
		{
			coinRigid.gravityScale = 0.1f;
			if (gameObject.tag == "Coin")
			{
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, gameManager.coinTarget.transform.position, 5f * Time.deltaTime);
			}
			else if (gameObject.tag == "Stone")
			{
				gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, gameManager.stoneTarget.transform.position, 5f * Time.deltaTime);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "CoinBackground")
		{
			gameManager.AddCoin();
			Destroy(gameObject, 0f);
		}
		else if(collision.tag == "StoneBackground")
		{
			gameManager.AddStone();
			Destroy(gameObject, 0f);
		}
	}
}
