using UnityEngine;
using System.Collections;

public class localRotation : MonoBehaviour {


    public float rotationSpeed;
    private int rotateIF;
    
    void Start() 
    {
        rotateIF = Random.Range(0, 2);
        if(rotateIF==0)
        {
            gameObject.GetComponent<localRotation>().enabled = false;
        }
      
    }

	void Update () {

        transform.Rotate(Vector3.forward * Time.deltaTime*rotationSpeed);
    }
}
