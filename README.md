# FlyingBird

「FlyingBirdを2hでつくろう」のゲームハンズオン用の資料です。
Unity初心者向けに作成しました。

# 準備

- PC
- Unity5 (install済みにする)

できれば

- Mouse (editorでカメラの操作がやすい)

# 手順

## Game1. Sceneを作ろう
======================

### Step1. Projectを作ろう

設定は2Dにする

### Step2. Sceneを作ろう

- CMD+Sで保存
- Assets/App/Scenes/Main.scene として保存

### Step3. プレイボタンを押してみよう

画面上部の再生ボタンを押す

### Step4. 画面を縦にしよう

Gameパネルのアスペクト比の設定を 9:16に変更

## Game2. 背景と地面を設定しよう
============================

### Step1. 背景を設定しよう

HierarchyからMainCameraを選択

- Backgroundの項目を選択
- HEX: 6EC1CA00 / rgba(110,193,202,0)

### Step2. 地面を配置しよう

### Step3. キャラクターを配置しよう


## Game3. キャラクターを動かそう
============================

### Step1. キャラクターに重力をつけよう

AddComponent > Rigid Body 2D

### Step2. スペースボタンを押したらキャラが上にジャンプするようにしよう

```
using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	public float forceY;
	public float clampVelocity;
	private Rigidbody2D rigidbody;

	void Start () {
		this.rigidbody = this.GetComponent<Rigidbody2D>();
	}

	void Update () {
		// 速度制限を設ける
		this.rigidbody.velocity = Vector3.ClampMagnitude(this.rigidbody.velocity, clampVelocity);

		if (Input.GetKeyDown("space")) {
			this.MoveUp();
		}
	}

	void MoveUp() {
		// 速度をゼロにする
		this.rigidbody.velocity = Vector3.zero;

		// 上方向(Y)に力を加える
		this.rigidbody.AddForce(new Vector2(0, forceY));
	}
}
```

forceYは200くらいがおすすめ.
clampVelocityは5くらいで.

## Game4. 接地できるようにしよう
=========================

### Step1. birdにBoxCollider2Dをアタッチする

### Step2. 地面にBoxCollider2Dをアタッチする

## Game5. 障害物をつくろう
=======================

### Step1. 障害物を配置しよう

ドカン上/下を配置
(0,7.5,0), (0,-7.5,0)

地面の位置をz:-1

### Step2. 障害物に当たり判定をつけよう

ドカンにBoxCollider2Dをつける

### Step3. 障害物を動かすようにしよう

```
using UnityEngine;
using System.Collections;

public class Dokan : MonoBehaviour {
	public float speed;

	void Update () {
		this.transform.Translate(new Vector3(-Time.deltaTime * speed, 0, 0));
	}
}
```

Scriptを書いてアタッチする

## Game6. 障害物を自動生成しよう
============================

### Step1. Dokanをprefabにしよう

PrefabsのフォルダにHierarchyからDrag & Drop

### Step2. DokanSpawnerを作成しよう

DokanSpawnerを作成

```
using UnityEngine;
using System.Collections;

public class DokanSpawner : MonoBehaviour {
	public GameObject prefab;
	public float intervalSecond = 1.0f;

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
```

### Step3. 上下にランダムで移動させよう

```
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
```

## Game7. 障害物にあたったらリスタートしよう

### Step1. Birdにタグを付けよう

タグ > Player

### Step2. キャラクターが接地したらリスタートするようにしよう

```
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy : MonoBehaviour {
	private Collider2D collider;

	void Start () {
		this.collider = this.GetComponent<Collider2D>();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			SceneManager.LoadScene("Main");
		}
	}
}
```

## Game8. スコアを表示しよう
=========================

## Game9. リザルトを作ろう
=======================

## Game10. SEをつけよう
=====================

## Game11. BGMをつけよう
=======================

## Game12. ゲームをwebに書きだそう
===============================
