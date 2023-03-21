using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private RawImage rawImage;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rawImage.uvRect = new Rect(offset, 0, 1, 1);
    }
}
