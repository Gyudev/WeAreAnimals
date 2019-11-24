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


	private AudioSource audioSource;
	public AudioClip audioJump;
	public AudioClip audioAttack;
	public AudioClip audioDie;

	private float timeSpawnBullet;
	public float spawnBullet = 1f;

	private bool isDie = false;

	public float playerHp	{ get; set;	}
	public float playerDamage { get; set; }

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
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
		if (!isDie)
		{
			timeSpawnBullet += Time.deltaTime;
			if (spawnBullet <= timeSpawnBullet)
			{
				timeSpawnBullet = 0f;
				Attack();
			}
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
		PlaySound("Die");
		isDie = true;
		playerRigid.AddForce(new Vector2(0f, 50f));
		dogAnim.SetInteger("intDie", 0);
	}

	private void Attack()
	{
		PlaySound("Attack");
		dogAnim.SetTrigger("doAttack");
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
	}

	private void JumpButton()
	{
		Jump();
	}

	private void Jump()
	{
		PlaySound("Jump");
		playerRigid.AddForce(new Vector2(0f, 400f));
	}

	private void PlaySound(string action)
	{
		switch (action)
		{
			case "Jump":
				audioSource.clip = audioJump;
				break;
			case "Die":
				audioSource.clip = audioDie;
				break;
			case "Attack":
				audioSource.clip = audioAttack;
				break;
		}
		audioSource.Play();
	}
}
