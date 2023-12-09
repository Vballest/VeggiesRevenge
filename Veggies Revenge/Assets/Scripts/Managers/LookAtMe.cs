using UnityEngine;

public class LookAtMe : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if(distance > 10)
        { 
            transform.LookAt(target);
        }
    }
}
