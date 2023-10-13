using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelTextUpdate : MonoBehaviour
{
     public TMP_Text LevelText; 
    [SerializeField] private LevelSystem _LevelSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevelUI();
    }

       // Method to update the health UI
        public  void UpdateLevelUI()
    {
        if (_LevelSystem != null)
        {
            LevelText.text = " LV " + _LevelSystem.level.ToString();
        }
    }


}
