using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public Text levelText;
    public Text keyText;
    public GameObject[] health;


    public void AddHealth(int i)
    {
        health[i].SetActive(true);
    }

    public void DeleteHealth(int i)
    {
        health[i].SetActive(false);
    }

    public void VisualLevel(int level)
    {
        levelText.text = "Level - " + level.ToString();
    }

    public void setKeyText(int key, int pad)
    {
        keyText.text = Convert.ToString(key, 2).PadLeft(pad, '0');
    }

}
