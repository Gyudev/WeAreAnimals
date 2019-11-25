using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	private Button jumpButton;

	private float timeSpawnBullet;
	public float spawnBullet = 1f;

	public bool isDie = false;

	public float playerHp	{ get; set;	}
	public float playerDamage { get; set; }

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		playerAnim = GetComponent<Animator>();
		jumpButton = GameObject.Find("Canvas").transform.Find("Jump Button").GetComponent<Button>();
		jumpButton.onClick.AddListener(JumpButton);
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
		if (!isDie || !monsterStatus.isDie)
		{
			timeSpawnBullet += Time.deltaTime;
			if (spawnBullet <= timeSpawnBullet)
			{
				timeSpawnBullet = 0f;
				Attack();
			}
		}

		Debug.DrawRay(playerRigid.position, Vector3.down, new Color(0, 1, 0));

		RaycastHit2D playerRayHit = Physics2D.Raycast(playerRigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

		if (playerRayHit.collider != null)
		{

			if (playerRayHit.distance < 0.62f)
			{
				playerAnim.SetBool("isJump", false);
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
		playerAnim.SetInteger("intDie", 0);
	}

	private void Attack()
	{
		PlaySound("Attack");
		playerAnim.SetTrigger("doAttack");
		GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
	}

	private void JumpButton()
	{
		Jump();
	}

	private void Jump()
	{
		if (!playerAnim.GetBool("isJump"))
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
