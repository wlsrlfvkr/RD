using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsWaveSpawner : MonoBehaviour {
	public Transform enemyPrefeb; //소환할 Enemy의 프리팹

	public Transform spawnPoint; //Enemy가 스폰될 START 오브젝트의 Transform값 파라미터

	public float timeBetweenWaves = 5f; //웨이브 간 간격 설정
	private float countDown = 2f; //타이머, 초기값이 2 이므로 게임 시작 시 첫 웨이브는 2초 후 시작됨

	private int waveIndex = 0; //웨이브 마다 스폰 할 Enemy의 갯수

	void Update() {
		if (countDown <= 0f) {
			StartCoroutine (SpawnWave());
			countDown = timeBetweenWaves;
		}

		countDown -= Time.deltaTime;
		//Coroutine으로 바꿔보자.
	}

	IEnumerator SpawnWave() {

		waveIndex++;

		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}

	}

	void SpawnEnemy() {
		Instantiate (enemyPrefeb,spawnPoint.position,spawnPoint.rotation);
	}
}
