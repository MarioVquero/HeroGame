using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public PlayerInputScript PIScropt;
    public GameObject AttackSquare;
    [SerializeField] Transform shootPoint;


    [SerializeField] Transform aimPos;
    [SerializeField] LayerMask aimMask;
    [SerializeField] float aimSmoothSpeed = 20f;

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
        yield return new WaitForSeconds(1f);
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(shootPoint.position, shootPoint.forward, out hitInfo);
        AttackSquare.SetActive(true);
        if (hitInfo.collider.CompareTag("floor") || hitInfo.collider.CompareTag("enemy"))
        {
            Vector3 position = hitInfo.point;
            // Debug.Log(position);
            // PIScropt.pos.position = new Vector3(position.x, 1, position.z);
            // PIScropt.currHeight = 1;
            movePlayer();
            // // reset everything
            PIScropt.loseSpeed = false;
            Debug.Log(PIScropt.pos.position);
            // hitInfo.point = Vector3.zero;
            // hit = false;



            undoSlowTimer();
            yield return null;
        }
        else
        {
            undoSlowTimer();
            PIScropt.loseSpeed = false;
            yield return null;
        }
    }

    public void movePlayer()
    {
        Vector2 screentCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screentCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            // lerp player pos
        }
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
