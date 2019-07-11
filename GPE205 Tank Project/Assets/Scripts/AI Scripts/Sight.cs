using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public AIController ai;

    public GameObject player;
    private Transform Playertf;
    private Transform foundPlayer;
    public float maxAngle;
    public float maxRadius;

    public static bool isInFov = false;

    private void Start()
    {
        ai = GetComponent<AIController>();

        foundPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        Playertf = player.GetComponent<Transform>(); //LMB
    }

    // Gizmos is what is responsible for drawing all of the lines that the AI uses to see
    private void OnDrawGizmos()
    {
        // this sphere is responsible for setting the limits for the FOV and player detection
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        // these lines set the FOV and can be changed by changing the value of maxAngle
        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        // this if statement is used to check if the AI can see the player in its FOV
        // Line changes from red to green when player is in its FOV
        if (!isInFov)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * maxRadius); //LMB
        }

        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * maxRadius);
        }

        // Shows the center of the FOV
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);

    }
    // This is a list of checks that checks if the player is in the FOV
    // If the player is in the FOV, it sets isInFov to true, if not, it sets it to false
    public static bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlaps = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target) //LMB // Original = overlaps[i].gameObject.transform == target
                {
                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {

                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {
                            if (hit.transform == target)
                            {
                                isInFov = true;
                                return true;
                            }
                        }

                    }

                }


            }
        }
        isInFov = false;
        return false;
    }

    // updates every frame
    private void Update()
    {
        Playertf = player.GetComponent<Transform>();
        isInFov = inFOV(transform, Playertf, maxAngle, maxRadius);
        

        if (isInFov == true)
        {
           
        }
       
    }


}