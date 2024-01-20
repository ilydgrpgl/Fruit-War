using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    //Adjusted for different screen sizes
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;

        float spriteWidth = spriteRenderer.size.x;
        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight / Screen.height * Screen.width;
        tempScale.x = screenWidth / spriteWidth;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
