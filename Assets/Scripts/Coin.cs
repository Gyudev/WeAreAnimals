using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	private Rigidbody2D coinRigid;

	private void Start()
	{
		coinRigid = GetComponent<Rigidbody2D>();

		int randomForceX = Random.Range(-60, 61);
		coinRigid.AddForce(new Vector2(randomForceX, 100));

		Destroy(gameObject, 2f);
	}
}
