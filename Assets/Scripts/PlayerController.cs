using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text gameOver;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		gameOver.text = "";
	}

	void Update () 
	{
	
	}

	void FixedUpdate()
	{
		var moveHorizontal = Input.GetAxis ("Horizontal");
		var moveVertical = Input.GetAxis ("Vertical");
		var movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = string.Format ("Count: {0}", count);
		if (count >= 13)
			gameOver.text = "You Win!";

	}
}
