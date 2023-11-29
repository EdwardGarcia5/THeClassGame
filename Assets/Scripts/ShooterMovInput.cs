using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterMovInput : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    private Vector2 movementValue;
    private float lookValue;
    public GameObject prefab;
    public GameObject shootPoint;
    public ParticleSystem muzzleEffect;

    private void Awake(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputValue value){
        movementValue = value.Get<Vector2>() * speed;
    }

    public void OnLook(InputValue value){
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }

    public void OnFire(InputValue value){
        if(value.isPressed){

            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
            muzzleEffect.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);
        transform.Rotate(0, lookValue * Time.deltaTime, 0);
    }
}
