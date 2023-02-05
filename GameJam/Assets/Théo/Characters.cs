using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Characters : MonoBehaviour
{
	#region Variables

	public float speedCharacter = 50;
	public float duration = 10^4;
	public float strength = 1;
	public int vibrato = 0;
	public float randomness = 0;
	public bool snapping = false;
	public bool fadeOut = true;
	public ShakeRandomnessMode randomnessMode;
	
	private Rigidbody2D characterRigidbody; // RigidBody de mon personnage

	#endregion Variables

	void Update()
	{
        DotWeen();

        Vector3 posHeadingPoint = new Vector3(transform.position.x + 3, transform.position.y + 3, transform.position.z);
        transform.position = posHeadingPoint;

        Vector3 direction = posHeadingPoint - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		characterRigidbody.rotation = angle;
		direction.Normalize();
		Vector2 movement = direction;
		MoveCharacter(movement);
	}

    void DotWeen()
    {
        transform.DOShakePosition(duration, strength, vibrato, randomness, snapping = false, fadeOut = true, randomnessMode = ShakeRandomnessMode.Full);
    }

    void MoveCharacter(Vector2 direction)
	{
		characterRigidbody.MovePosition((Vector2)transform.position + (direction * (speedCharacter) * Time.deltaTime));
	}
}
