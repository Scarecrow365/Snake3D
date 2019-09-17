using UnityEngine;

public class GameManage : MonoBehaviour
{

    [SerializeField] private GameObject Snake;
    [SerializeField] private GameObject Apple;
    [SerializeField] private GameObject PosSpawnSnake;
    [Range(1,5)]
    [SerializeField] private int HowMuchAppleCreate;
    [SerializeField] private float _borderApplesSpawn = 6.7f;

    private GameObject _firstSnake;
    private GameObject _secondSnake;

	void Start ()
	{
        SnakeCreate(true);
        SnakeCreate(false);
		AppleCreate(HowMuchAppleCreate);
	}

    private void SnakeCreate(bool isFirstSnake)
    {
        switch (isFirstSnake)
        {
            case true:
                Instantiate(Snake, Vector3Int.RoundToInt(PosSpawnSnake.transform.position), Quaternion.identity);
                break;
            case false:
                Instantiate(Snake, Vector3Int.RoundToInt(-PosSpawnSnake.transform.position),
                    Quaternion.Euler(0, 180, 0));
                break;
        }
    }

    private void AppleCreate(int countAppleCreate)
    {
        for (int i = 0; i < countAppleCreate; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-_borderApplesSpawn, _borderApplesSpawn), 0,
                Random.Range(-_borderApplesSpawn, _borderApplesSpawn));
            Instantiate(Apple, Vector3Int.RoundToInt(spawnPosition), Quaternion.identity);
        }
    }

    public void DestroyFood(GameObject food)
    {
        Destroy(food);
        AppleCreate(1);
    }
}
