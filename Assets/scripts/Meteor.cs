using UnityEngine;

public class Meteor : MonoBehaviour
{

    private Vector2 speedMinMax = new Vector2(9f,19f);
    private float speed;
    private float screenHeight;
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, DifficulityManager.GetDifficultyPercent()); 
        screenHeight = Camera.main.orthographicSize + transform.localScale.y; 
    }

    
    void Update()
    {
        if (transform.position.y < -screenHeight)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.down * (speed * Time.deltaTime), Space.Self);
    }
}
