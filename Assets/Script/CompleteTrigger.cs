using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball")
        {
            float distance = Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position);
           
            if (distance < 1f)
            {
                GameObject.FindGameObjectWithTag("Controller").gameObject.GetComponent<MainController>().OnGameWon();
            }
        }
    }
}
