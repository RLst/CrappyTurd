using UnityEngine;

namespace Pokoro
{
	//1. Put bird, pipes, background, ground assets in
	//2. Setup pipes and make it a prefab
	public class Bird : MonoBehaviour
	{
		//! Monobehaviour allows you to attach your own custom logic to objects inside the game engine
		//! It is good practice to name things accordingly; object oriented
		//! Each object has it's own logic; logic should make sense for that object; should only be related to within that object;
		//! Should minimize coupling to other objects; explain coupling and decoupling

		//1. Jumps everytime the space button is pressed
		//2. Dies if it hits a killer object
		public Rigidbody2D rigidBody;
		public bool isDead = false;
		// public float flyForce = 1f;
		// public ForceMode2D forceMode;
		public float flySpeed = 1.4f;
		public Vector2 velRange = new Vector2(-5, 5);
		public Vector2 tiltRange = new Vector2(-30, 15);

		Vector2 jumpForce;

		void Awake()
		{
			rigidBody = GetComponent<Rigidbody2D>();
		}

		void Update()
		{
			if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
			{
				// Debug.Log("jump");
				// jumpForce = new Vector2(0, flyForce);
				// rigidBody.AddForce(jumpForce, forceMode);
				rigidBody.velocity = Vector2.up * flySpeed;

			}
			print(rigidBody.velocity);

			//Handle bird tilt
			var tiltZangle = Utils.Remap(rigidBody.velocity.y, velRange.x, velRange.y, tiltRange.x, tiltRange.y);
			Quaternion rotation = Quaternion.Euler(0, 0, tiltZangle);
			transform.rotation = rotation;
		}

		void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.GetComponent<Killer>())
			{
				//Kill the bird
				// Debug.Log("Kill the bird");
				isDead = true;
			}
		}

		public void Kill()
		{
			isDead = true;
		}

		public void TakeDamage(int damage)
		{
			int health = 10;
			health -= damage;
			if (health < 0)
			{
				Kill();
			}
		}

		//! Visual Studio Code common shortcuts
		//! shifting lines up and down
		//! change theme cmd + K,T
		//! command + .
		//! set to save automatically
		//! cmd + b = sidebar
		//! cmd + j = terminal/lower console
		//! cmd + d = duplicate line
		//! cmd + . = common code actions
		//! cmd + r,r = rename symbol
		//! show minimap
		//! word wrap
	}
}