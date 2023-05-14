using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    public event System.Action OnPlayerDeath;
    
    Vector2 inputX;
    Vector2 halfScreenSizeWorldUnits;
    float halfPlayerWidth;

    // Start is called before the first frame update
    void Start()
    {
        halfScreenSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        halfPlayerWidth = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        transform.Translate(inputX.normalized * speed * Time.deltaTime);

        if (transform.position.x - halfPlayerWidth > halfScreenSizeWorldUnits.x || transform.position.x + halfPlayerWidth < -halfScreenSizeWorldUnits.x)
        {
            transform.Translate(transform.position * Vector2.left * 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

}
