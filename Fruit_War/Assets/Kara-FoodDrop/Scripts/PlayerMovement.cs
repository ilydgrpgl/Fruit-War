using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 velocity;
    Joystick joystick;
   
    void Start()
    {
       rb2d=GetComponent<Rigidbody2D>();
        joystick=FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        

#if UNITY_EDITOR
        KeyboardControl();
#else
       JoyStickControl();
#endif
 
    }
    public void KeyboardControl()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");//sað sol yönü
        Vector2 scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * 3.0f, 10.0f * Time.deltaTime);
            
            scale.x = 0.8f;
        }
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * 3.0f, 10.0f * Time.deltaTime);
            
            scale.x = -0.8f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, 40.0f * Time.deltaTime);
            
        }
        transform.localScale = scale;// sclae deðerini sürekli günceller
        transform.Translate(velocity * Time.deltaTime);//karakterinizin hýzýný günceller ve karakterin pozisyonunu hesaplar
    }

       void JoyStickControl()
    {
        float MoveInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;
        if (MoveInput > 0)
         {
            velocity.x = Mathf.MoveTowards(velocity.x, MoveInput * 3.0f, 10.0f * Time.deltaTime);

            scale.x = 0.8f;
        }
        else if (MoveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, MoveInput * 3.0f, 10.0f * Time.deltaTime);

            scale.x = -0.8f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, 40.0f * Time.deltaTime);

        }
        transform.localScale = scale;// sclae deðerini sürekli günceller
        transform.Translate(velocity * Time.deltaTime);//karakterinizin hýzýný günceller ve karakterin pozisyonunu hesaplar
    }

}

