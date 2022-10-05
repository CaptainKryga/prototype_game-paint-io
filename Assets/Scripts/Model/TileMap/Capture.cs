using Test;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Model.TileMap
{
	public class Capture : PTilemap
	{
		[SerializeField] private TilemapInstance tilemapInstance;

		[SerializeField] private LeminLogic leminLogic;

		[SerializeField] private GameObject prefabDebug;
		[SerializeField] private Transform parentDebug;

		private int[][] test;

		private LeminCell[][] cells;

		public void UpdateCapture(Vector3Int[] path)
		{
			if (path == null)
				return;
			
			
			for (int x = 0; x < cells.Length; x++)
			{
				for (int y = 0; y < cells.Length; y++)
				{
					cells[x][y].Debug = cells[x][y].type == Lemin.ECaptured.clear ? "-" :
						cells[x][y].type.ToString().Substring(0, 2);
				}
			}

			Vector3Int[] captured = leminLogic.GetCapturedCells(path, cells);
			
			for (int x = 0; x < path.Length; x++)
			{
				capture.SetTile(path[x], tile);
				capture.SetTileFlags(path[x], TileFlags.None);
				capture.SetColor(path[x], colorCapture);
				cells[path[x].x][path[x].y].type = Lemin.ECaptured.capture;
			}
			
			for (int x = 0; x < captured.Length; x++)
			{
				capture.SetTile(captured[x], tile);
				capture.SetTileFlags(captured[x], TileFlags.None);
				capture.SetColor(captured[x], colorCapture);
				cells[captured[x].x][captured[x].y].type = Lemin.ECaptured.capture;
			}
			
		}

		public void Init(Vector3Int pos, Color colorGhost, Color colorCapture)
		{
			this.colorCapture = colorCapture;
			this.colorGhost = colorGhost;

			this.cells = tilemapInstance.GetCells;

			InitCell(pos);
			InitCell(pos + Vector3Int.down * 1);
			InitCell(pos + Vector3Int.down * 2);
			InitCell(pos + Vector3Int.down * 3);
		}

		private void InitCell(Vector3Int pos)
		{
			capture.SetTile(pos, tile);
			capture.SetTileFlags(pos, TileFlags.None);
			capture.SetColor(pos, this.colorCapture);
			cells[pos.x][pos.y].type = Lemin.ECaptured.capture;
		}

	}
}
