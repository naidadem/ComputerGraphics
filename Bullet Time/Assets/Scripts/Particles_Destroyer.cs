using UnityEngine;
using System.Collections;

public class Particles_Destroyer : MonoBehaviour {

    
    public void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer() 
    {
        yield return new WaitForSeconds(4.5f);
        Destroy(gameObject);
    }
}
