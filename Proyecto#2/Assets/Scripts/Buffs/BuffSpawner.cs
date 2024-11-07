using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    public GameObject[] powerUps; // Array de prefabs de buff
    public Vector2 spawnRangeX;    // Rango X donde pueden aparecer
    public Vector2 spawnRangeY;    // Rango Y donde pueden aparecer
    public float spawnInterval = 5.0f; // Intervalo entre cada aparición

    private void Start()
    {
        InvokeRepeating("SpawnRandomBuff", 2.0f, spawnInterval);
    }

    private void SpawnRandomBuff()
    {
        int index = Random.Range(0, powerUps.Length); // Selecciona un buff aleatorio
        float x = Random.Range(spawnRangeX.x, spawnRangeX.y); // Posición en X
        float y = Random.Range(spawnRangeY.x, spawnRangeY.y); // Posición en Y
        Vector3 spawnPosition = new Vector3(x, y, 0); // Coordenadas

        Instantiate(powerUps[index], spawnPosition, Quaternion.identity); // Crear el Buff
    }
}
