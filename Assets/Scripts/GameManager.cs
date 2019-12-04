using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameObject instance;

    public int level;
    public int health;
    public int key;
    public Player player;

    private UIManager UIManager;
    public LevelManager levelManager;
    private IntegerLevel integerLevel;
    private BinerLevel binerLevel;

    private void Start()
    {
        if(instance == null)
        {
            instance = gameObject;
            level = 1;
            health = 3;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        addingEssential();
        
    }

    public void addingEssential()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        UIManager = GameObject.Find("UIGame").GetComponent<UIManager>();
        UIManager.VisualLevel(level);

        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        integerLevel = GameObject.Find("LevelManager").GetComponent<IntegerLevel>();
        binerLevel = GameObject.Find("LevelManager").GetComponent<BinerLevel>();
        if (integerLevel != null)
        {
            key = integerLevel.getCurrent();
            integerLevel.setKeyText(key);
        }
        else if(binerLevel != null)
        {
            key = levelManager.getCurrent();
        }
        for (int i = 0; i < health; i++)
        {
            UIManager.AddHealth(i);
        }
    }

    public void DelHealth()
    {
        UIManager.DeleteHealth(--health);
        if(health <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }

    public void Check(int k)
    {
        key = k;
        if(integerLevel != null)
            integerLevel.setKeyText(key);
        isOpen();
    }

    public void isOpen()
    {
        if (key == levelManager.key)
        {
            levelManager.OpenDoor();
        }
        else
        {
            levelManager.CloseDoor();
        }
    }
}
