using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{

    [SerializeField] Transform shootPoint;


    [SerializeField] private float radius;
    [SerializeField] private float chargeSpeed;
    [SerializeField] private float damage;

    public Vector3 Attack()
    {

        RaycastHit hitInfo;
        bool hit = Physics.Raycast(shootPoint.position, shootPoint.forward, out hitInfo);
        if (hitInfo.collider.CompareTag("floor"))
        {
            Vector3 position = hitInfo.point;
            hitInfo.point = Vector3.zero;
            return position;
        }
        else
        {
            return Vector3.zero;
        }
    }
    
}
