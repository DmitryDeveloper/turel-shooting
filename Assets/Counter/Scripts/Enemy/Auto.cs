using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto : BaseEnemy
{
    [SerializeField] GameObject directionPoint;
    private Rigidbody enemyRb;
    private float speed = 2.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();


        Transform[] wheels = transform.GetComponentsInChildren<Transform>();

        foreach (Transform wheel in wheels)
        {
            if (wheel.CompareTag("Wheel"))
            {
                StartCoroutine(SpinWheel(wheel));
            }
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    IEnumerator SpinWheel(Transform wheel)
	{
        while (true) {
            wheel.Rotate(Vector3.right * Time.deltaTime * 100f); // Изменяем вращение колеса
            yield return null;
        }
	}
}
