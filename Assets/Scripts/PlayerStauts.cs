using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStauts : MonoBehaviour
{
	public GameObject bulletPrefab;
	//private GameObject player;

	private float timeSpawnBullet;
	public float spawnBullet = 1f;
	private Transform targetMonster;

	private void Awake()
	{
		targetMonster = FindObjectOfType<MonsterStatus>().transform;
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
