using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    float durationUntilNextBalloon;
    Sprite circleTexture;

    LinkedList<GameObject> activeBalloons;

    void Start()
    {
        NetworkedClientProcessing.SetGameLogic(this);
        activeBalloons = new LinkedList<GameObject>();

    }
    void Update()
    {
        //durationUntilNextBalloon -= Time.deltaTime;

        //if(durationUntilNextBalloon < 0)
        //{
        //    durationUntilNextBalloon = 1f;

        //    float screenPositionXPercent = Random.Range(0.0f, 1.0f);
        //    float screenPositionYPercent = Random.Range(0.0f, 1.0f);
        //    Vector2 screenPosition = new Vector2(screenPositionXPercent * (float)Screen.width, screenPositionYPercent * (float)Screen.height);
        //    SpawnNewBalloon(screenPosition);
        //}
    }
    public void SpawnNewBalloon(float xPosPercent, float yPosPercent, int balloonID)
    {
        Vector2 screenPosition = new Vector2(xPosPercent * (float)Screen.width, yPosPercent * (float)Screen.height);

        if (circleTexture == null)
            circleTexture = Resources.Load<Sprite>("Circle");

        GameObject balloon = new GameObject("Balloon");

        balloon.AddComponent<SpriteRenderer>();
        balloon.GetComponent<SpriteRenderer>().sprite = circleTexture;
        balloon.AddComponent<CircleClick>();
        balloon.AddComponent<CircleCollider2D>();

        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 0));
        pos.z = 0;
        balloon.transform.position = pos;
        //go.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, -Camera.main.transform.position.z));

        balloon.GetComponent<CircleClick>().balloonID = balloonID;
        activeBalloons.AddLast(balloon);
    }

    public void BalloonWaPopped(int balloonID)
    {
        GameObject destoryMe = null;
        foreach(GameObject b in activeBalloons)
        {
            if(b.GetComponent<CircleClick>().balloonID == balloonID)
            {
                destoryMe = b;
                break;
            }
        }

        if(destoryMe != null)
        {
            activeBalloons.Remove(destoryMe);
            Destroy(destoryMe);
        }
    }

}

