using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private Transform submenuPanel;
	private Transform submenu;

	private Button stopButton;
	private Button menuExitButton;
	private Button continueButton;
	private Button restartButton;
	private Button exitButton;

	public GameObject coinTarget;
	public GameObject stoneTarget;

	public AudioSource coinAudioSource;
	public AudioSource stoneAudioSource;

	public AudioClip coinAudioClip;
	public AudioClip stoneAudioClip;

	public MonsterStatus monsterStatus;
	public GameObject monsterPrefab;
	public GameObject moinsterRespawnPosition;

	public Text coinText;
	public Text stoneText;

	private Text countdownText;

	private int coin;
	private int stone;
	
	private bool isStop = true;

	private void Awake()
    {
		submenuPanel = GameObject.Find("Canvas").transform.Find("Submenu Panel").GetComponent<Transform>();
		submenu = submenuPanel.transform.Find("Submenu").GetComponent<Transform>();

		stopButton = GameObject.Find("Canvas").transform.Find("Stop Button").GetComponent<Button>();
		stopButton.onClick.AddListener(StopButton);

		menuExitButton = submenu.transform.Find("Menu Exit").GetComponent<Button>();
		menuExitButton.onClick.AddListener(MenuExitButton);

		continueButton = submenu.transform.Find("Continue").GetComponent<Button>();
		continueButton.onClick.AddListener(ContinueButton);
		restartButton = submenu.transform.Find("Restart").GetComponent<Button>();
		restartButton.onClick.AddListener(RestartButton);
		exitButton = submenu.transform.Find("Exit").GetComponent<Button>();
		exitButton.onClick.AddListener(ExitButton);

		countdownText = submenuPanel.transform.Find("Countdown").GetComponent<Text>();
	}

	private void Start()
	{
		Time.timeScale = 0;
		coin = 0;
		stone = 0;
		coinText.text = coin.ToString();
		stoneText.text = stone.ToString();
		coinAudioSource.clip = coinAudioClip;
		stoneAudioSource.clip = stoneAudioClip;
		GameObject monster = Instantiate(monsterPrefab, moinsterRespawnPosition.transform.position, moinsterRespawnPosition.transform.rotation);
	}


	private void Update()
    {
		// 계속하기를 눌렀을 때 카운트 다운
		if (isStop)
		{
			isStop = false;
			StartCoroutine(CountdownTimer(4));
		}

		if (monsterStatus.isDie)
		{
			
		}
    }

	IEnumerator CountdownTimer(float countTime)
	{
		//3초 카운트 다운
		float lastTime = Time.realtimeSinceStartup;
		float processTime = 0;
		float countdown = 0;

		while(processTime + 1.1f <= countTime)
		{
			processTime = Time.realtimeSinceStartup - lastTime;
			countdown = countTime - processTime;
			countdown = (int)countdown;
			countdownText.text = countdown.ToString();

			yield return null;
		}
		submenu.gameObject.SetActive(true);
		submenuPanel.gameObject.SetActive(false);

		Time.timeScale = 1;
	}

	private void MonsterRespawn()
	{
		GameObject monster = Instantiate(monsterPrefab, transform.position, transform.rotation);
	}

	private void StopButton()
	{
		Time.timeScale = 0;
		submenuPanel.gameObject.SetActive(true);
	}

	private void MenuExitButton()
	{
		Continue();
	}

	private void ContinueButton()
	{
		Continue();
	}

	private void RestartButton()
	{
		SceneManager.LoadScene(0);
	}

	public void AddCoin(int coinValue)
	{
		coinAudioSource.Play();
		coin += coinValue;
		coinText.text = coin.ToString();
	}

	public void AddStone()
	{
		stoneAudioSource.Play();
		stone += 1;
		stoneText.text = stone.ToString();
	}

	private void ExitButton()
	{

	}

	private void Continue()
	{
		isStop = true;
		submenu.gameObject.SetActive(false);
	}
}
