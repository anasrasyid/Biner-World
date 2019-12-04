using UnityEngine;

public class BinerLevel : LevelManager
{
    public override int getCurrent()
    {
        int curr = 0;
        foreach (GameObject x in box)
        {
            var tmp = x.GetComponent<BoxBin>();
            tmp.value = 0;
            curr += tmp.value * (int)Mathf.Pow(2, tmp.idx);
        }
        return curr;
    }
}
