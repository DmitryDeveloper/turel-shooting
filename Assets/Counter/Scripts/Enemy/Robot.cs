using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : BaseEnemy
{
    [SerializeField] float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed) {
            base.Update();

            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            Vector3 newPosition = transform.position;
            //WHY position is changing ???
            //probably animation affects this ?
            newPosition.y = 0;
            newPosition.z = 0;
            transform.position = newPosition;
        }
    }
}
