using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainerTrigger : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Ball")
        {
            float distance = Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position);
            if (distance<0.6f)
            {
                float currentScale = gameObject.transform.localScale.x;
                
                if(currentScale<2)
                other.gameObject.transform.localScale += new Vector3(currentScale/2f, currentScale/2f, currentScale / 2f);

                Destroy(gameObject);
            }    
        }
    }

    
}
