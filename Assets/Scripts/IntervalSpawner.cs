using UnityEngine;
using System.Collections;

public class IntervalSpawner : MonoBehaviour {
	public GameObject prefab;
	public float intervalSecond = 1.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine("Spawn");
	}

	IEnumerator Spawn() {
		while(true) {
			Instantiate(prefab, this.transform.position, prefab.transform.rotation);
			yield return new WaitForSeconds(intervalSecond);
		}
	}
}