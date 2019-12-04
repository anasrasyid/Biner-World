using UnityEngine;

public abstract class LevelManager : MonoBehaviour
{
    public GameObject door;
    public GameObject[] box;
    public int key;

    void Start()
    {
        key = (int)UnityEngine.Random.Range(0, Mathf.Pow(2f, box.Length));
        GameObject.Find("UIGame").GetComponent<UIManager>().setKeyText(key, box.Length);
        //GameObject.Find("GamaManager").GetComponent<GameManager>().isOpen();
    }


    public void OpenDoor()
    {
        door.GetComponent<ChangeSprite>().changeSprite(1);
        door.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public abstract int getCurrent();

    public void CloseDoor()
    {
        door.GetComponent<ChangeSprite>().changeSprite(0);
        door.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
