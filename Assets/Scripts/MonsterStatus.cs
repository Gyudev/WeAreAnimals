using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatus : MonoBehaviour
{
	public PlayerStauts playerStauts;

	public GameObject monster;
	private Rigidbody2D monsterRigid;

	public GameObject bulletPrefab;

	public Image monsterHpBar;


	private float timeSpawnBullet;
	public float spawnBullet = 2f;

	private bool isDie = false;

	public float monsterHp { get; set; }
	public float monsterDamage { get; set; }

	private void Start()
    {
		monsterRigid = GetComponent<Rigidbody2D>();
		monsterHp = 5f;
		monsterDamage = 10f;
    }

    private void Update()
    {
        
    }

	private void FixedUpdate()
	{
		if (!isDie)
		{
			timeSpawnBullet += Time.deltaTime;
			if (spawnBullet <= timeSpawnBullet)
			{
				timeSpawnBullet = 0;
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

	private void MonsterDie()
	{
		isDie = true;
		monsterRigid.AddForce(new Vector2(300f, 100f));
		Destroy(monster, 1f);
	}

	private void Attack()
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
	}

}
