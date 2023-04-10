using UnityEngine;

namespace Pokoro
{
	//! Intermediate Lesson: Pooling
	//Destroys any set of pipes that hits it
	public class PipeDestroyer : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<Pipes>())
			{
				// Debug.Log("Object hits destroyer");
				Destroy(other.gameObject);
			}
		}
	}
}