using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoAspectRationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //string meta = "http://www.euphoriaxr.com,1280,720";
        //string[] metaData = meta.Split(',');
        //AdjustRatio(float.Parse(metaData[1]), float.Parse(metaData[2]));
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
            return;
        }

        if (width < height)
        {
            ratio = height / width;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z*ratio);
        }
        else
        {
            ratio = width / height;
            transform.localScale = new Vector3(transform.localScale.x*ratio, transform.localScale.y, transform.localScale.z);
        }
    }
}
