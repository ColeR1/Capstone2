using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour
{

    public TextMeshProUGUI levelText;
    public int level;
    public int exp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
    }

    void LevelUp()

    {
        if(exp>100)
        {
            level = level +1;
            exp =0;
            levelText.text = "LV:" + level.ToString();
        }
    }

    
}
