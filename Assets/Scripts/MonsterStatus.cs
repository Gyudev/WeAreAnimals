using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatus : MonoBehaviour
{
	public PlayerStauts playerStauts;

	public GameObject bulletPrefab;
	public GameObject coinPrefab;
	public GameObject stonePrefab;
	public GameObject monster;

	private Rigidbody2D monsterRigid;
	
	public Image monsterHpBar;


	private float timeSpawnBullet;
	public float spawnBullet = 2f;

	public bool isDie = false;

	public float monsterHp { get; set; }
	public float monsterDamage { get; set; }

	private void Start()
    {
		monsterRigid = GetComponent<Rigidbody2D>();
		monsterHp = 5f;
		monsterDamage = 0f;
    }

    private void Update()
    {
        
    }

	private void FixedUpdate()
	{
		if (!isDie || !playerStauts.isDie)
		{
			timeSpawnBullet += Time.deltaTime;
			if (spawnBullet <= timeSpawnBullet)
			{
				ResetTime();
				Attack();
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Bullet")
		{
			monsterHpBar.fillAmount -= playerStauts.playerDamage / monsterHp;

			if (monsterHpBar.fillAmount <= 0.1f)
			{
				MonsterDie();
			}
		}
	}
	private void ResetTime()
	{
		timeSpawnBullet = 0;
	}

	private void MonsterDie()
	{
		ResetTime();
		GetCoin();
		GetStone();

		isDie = true;
		
		monsterRigid.AddForce(new Vector2(300f, 100f));
		Destroy(monster, 1f);
	}

	private void GetCoin()
	{
		int randomCoin = Random.Range(0, 6);
		for (int i = 0; i < randomCoin; i++)
		{
			GameObject coin = Instantiate(coinPrefab, transform.position, transform.rotation);
		}
	}

	private void GetStone()
	{
		int randomStone = Random.Range(0, 4);
		for(int i = 0; i < randomStone; i++)
		{
			GameObject stone = Instantiate(stonePrefab, transform.position, transform.rotation);
		}
	}

	private void Attack()
	{
		if (!playerStauts.isDie)
		{
			GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
		}
		else
		{
			ResetTime();
		}
	}

}
