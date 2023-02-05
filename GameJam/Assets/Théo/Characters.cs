using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
	#region Variable

	public float speedCharacter = 5f;
	public float frequency = 20f;
	public float magnitude = 0.5f;
	Vector3 pos;

	public float leftLimit;
	public float currentTime = 0;
	public float timer;
	private Rigidbody2D headingPointRigidBody; // RigidBody de ma cible
	private Rigidbody2D characterRigidbody; // RigidBody de mon personnage
	public GameObject cheatTeleport; // Correspond à un gameObject vide que j'utilise pour déplacer mon personnage dessus. Je l'utilise pour faire des essais et itérer
	public GameObject headingPoint;
	public GameObject character;

	#endregion Variable

	void Start()
	{
		pos = transform.position;
	}

	void Update()
	{
		MoveLeft();

		//MovingGameObjects(character);

		headingPoint.transform.SetPositionAndRotation(new Vector3(character.transform.position.x + 3, character.transform.position.y + 3, headingPointRigidBody.transform.position.z), Quaternion.Euler(Vector2.zero));

		Vector3 direction = headingPoint.transform.position - this.transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		characterRigidbody.rotation = angle;
		direction.Normalize();
		Vector2 movement = direction;
		MoveCharacter(movement);
	}

	void MoveLeft()
	{
		pos -= transform.right * Time.deltaTime * speedCharacter;
		transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

	//public void MovingGameObjects(GameObject a)
	//{
	//	a.transform.Translate((speedCharacter) * Time.deltaTime, 0, 0);
	//}

	void MoveCharacter(Vector2 direction)
	{
		characterRigidbody.MovePosition((Vector2)transform.position + (direction * (speedCharacter) * Time.deltaTime));
	}
}
