using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Charcontrol playerScript;
    private Vector2 velocity;
    public Camera cam;
    
    public float smoothTimeX;
    public float smoothTimeY;
    public float camdir;
    private float timer = 0;
    private float lastpos = 0;
    private bool edge = false;

    void Start()
    {
        playerScript = player.GetComponent<Charcontrol>();
    }

    void FixedUpdate()
    {
        camdir = playerScript.facing * -0.02f;
        float posX = transform.position.x;
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY) + .03f;
        if (posX > 6.1f && player.transform.position.x > 8) { edge = true; camdir = 0; posX = Mathf.SmoothDamp(transform.position.x, 6.5f, ref velocity.x, smoothTimeX); }
        else if (posX < -8f && player.transform.position.x < -8) { edge = true; camdir = 0; posX = Mathf.SmoothDamp(transform.position.x, -8.4f, ref velocity.x, smoothTimeX); }
        else { edge = false; posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX); }

        if(lastpos == posX && !edge)
        {
            timer = timer + (400-timer)/200;
        } else if ( timer > 10)
        {
            timer -= 10;
        } else
        {
            timer = 0;
        }

        float camscale;
        if(player.transform.position.x > 4) { camscale = (-4 + player.transform.position.x); } else { camscale = 0; }
        cam.orthographicSize = Mathf.SmoothStep(cam.orthographicSize, 5 - timer/600 + camscale * 0.1f, 10);

        transform.position = new Vector3(posX + camdir, posY, transform.position.z);
        lastpos = posX;
    }
}