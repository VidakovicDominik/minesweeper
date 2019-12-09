using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public static GameMode staticInstance;
    private static int levelLength = 100;
    private static int mineCount = 200;

    void Awake()
    {
        staticInstance = this;

        DontDestroyOnLoad(this);
    }

    public void SetLevelLength(int diff)
    {
        levelLength=diff;
    }

    public int GetLevelLength()
    {
        return levelLength;
    }

    public void SetMineCount(int count)
    {
        mineCount = count;
    }

    public int GetMineCount()
    {
        return mineCount;
    }
}
