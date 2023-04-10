using UnityEngine;

namespace Pokoro
{
	//Moves a game object at specified speed
	public class Mover : MonoBehaviour
	{
		public float speed = -1f;

		void Update()
		{
			//! Show difference between .Translate() and .position
			//! Explain why we need to use .deltaTime
			//Move from right to left
			transform.Translate(speed * Time.deltaTime, 0, 0);
			// transform.position = transform.position * Vector2.left * speed * Time.deltaTime;
		}
	}
}