using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float screenWidth = 16;
    private float paddlePosition;
    // Start is called before the first frame update
    void Start()
    {
        paddlePosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        paddlePosition =  (Input.mousePosition.x/Screen.width* screenWidth);
        paddlePosition = Mathf.Clamp(paddlePosition, 1, 15);
        transform.position = new Vector2(paddlePosition, transform.position.y);
    }
}
