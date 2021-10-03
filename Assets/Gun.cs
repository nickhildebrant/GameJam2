using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage = 10;
    [SerializeField]
    private float range = 25;
    [SerializeField]
    private Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    private void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
        }
    }
}
