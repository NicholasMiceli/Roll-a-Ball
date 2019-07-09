using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float minimum = 7.04F;
    public float maximum =  2.68F;
    static float t = 0.0f;

    void Start()
    {
 
    }
    void Update()
    {
    transform.position = new Vector3(36.83f, 0, Mathf.Lerp(minimum, maximum, t));
    t += 0.5f * Time.deltaTime;
    if (t > 1)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }

}
