using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleClick : MonoBehaviour
{

    public int balloonID;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // Destroy(gameObject);
        NetworkedClientProcessing.SendMessageToServer(ClientToServerSignifiers.BalloonClicked + "," + balloonID);
    }
}
