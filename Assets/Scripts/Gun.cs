using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float damage = 10;
    [SerializeField]
    private float range = 25;
    [SerializeField]
    private Camera fpsCam;

    [SerializeField] private Transform slide;
    [SerializeField] private Transform gun;

    private bool isShooting = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }

        if (slide.localPosition.z > -.01f && isShooting) {
            slide.localPosition = new Vector3(0f, 0f, slide.localPosition.z - .0005f);
            //gun.Rotate(new Vector3(-.5f, 0f, 0f));
        } else if(slide.localPosition.z < -.01f){
            slide.localPosition = new Vector3(0f, 0f, 0f);
            //gun.rotation.Set(0f, 0f, 0f, 0f);
            isShooting = false;
        }
    }

    private void Shoot(){
        RaycastHit hit;
        GetComponent<AudioSource>().Play();
        isShooting = true;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            hit.transform.gameObject.GetComponent<Hitpoints>().TakeDamage(10);
        }
    }
}
