using Meta.XR.MRUtilityKit;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public float spawnTimer = 2f;              // Zombie pojawiaj� si� co 2 sekundy
    public GameObject prefabToSpawn;           // Prefab zombie

    public float minEdgeDistance = 0.3f;       // Minimalna odleg�o�� od kraw�dzi
    public MRUKAnchor.SceneLabels spawnLabels; // Typ powierzchni (np. Wall)
    public float normalOffset = 0.2f;          // Przesuni�cie od �ciany

    public int spawnTry = 50;                  // Ile pr�b szukania miejsca
    public int maxZombies = 15;                // Maksymalnie aktywnych zombie

    private float timer = 0f;
    private int currentZombieCount = 0;

    void Update()
    {
        // Sprawd� czy MRUK jest gotowy
        if (MRUK.Instance == null || !MRUK.Instance.IsInitialized)
            return;

        // Odliczanie czasu
        timer += Time.deltaTime;
        if (timer > spawnTimer)
        {
            timer = 0f;
            SpawnZombie();
        }
    }

    public void SpawnZombie()
    {
        if (currentZombieCount >= maxZombies)
            return;

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        int currentTry = 0;

        while (currentTry < spawnTry)
        {
            bool found = room.GenerateRandomPositionOnSurface(
                MRUK.SurfaceType.VERTICAL,
                minEdgeDistance,
                new LabelFilter(spawnLabels),
                out Vector3 pos,
                out Vector3 norm
            );

            if (found)
            {
                Vector3 spawnPos = pos + norm * normalOffset;
                spawnPos.y = 0; // Dopasuj do pod�ogi

                Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
                currentZombieCount++;
                return;
            }

            currentTry++;
        }
    }

    // Wywo�ywane przez zombie przy �mierci
    public void NotifyZombieDied()
    {
        currentZombieCount = Mathf.Max(0, currentZombieCount - 1);
    }
}
