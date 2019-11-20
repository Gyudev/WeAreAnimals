using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterStatus : MonoBehaviour
{
	public GameObject bulletPrefab;

	private float timeSpawnBullet;
	public float spawnBullet = 1f;

	public float monsterHp = 5f;
	public float playerTestDamage = 1f;
	public Image hpImage;
	private Rigidbody2D monsterRigidbody;

    private void Start()
    {
		monsterRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

	private void FixedUpdate()
	{
		timeSpawnBullet += Time.deltaTime;
		if (spawnBullet <= timeSpawnBullet)
		{
			timeSpawnBullet = 0f;
			BulletFire();
		}
	}

	private void BulletFire()
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Bullet")
		{
			DiscountMonsterHp();
		}
	}

	private void DiscountMonsterHp()
	{
		hpImage.fillAmount -= playerTestDamage / monsterHp;

		if(hpImage.fillAmount <= 0)
		{
			monsterRigidbody.AddForce(new Vector2(500f, 300f));
		}
	}
}
