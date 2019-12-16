using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
	private Button startStage;

	public static string globalStageNumber;

	private void Start()
    {
        
    }

    private void Update()
    {
        
    }

	public void StartStage(string stageNumber)
	{
		switch (stageNumber)
		{
			case "1-1":
				globalStageNumber = "1-1";
				DontDestroyOnLoad(gameObject);
				SceneManager.LoadScene(1);
				break;
		}

	}
}
