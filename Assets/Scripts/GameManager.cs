using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
    }


    public int whiteCount=0;
    public int blackCount=0;
    // Start is called before the first frame update
    void Start()
    {

        UIManager.Instance.BlackCountText(blackCount);
        UIManager.Instance.WhiteCountText(whiteCount);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlackToken()
    {
        blackCount++;
        UIManager.Instance.BlackCountText(blackCount);

    }
    public void WhiteToken()
    {
        whiteCount++;
        UIManager.Instance.WhiteCountText(whiteCount);
    }
    public void RedToken()
    {

    }

    public void Foul()
    {

    }
}
