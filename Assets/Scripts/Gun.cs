using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private int damage = 100;
    [SerializeField]
    private float range = 50;
    [SerializeField]
    private Camera fpsCam;

    [SerializeField] private Transform slide;
    [SerializeField] private Transform gun;
    [SerializeField] private Transform muzzle;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject muzzleFlash;

    private bool isShooting = false;
    private bool canShoot = false;
    private float timer = 1f;
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

        if (!canShoot) {
            timer -= Time.deltaTime;
            if(timer <= 0f) {
                canShoot = true;
                timer = 1f;
            }
        }
    }

    private void Shoot(){
        if (canShoot) {
            canShoot = false;
            RaycastHit hit;
            GetComponent<AudioSource>().Play();
            isShooting = true;
            Instantiate(muzzleFlash, muzzle.position, muzzle.rotation);
            GameObject newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
            newBullet.transform.forward = muzzle.forward;
            newBullet.GetComponentInChildren<Rigidbody>().AddForce(transform.forward * 500);
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
                var otherHealth = hit.transform.gameObject.GetComponentInParent<Hitpoints>();
                if (otherHealth != null) {
                    Debug.Log("Hit zombie");
                    otherHealth.TakeDamage(damage);
                }
            }
        }
    }
}
