using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float range = 50;
    [SerializeField]
    private Camera fpsCam;

    [SerializeField] private Transform slide;
    [SerializeField] private Transform gun;
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject muzzleFlash;

    private bool isShooting = false;
    public TimeManager timeManager;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }

        if (Input.GetButton("Fire2")) {
            timeManager.SlowMotion();
        } else {
            Time.timeScale = 1;
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
        Instantiate(muzzleFlash, muzzle.position, muzzle.rotation);
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            var otherHealth = hit.transform.gameObject.GetComponentInParent<Hitpoints>();
            if(otherHealth != null) {
                otherHealth.TakeDamage(damage);
            }
        }
    }
}
