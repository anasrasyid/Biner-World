using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBin : Box
{
    public TextMesh textIndex;
    public int idx;
    public int values;

    private void Start()
    {
        value = 0;
        textValue.text = value.ToString();
        textIndex.text = idx.ToString();
        values = (int)(Mathf.Pow(2f, (float)(idx)));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            value++;
            value = value % 2;
            setValue(value);
        }
    }
}
