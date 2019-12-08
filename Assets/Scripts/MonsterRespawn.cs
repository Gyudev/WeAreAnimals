using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRespawn : MonoBehaviour
{
	public MonsterStatus monsterStatus;
	
	public Transform spawnPoints;

	private void Awake()
	{
		spawnPoints = GetComponent<Transform>();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void CreateMonster()
	{
		MonsterStatus.isDie = false;
		MonsterStatus monster = Instantiate(monsterStatus, spawnPoints.position, spawnPoints.rotation);
	}
}
