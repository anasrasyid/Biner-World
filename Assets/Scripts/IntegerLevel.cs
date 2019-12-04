using UnityEngine;

public class IntegerLevel : LevelManager
{
    public Box keyText;
    public override int getCurrent()
    {
        return Random.RandomRange(0,10);
    }

    public void setKeyText(int k)
    {
        keyText.setValue(k);
    }
}
