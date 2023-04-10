using UnityEngine;

namespace Pokoro
{
	//Script that just scrolls the texture, aesthetic
	public class TextureScroller : MonoBehaviour
	{
		public float scrollSpeed = 0.5f;

		Material material;

		void Start()
		{
			//! Explain getcomponent
			//! Explain .material
			material = GetComponent<Renderer>().material;
		}

		void Update()
		{
			//! We're simply scrolling the texture, use an analogy like some kinda wallpaper scroller
			material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0);
		}
	}
}