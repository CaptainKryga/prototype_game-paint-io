using System;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
	public class VController : MonoBehaviour
	{
		[SerializeField] private Controller.Controller controller;

		[SerializeField] private GameObject panelPlayerInit;
		[SerializeField] private GameObject panelGameOver;

		[SerializeField] private Button btnStartBattle;
		[SerializeField] private InputField inputFieldPlayerName;

		private string playerName;
		private int playerId;

		private void Start()
		{
			panelPlayerInit.SetActive(false);
			panelGameOver.SetActive(false);
		}

		public void ConsoleCommand(string command)
		{
			controller.ConsoleCommand(command);
		}

		public void InitPlayer()
		{
			panelPlayerInit.SetActive(true);
		}

		public void GameOver()
		{
			panelGameOver.SetActive(true);
		}

		public void OnClick_StartBattle()
		{
			controller.Restart(playerName, playerId);
		}

		public void ReceiveStartBattle(bool isFlag)
		{
			if (isFlag)
			{
				panelPlayerInit.SetActive(false);
				panelGameOver.SetActive(false);
			}
			else
			{
				///////////////////////////////////////////////////////////////
				Debug.Log("Message BOX");
			}
		}

		public void OnClick_SetPlayerFlag(int id)
		{
			playerId = id;
		}

		public void OnInputField_SetName()
		{
			playerName = inputFieldPlayerName.text;
		}
	}
}