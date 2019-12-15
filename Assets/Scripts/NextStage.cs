using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
	private Button startStage;


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
				SceneManager.LoadScene(1);
				break;
		}

	}
}
