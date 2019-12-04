using UnityEngine;

public class Box : MonoBehaviour
{
    public TextMesh textValue;
    public int value;

    public void setValue(int val)
    {
        value = val;
        textValue.text = value.ToString();
    }
}
