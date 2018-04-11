using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Transform[] backgrounds;
    public float[] position;
    private float[] parallexScales;
    public float smoothing;

    public Vector3 previousCameraPosition;

    // Use this for initialization
    void Start()
    {
        previousCameraPosition = transform.position;

        parallexScales = new float[backgrounds.Length];
        for (int i = 0; i < parallexScales.Length; i++)
        {
            parallexScales[i] = position[i]*0.1f;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 parallax = (previousCameraPosition - transform.position) * (parallexScales[i] / smoothing);

            backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x, backgrounds[i].position.y + parallax.y / 5, backgrounds[i].position.z + parallax.z);
        }
        previousCameraPosition = transform.position;
    }
}
