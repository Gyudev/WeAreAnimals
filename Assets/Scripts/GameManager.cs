using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private Transform submenuPanel;
	private Transform submenu;

	private Button stopButton;
	private Button menuExitButton;
	private Button continueButton;
	private Button restartButton;
	private Button exitButton;

	private Text countdownText;
	
	private bool isStop = false;

	private void Awake()
    {
		//Screen.SetResolution(1280, 720, true);
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

    
    private void Update()
    {
		// 계속하기를 눌렀을 때 카운트 다운
		if (isStop)
		{
			isStop = false;
			StartCoroutine(CountdownTimer(4));
		}
    }

	IEnumerator CountdownTimer(float countTime)
	{
		float lastTime = Time.realtimeSinceStartup;
		float processTime = 0;
		float countdown = 0;

		while(processTime + 1f <= countTime)
		{
			processTime = Time.realtimeSinceStartup - lastTime;
			countdown = countTime - processTime;
			countdown = (int)countdown;
			countdownText.text = countdown.ToString();
			Debug.Log((int)countdown);
			yield return null;
		}
		submenu.gameObject.SetActive(true);
		submenuPanel.gameObject.SetActive(false);

		Time.timeScale = 1;
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
