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
    public GameObject variant5;
    public Transform bottomObstacleSpawn;
    public Transform topObstacleSpawn;
    public float timeToObstacle = 0f;
    public float obstacleStep = 3f;
    public float obstacleSpeed = 200f;
    int currentHealthOrbSpawnChance = 0;

    private ObjectPool<GameObject> myObstaclePool;
    void Awake()
    {
        currentHealthOrbSpawnChance = 0;
        // init for my object pool
        myObstaclePool = new ObjectPool<GameObject>(
            createFunc: CreateItem,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyItem,
            collectionCheck: true,
            defaultCapacity: 10,
            maxSize: 50
        );
    }

    // create method for my object pool
    //also handles the variation necessary to spawn a health orb while randomizing obstacle tiles
    private GameObject CreateItem()
    {
        if (currentHealthOrbSpawnChance == 5) { return cookObstacleRandom(5); }
        else { return cookObstacleRandom(1); }

    }

    private void OnGet(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void OnRelease(GameObject gameObject)
    {
        print("returning to pool" + gameObject.name);
        gameObject.SetActive(false);
    }

    private void OnDestroyItem(GameObject gameObject)
    {
        print("destroying obstacle");
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

            if (obstacleSpeed < 300)
            {
                obstacleSpeed += 0.2f;
            }
        }
    }

    public void ReleseMeFromPool(GameObject gameObject)
    {

        myObstaclePool.Release(gameObject);
    }

    //switch case to handle variation in the tile placement
    private GameObject cookObstacleRandom(int n)
    {
        int variant;
        if (n == 5) { variant = 5; }
        else { currentHealthOrbSpawnChance += 1; variant = variantGenerator.Next(1, 5); }
        switch (variant)
        {
            case 1:
                GameObject v1 = Instantiate(variant1, bottomObstacleSpawn);
                v1.name = "obstacleVariant1";
                v1.SetActive(false);
                v1.GetComponent<obstacle>().releaseValve = this;
                v1.GetComponent<obstacle>().speef = obstacleSpeed;
                return v1;

            case 2:
                GameObject v2 = Instantiate(variant2, bottomObstacleSpawn);
                v2.name = "obstacleVariant2";
                v2.SetActive(false);
                v2.GetComponent<obstacle>().releaseValve = this;
                v2.GetComponent<obstacle>().speef = obstacleSpeed;
                return v2;
            case 3:

                GameObject v3 = Instantiate(variant3, bottomObstacleSpawn);
                v3.name = "obstacleVariant3";
                v3.SetActive(false);
                v3.GetComponent<obstacle>().releaseValve = this;
                v3.GetComponent<obstacle>().speef = obstacleSpeed;
                return v3;
            case 4:
                GameObject v4 = Instantiate(variant4, bottomObstacleSpawn);
                v4.name = "obstacleVariant4";
                v4.SetActive(false);
                v4.GetComponent<obstacle>().releaseValve = this;
                v4.GetComponent<obstacle>().speef = obstacleSpeed;
                return v4;
            case 5:
                GameObject v5 = Instantiate(variant5, bottomObstacleSpawn);
                v5.name = "obstacleVariant5";
                v5.SetActive(false);
                v5.GetComponent<obstacle>().releaseValve = this;
                v5.GetComponent<obstacle>().speef = obstacleSpeed;
                currentHealthOrbSpawnChance = 0;
                return v5;
            default:
                return null;
        }
    }

    public void resetObstacles()
    {
        for (int i = 0; i <= bottomObstacleSpawn.childCount - 1; i++)
        {
            Destroy(bottomObstacleSpawn.GetChild(i).gameObject);
        }
    }
}
