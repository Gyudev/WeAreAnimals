using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStauts : MonoBehaviour
{
	public GameObject bulletPrefab;

	private float timeSpawnBullet;
	private float playerHp = 10f;
	public float spawnBullet = 1f;

	private void Awake()
	{
	}
	private void Start()
	{
		
	}

	private void Update()
	{
		
	}

	private void FixedUpdate()
	{
		timeSpawnBullet += Time.deltaTime;
		if(spawnBullet <= timeSpawnBullet)
		{
			timeSpawnBullet = 0f;
			BulletFire();
		}
	}

	private void PlayerDie()
	{

	}

	private void BulletFire()
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
		
	}
}
