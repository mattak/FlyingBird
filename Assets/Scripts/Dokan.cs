using UnityEngine;
using System.Collections;

public class Dokan : MonoBehaviour {
	public float speed;

	void Update () {
		this.transform.Translate(new Vector3(-Time.deltaTime * speed, 0, 0));
	}
}