using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public int WoodCount {get; private set;}

    public UnityEvent<PlayerManager> onWoodCollected;

    public void WoodCollected()
    {
        WoodCount ++;
        onWoodCollected.Invoke(this);
    }
}
