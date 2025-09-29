using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public PlayerInputScript PIScropt;
    public GameObject AttackSquare;
    [SerializeField] Transform shootPoint;


    public Transform plauerPos;

    [SerializeField] Transform aimPos;
    [SerializeField] LayerMask aimMask;
    [SerializeField] float aimSmoothSpeed = 20f;
    [SerializeField] float attackSpeed = 0.5f;

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

    public IEnumerator Attacking()
    {
        SlowTime();
        // Debug.Log("attacking");
        yield return new WaitForSeconds(1f);
        // RaycastHit hitInfo;
        // bool hit = Physics.Raycast(shootPoint.position, shootPoint.forward, out hitInfo);
        AttackSquare.SetActive(true);


        // Debug.Log("movingPlayer");
        movePlayer(GetFinalPos(), plauerPos);
        // Debug.Log("movedPlayer");
        
        

        PIScropt.loseSpeed = false;
        undoSlowTimer();
        yield return null;
    }

    public void movePlayer(Transform MovePos, Transform pPos)
    {
        // Debug.Log(MovePos.position);
        // Debug.Log("moveplayer");
        float Jlength = Vector3.Distance(pPos.position, MovePos.position);
        float startTime = Time.time;
        float distCov = (Time.time - startTime) * attackSpeed;
        float FOJ = distCov / Jlength;

        transform.position = Vector3.Lerp(MovePos.position, pPos.position, FOJ);
        PIScropt.currHeight = 1;
    }

    private Transform GetFinalPos()
    {

        Vector2 screenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCentre);


        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {

            // Debug.Log("showAttack");

            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
        }
        // Debug.Log(aimPos.position);
        return aimPos;
    }




    private void SlowTime()
    {
        Time.timeScale = 0.2f;
    }

    private void undoSlowTimer()
    {
        Time.timeScale = 1f;
    }

    
}
