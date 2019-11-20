using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text;
    private static GameObject instance;
    private float time;
    public Player player;

    private void Start()
    {
        if(instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        time = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Update()
    {
        VisualTime(Mathf.RoundToInt(time));
        time += Time.deltaTime;
        Death();
    }

    private void VisualTime(int time)
    {
        if(time > 60)
        {
            text.text = (time / 60).ToString() + ":" + (time%60).ToString();
        }
        else
        {
            text.text = time.ToString();
        }
    }

    private void Death()
    {
        if(player == null)
        {
            text.text = "\n Game Over";
        }
    }
    
}
