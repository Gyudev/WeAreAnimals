using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	public Transform stagePanel;
	public Button gameStartButton;

	private bool isStagePanel = false;

	public void StageButtonClick()
	{
		if (!isStagePanel)
		{
			stagePanel.gameObject.SetActive(true);
		}
	}
}
