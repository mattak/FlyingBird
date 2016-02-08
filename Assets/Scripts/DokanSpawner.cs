using UnityEngine;
using System.Collections;

public class DokanSpawner : MonoBehaviour {
	public GameObject prefab;
	public float intervalSecond = 1.0f;
	public float randomOffsetY = 5f;

	// Use this for initialization
	void Start () {
		StartCoroutine("Spawn");
	}

	IEnumerator Spawn() {
		while(true) {
			float differenceY = (Random.value - 0.5f) * randomOffsetY;
			Vector3 difference = new Vector3(0, differenceY, 0);
			Instantiate(prefab, this.transform.position + difference, prefab.transform.rotation);
			yield return new WaitForSeconds(intervalSecond);
		}
	}
}