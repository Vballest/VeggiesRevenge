using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [Header("Recovery")]
    public float recoverPoints;

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            var healthCtrl = collision.gameObject.GetComponent<HealthControllerPlayer>();
            if(healthCtrl)
            {
                healthCtrl.ApplyRecovery(recoverPoints);
                Destroy(gameObject);
            }
        }
    }
}
