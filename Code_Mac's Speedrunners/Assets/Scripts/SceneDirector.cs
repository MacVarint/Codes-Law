using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDirector : MonoBehaviour
{
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        ScoreHolder.scoreHolder.level = level;
    }
}
