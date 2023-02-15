using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{   //Used Brackey WaveSpawing tutorial - edited
    public static int EnemyCount = 0;

    public Waves[] waves;

    public Transform spawnPoint;
   
    public float timeBetweenWaves = 5f; 
    private float countdown = 2f; //spawn first wave

    public Text waveCountDownText;

    public GameManager gameManager;

    private int waveIndex = 0;

    private void Update()
    {
        if (EnemyCount > 0)
        {
            return;
        }
        if(countdown <= 0f) 
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }
    
    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;

        Waves wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        } 
        waveIndex++;

        if (waveIndex >= (waves.Length) && EnemyCount >= 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy) 
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemyCount++;
    }
}
