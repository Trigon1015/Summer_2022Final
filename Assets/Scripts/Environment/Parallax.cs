using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, startposY, height;
    private float yOffset = 1.5f, yLerp = 0.02f;
    private PlayerController player;
    public GameObject cam;
    public float parallexEffect, parallexEffectY;

    void Start()
    {
        startpos = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        player = FindObjectOfType<PlayerController>();
        transform.position = player.transform.position;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallexEffect));
        float dist = (cam.transform.position.x * parallexEffect);
        float tempY = (cam.transform.position.y * (1 - parallexEffectY));
        float distY = (cam.transform.position.y * parallexEffectY);
        transform.position = new Vector3(startpos + dist, startposY +yOffset + distY, transform.position.z);
            //Debug.Log(Mathf.Lerp(transform.position.y, player.transform.position.y+yOffset, yLerp));
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
        //if (tempY > startposY + height) startposY += height;
        //else if (tempY < startposY - height) startposY -= height;
    }
}