using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScore : MonoBehaviour {

    public void Clear()
    {
        Score.instance.ResetScore();
    }

}
