using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.AR.HitTest;
using Niantic.ARDK.External;
using Niantic.ARDK.Utilities;
using Niantic.ARDK.Utilities.Input.Legacy;

public class SpawnObjectController : MonoBehaviour
{

    [HideInInspector]
    public SpawnObjectHolderController OHcontroller;

    public float spawnDelay = 5f; // Délai avant apparition
    public float spawnRadius = 2f; // Rayon de distance entre l'objet et le joueur
    public float fishSpawnDuration = 10f; //Délai avant disparition du fish
    public float whaleSpawnDuration = 10f; //Délai avant disparition de la whale
    public float fishSpawnRate; //Taux d'apparition des poissons, par secondes
    


    public GameObject shark; //Pour avoir la position du requin en temps réel
    private Vector3 sharkPosition;

    /// The camera used to render the scene. Used to get the center of the screen.
    public Camera Camera;


    /// The object we will place when we get a valid hit test result!
    public GameObject[] prefabs;

    /// A list of placed game objects to be destroyed in the OnDestroy method.
    private List<GameObject> _placedObjects = new List<GameObject>();
    public GameObject whalePrefab;
    public float whaleSpeed;
    public float whaleSpawnRate; //Taux d'apparition des poissons, par secondes
    
    /// Internal reference to the session, used to get the current frame to hit test against.
    private IARSession _session;

    private bool objectsSpawning = false;


    private void Start()
    {
        ARSessionFactory.SessionInitialized += OnAnyARSessionDidInitialize;
    }

    private void OnAnyARSessionDidInitialize(AnyARSessionInitializedArgs args)
    {
        _session = args.Session;
        _session.Deinitialized += OnSessionDeinitialized;
    }

    private void OnSessionDeinitialized(ARSessionDeinitializedArgs args)
    {
        ClearObjects();
    }

    private void OnDestroy()
    {
        ARSessionFactory.SessionInitialized -= OnAnyARSessionDidInitialize;

        _session = null;

        ClearObjects();
    }

    private void ClearObjects()
    {
        foreach (var placedObject in _placedObjects)
        {
            Destroy(placedObject);
        }

        _placedObjects.Clear();
    }

    private void Update()
    {
        if (_session == null)
        {
            return;
        }

        if (shark.activeInHierarchy)
        {
            sharkPosition = shark.transform.position;
            if (!objectsSpawning)
            {
                InvokeRepeating("SpawnObject", 1f, fishSpawnRate);
                InvokeRepeating("WhaleSpawn", 5f, whaleSpawnRate);
                objectsSpawning = true;
            }
            else return;
            
        }        
    }

    void WhaleSpawn()
    {
        float minDist = spawnRadius - 1f;
        Vector3 spawnPosition = GetValidSpawnPosition(sharkPosition, spawnRadius, minDist);
        GameObject obj = 
            Instantiate(whalePrefab, spawnPosition, Quaternion.identity);
        Destroy(obj, whaleSpawnDuration);
    }

    void SpawnObject()
    {
        float minDistance = spawnRadius - 1f;

        Vector3 spawnPosition = GetValidSpawnPosition(sharkPosition, spawnRadius, minDistance);
        
        int randomNumber = Random.Range(1, 5);

        if (randomNumber == 1)
        {
            GameObject obj = Instantiate(prefabs[0], spawnPosition, Quaternion.identity);
            Destroy(obj, fishSpawnDuration);
        }
        else if (randomNumber == 2)
        {
            GameObject obj = Instantiate(prefabs[1], spawnPosition, Quaternion.identity);
            Destroy(obj, fishSpawnDuration);
        }
        else if (randomNumber == 3)
        {
            GameObject obj = Instantiate(prefabs[2], spawnPosition, Quaternion.identity);
            Destroy(obj, fishSpawnDuration);
        }
        else if (randomNumber == 4)
        {
            GameObject obj = Instantiate(prefabs[3], spawnPosition, Quaternion.identity);
            Destroy(obj, fishSpawnDuration);
        }
    }

    // Méthode pour obtenir une spawn position valide en vérifiant la distance avec la shark position
    Vector3 GetValidSpawnPosition(Vector3 sharkPos, float radius, float minDist)
    {
        Vector3 newSpawnPos;

        do
        {
            newSpawnPos = new Vector3(
                Random.Range(sharkPos.x - radius, sharkPos.x + radius),
                sharkPos.y,
                Random.Range(sharkPos.z - radius, sharkPos.z + radius)
            );

        } while (Vector3.Distance(newSpawnPos, sharkPos) < minDist);

        return newSpawnPos;
    }

}
