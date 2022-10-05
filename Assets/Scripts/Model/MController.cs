using Model.Photon;
using Model.TileMap;
using UnityEngine;
using View;

namespace Model
{
	public class MController : MonoBehaviour
	{
		[SerializeField] private PhotonConnectRoom photonConnectRoom;
		[SerializeField] private VController vController;

		[SerializeField] private TilemapInstance tilemapInstance;
		[SerializeField] private EntityInstance entityInstance;

		[SerializeField] private SyncChangeFlag syncChangeFlag;

		//connect to server and init player
		public void Init()
		{
			if (!photonConnectRoom.IsConnect)
				photonConnectRoom.ConnectToServer();
			else
				InitPlayer();
		}
		public void InitPlayer()
		{
			tilemapInstance.InitTileMap();
			vController.InitPlayer();
		}

		//restart game after death or win
		public void Restart(string playerName, int playerId)
		{
			if (playerName == "" || playerId < 1 || playerId > 15)
			{
				syncChangeFlag.SelectedPlayerFlag(playerId);
				vController.ReceiveStartBattle(false);
				return;
			}
			else
			{
				
			}
			
			entityInstance.Restart(playerName, playerId);
			//if all it's okey true
			vController.ReceiveStartBattle(true);
		}

		public void GameOver()
		{
			vController.GameOver();
		}
	}
}
