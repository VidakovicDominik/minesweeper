using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public static GameMode staticInstance;
    private static int levelLength = 100;
    private static int mineCount = 200;
    private static float timeLimit = 190;

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

    public static void SetTime(float time)
    {
        timeLimit = time;
    }

    public static float GetTime()
    {
        return timeLimit;
    }
}
