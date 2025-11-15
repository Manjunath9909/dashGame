using UnityEngine;
using UnityEngine.Pool;

public class obstacleHandler : MonoBehaviour
{
    public mainObject gameRunner;
    System.Random variantGenerator = new System.Random();
    //imports for obstacles
    public GameObject variant1;
    public GameObject variant2;
    public GameObject variant3;
    public GameObject variant4;
    public Transform bottomObstacleSpawn;
    public Transform topObstacleSpawn;
    public float timeToObstacle = 0f;
    public float obstacleStep = 3f;

    private IObjectPool<GameObject> myObstaclePool;
    void Awake()
    {

        myObstaclePool = new ObjectPool<GameObject>(
            createFunc: CreateItem,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyItem,
            collectionCheck: true,
            defaultCapacity: 100,
            maxSize: 100
        );
    }

    private GameObject CreateItem()
    {
        return cookObstacleRandom();
    }

    private void OnGet(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void OnRelease(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private void OnDestroyItem(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (gameRunner.gameRunning)
        {
            timeToObstacle += Time.deltaTime;
            if (timeToObstacle >= obstacleStep)
            {
                print("attempting spawn");
                GameObject obstacleActive = myObstaclePool.Get();
                obstacleActive.transform.position = bottomObstacleSpawn.position;
                timeToObstacle -= obstacleStep;
            }
        }
    }

    public void ReleseMeFromPool(GameObject gameObject)
    {
        myObstaclePool.Release(gameObject);
    }

    private GameObject cookObstacleRandom()
    {
        switch (variantGenerator.Next(1, 5))
        {
            case 1:
                GameObject v1 = Instantiate(variant1, bottomObstacleSpawn);
                v1.name = "obstacleVariant1";
                v1.SetActive(false);
                v1.GetComponent<obstacle>().releaseValve = this;
                return v1;

            case 2:
                GameObject v2 = Instantiate(variant2, bottomObstacleSpawn);
                v2.name = "obstacleVariant2";
                v2.SetActive(false);
                v2.GetComponent<obstacle>().releaseValve = this;
                return v2;
            case 3:
                GameObject v3 = Instantiate(variant3, bottomObstacleSpawn);
                v3.name = "obstacleVariant3";
                v3.SetActive(false);
                v3.GetComponent<obstacle>().releaseValve = this;
                return v3;
            case 4:
                GameObject v4 = Instantiate(variant4, bottomObstacleSpawn);
                v4.name = "obstacleVariant4";
                v4.SetActive(false);
                v4.GetComponent<obstacle>().releaseValve = this;
                return v4;
            default:
                return null;
        }
    }

}
