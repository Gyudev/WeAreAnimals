using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStauts : MonoBehaviour
{
	public MonsterStatus monsterStatus;

	public GameObject bulletPrefab;
	private Animator dogAnim;
	public Image playerHpBar;
	public Rigidbody2D playerRigid;


	private float timeSpawnBullet;
	public float spawnBullet = 1f;

	public float playerHp	{ get; set;	}
	public float playerDamage { get; set; }

	private void Awake()
	{
		dogAnim = GetComponent<Animator>();
	}

	private void Start()
	{
		playerHp = 10f;
		playerDamage = 1f;
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
			Attck();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "MonsterBullet")
		{
			playerHpBar.fillAmount -= monsterStatus.monsterDamage / playerHp;
			if (playerHpBar.fillAmount <= 0.1f)
			{
				PlayerDie();
			}
		}
	}

	private void PlayerDie()
	{
		playerRigid.AddForce(new Vector2(0f, 200f));
		dogAnim.SetInteger("intDie", 0);
	}

	private void Attck()
	{
		dogAnim.SetTrigger("doAttack");
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
	}
}
