using UnityEngine;

namespace Model.Entity
{
	public class Entity : MonoBehaviour
	{
		public float moveSpeed = 5;
		public Transform movePoint;

		public LayerMask layerCollider;

		private Vector3 newVec;
		private Vector3 save;
		
		private void Start()
		{
			movePoint.parent = null;
		}

		private void Update()
		{
			transform.position = Vector3.MoveTowards(transform.position, movePoint.position,
				moveSpeed * Time.deltaTime);
			
			if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
				newVec = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
			else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
				newVec = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
			
			if (Physics2D.OverlapCircle(movePoint.position + newVec, .2f, layerCollider))
				Debug.Log("GAME OVER");
			
			if (movePoint.position == transform.position)
			{
				movePoint.position += newVec;
			}
		}
	}
}
