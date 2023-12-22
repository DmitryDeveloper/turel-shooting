using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : BaseEnemy
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float delay;
    private float additionalMaxDelay = 1.5f;
    private bool canMove = false;
    Animator robotAnim;

    void Start()
    {
        robotAnim = GetComponent<Animator>();
        base.Start();
        delay += Random.Range(0, additionalMaxDelay);   
        StartCoroutine(StartMoving());
    }

    void FixedUpdate()
    {
        if (!isDestroyed && canMove) {
            // Debug.Log("CAN MOVE");
            base.Update();

            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            Vector3 newPosition = transform.position;
            //WHY position is changing ???
            //probably animation affects this ?
            newPosition.y = 0;
            transform.position = newPosition;
        }
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(delay);
        robotAnim.SetBool("IsRunning", true); 
        canMove = true;
    }
}
