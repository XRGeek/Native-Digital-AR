using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoAspectRationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustRatio(float width , float height)
    {
        float ratio;

        if (width == height)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
            return;
        }

        if (width < height)
        {
            ratio = height / width;
            transform.localScale = new Vector3(1, transform.localScale.y, 1*ratio);
        }
        else
        {
            ratio = width / height;
            transform.localScale = new Vector3(1*ratio, transform.localScale.y, 1);
        }
    }
}
