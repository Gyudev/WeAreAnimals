using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerStauts : MonoBehaviour
{
	public MonsterStatus monsterStatus;

	public GameObject bulletPrefab;
	private Animator playerAnim;
	public Image playerHpBar;
	public Rigidbody2D playerRigid;


	private AudioSource audioSource;
	public AudioClip audioJump;
	public AudioClip audioAttack;
	public AudioClip audioDie;

	private EventTrigger jumpButton;

	private float timeSpawnBullet;
	public float spawnBullet = 1f;

	public bool isDie = false;

	public float playerHp { get; set; }
	public float playerDamage { get; set; }

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		playerAnim = GetComponent<Animator>();

		jumpButton = GameObject.Find("Canvas").transform.Find("Jump Button").GetComponent<EventTrigger>();

		EventTrigger.Entry jumpButtonClick = new EventTrigger.Entry();
		jumpButtonClick.eventID = EventTriggerType.PointerDown;
		jumpButtonClick.callback.AddListener((data) => { JumpButton((PointerEventData)data); });
		jumpButton.triggers.Add(jumpButtonClick);
	}

	private void Start()
	{
		playerHp = 10f;
		playerDamage = 10f;
	}

	private void Update()
	{

	}

	private void FixedUpdate()
	{
		if (!isDie || !monsterStatus.isDie)
		{
			timeSpawnBullet += Time.deltaTime;
			if (spawnBullet <= timeSpawnBullet)
			{
				ResetTime();
				Attack();
			}
		}
		// 캐릭터가 다시 점프 할 수 있게 함
		if (playerRigid.velocity.y == 0)
		{
			playerAnim.SetBool("isJump", false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "MonsterBullet")
		{
			playerHpBar.fillAmount -= monsterStatus.monsterDamage / playerHp;
			if (playerHpBar.fillAmount <= 0.001f)
			{
				PlayerDie();
			}
		}
	}

	private void ResetTime()
	{
		timeSpawnBullet = 0f;
	}

	private void PlayerDie()
	{
		ResetTime();
		PlaySound("Die");
		isDie = true;
		playerRigid.AddForce(new Vector2(0f, 50f));
		playerAnim.SetInteger("intDie", 0);
	}

	private void Attack()
	{
		if (!isDie && !monsterStatus.isDie)
		{
			PlaySound("Attack");
			playerAnim.SetTrigger("doAttack");
			GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
		}
	}

	private void JumpButton(PointerEventData data)
	{
		ResetTime();
		Jump();
	}

	private void Jump()
	{
		// 캐릭터의 y속도가 0이거나 죽지 않았을때 점프
		if (!isDie && playerRigid.velocity.y == 0)
		{
			playerAnim.SetBool("isJump", true);
			PlaySound("Jump");
			playerRigid.AddForce(new Vector2(0f, 500f));
		}
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
