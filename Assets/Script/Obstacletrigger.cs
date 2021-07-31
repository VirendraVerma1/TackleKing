using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacletrigger : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball")
        {
            float distance = Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position);
            float gameObjectRadius = ((0.5f+gameObject.transform.localScale.x)/2f);
            float ballRadius = (other.gameObject.transform.localScale.x / 2f);
            if (distance < (gameObjectRadius+ ballRadius))
            {
                GameObject.FindGameObjectWithTag("Controller").gameObject.GetComponent<MainController>().OnGameOver();
            }
            
        }
    }


}
