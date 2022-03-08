using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundColor : MonoBehaviour
{

    public Camera cam;
    public float colorShiftDuration = 20f;

    private float hue = 150;
    private float saturation = 75;
    private float value = 50;

    // Start is called before the first frame update
    void Start()
    {

        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;

    }

    // Update is called once per frame
    void Update()
    {

        float t = Mathf.PingPong(Time.time, colorShiftDuration) / colorShiftDuration;
        hue = Mathf.Lerp(0, 360, t);

        Color p = Color.HSVToRGB(hue / 360, saturation / 100, value / 100);
        cam.backgroundColor = p;

    }
}
