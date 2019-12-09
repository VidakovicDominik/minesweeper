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

    public static void SetLevelLength(int diff)
    {
        levelLength=diff;
    }

    public static int GetLevelLength()
    {
        return levelLength;
    }

    public static void SetMineCount(int count)
    {
        mineCount = count;
    }

    public static int GetMineCount()
    {
        return mineCount;
    }
}
