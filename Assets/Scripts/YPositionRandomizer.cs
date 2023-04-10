using UnityEngine;

namespace Pokoro
{
	public class YPositionRandomizer : MonoBehaviour
	{
		public float maxOffset;

		void Start()
		{
			var offset = Random.Range(-maxOffset / 2f, maxOffset / 2f);	//! Slight optimize with * 0.5 instead

			//! Explaing Debug.Log()/LogError() etc
			//! Explain print()
			print(offset);
			transform.Translate(new Vector2(0, offset));
		}
	}
}