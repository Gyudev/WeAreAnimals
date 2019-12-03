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

	private int randomCoin;
	private int randomStone;

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
		
		monsterRigid.AddForce(new Vector2(0, 100f));
		Destroy(monster, 3f);
	}

	private void GetCoin()
	{
		randomCoin = Random.Range(0, 6);
		if(randomCoin != 0)
		{
			StartCoroutine(GetCoinCount(randomCoin));
		}
	}

	IEnumerator GetCoinCount(int coinCount)
	{
		for (int i = 0; i < coinCount; i++)
		{
			GameObject coin = Instantiate(coinPrefab, transform.position, transform.rotation);
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void GetStone()
	{
		randomStone = Random.Range(0, 4);
		if(randomStone != 0)
		{
			StartCoroutine(GetStoneCount(randomStone));
		}
	}

	IEnumerator GetStoneCount(int stoneCount)
	{
		for (int i = 0; i < stoneCount; i++)
		{
			GameObject stone = Instantiate(stonePrefab, transform.position, transform.rotation);
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void Attack()
	{
		if (!playerStauts.isDie && !isDie)
		{
			GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
		}
		else
		{
			ResetTime();
		}
	}

}
