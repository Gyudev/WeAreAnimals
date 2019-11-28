using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private Transform submenuPanel;

	private Button stopButton;

    private void Awake()
    {
		submenuPanel = GameObject.Find("Canvas").transform.Find("Submenu Panel").GetComponent<Transform>();
		stopButton = GameObject.Find("Canvas").transform.Find("Stop Button").GetComponent<Button>();
		stopButton.onClick.AddListener(StopButton);
    }

    
    private void Update()
    {
        
    }

	private void StopButton()
	{
		submenuPanel.gameObject.SetActive(true);
	}
}
