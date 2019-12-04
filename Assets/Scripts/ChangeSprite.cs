using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSprite : MonoBehaviour
{
    public Sprite[] sprite;
    private SpriteRenderer renderer;
    static int level = 1;

    private void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void changeSprite(int i)
    {
        renderer.sprite = sprite[i];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && renderer.color.Equals(Color.yellow))
        {
            level++;
            if (level % 2 == 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
