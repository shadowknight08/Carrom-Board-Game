using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject Ui = new GameObject("UIManager");
                Ui.AddComponent<UIManager>();
            }
            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
    }


    public TextMeshProUGUI blackCount;
    public TextMeshProUGUI whiteCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlackCountText(int count)
    {
        blackCount.text = count.ToString();
    }

    public void WhiteCountText(int count)
    {
        whiteCount.text = count.ToString();
    }
}
