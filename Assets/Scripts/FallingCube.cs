using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    public Vector2 speedMinMax;
    float screenHalfHeightWorldUnits;

    private void Start()
    {
        screenHalfHeightWorldUnits = Camera.main.orthographicSize;
    }
    // Update is called once per frame
    void Update()
    {

        float speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.getDifficultyPercent());

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -screenHalfHeightWorldUnits - transform.localScale.y)
        {
            Destroy(gameObject);
        }
    }
}
