using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public OVRInput.RawButton shootingButton;
    public GameObject bulletPrefab;
    public LineRenderer linePrefab;
    public GameObject gunImpactPrefab;
    private LineRenderer laserLineInstance;
    public Transform shootingPoint;
    public float bulletSpeed = 20f;
    public AudioClip shotSound;
    public ParticleSystem muzzleFlash;

    public float shootCooldown = 0.2f;
    private float lastShotTime;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;

    public TextMeshProUGUI ammoText;
    public Slider reloadSlider;

    public float maxLineDistance = 5f;

    public bool isLeftHand = false;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;

        laserLineInstance = Instantiate(linePrefab);
        laserLineInstance.positionCount = 2;

        UpdateAmmoUI();
        if (reloadSlider != null)
            reloadSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        if (laserLineInstance != null)
        {
            laserLineInstance.SetPosition(0, shootingPoint.position);
            laserLineInstance.SetPosition(1, shootingPoint.position + shootingPoint.forward * maxLineDistance);
        }

        if (isReloading) return;

        OVRInput.Controller handController = isLeftHand ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        OVRInput.Button reloadButton = isLeftHand ? OVRInput.Button.Three : OVRInput.Button.Two;

        if (OVRInput.GetDown(shootingButton) && Time.time >= lastShotTime + shootCooldown)
        {
            if (currentAmmo > 0)
            {
                Shoot(handController);
                currentAmmo--;
                lastShotTime = Time.time;
                UpdateAmmoUI();

                if (currentAmmo == 0)
                {
                    StartCoroutine(Reload());
                }
            }
        }

        if (OVRInput.GetDown(reloadButton, handController) && !isReloading && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
        }
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
            ammoText.text = $"Ammo: {currentAmmo}/{maxAmmo}";
    }

    IEnumerator Reload()
    {
        isReloading = true;
        if (reloadSlider != null)
        {
            reloadSlider.gameObject.SetActive(true);
            reloadSlider.value = 0f;
        }

        float timer = 0f;
        while (timer < reloadTime)
        {
            timer += Time.deltaTime;
            if (reloadSlider != null)
                reloadSlider.value = timer / reloadTime;
            yield return null;
        }

        currentAmmo = maxAmmo;
        UpdateAmmoUI();

        if (reloadSlider != null)
            reloadSlider.gameObject.SetActive(false);

        isReloading = false;
    }

    public void Shoot(OVRInput.Controller handController)
    {
        if (shotSound != null && audioSource != null)
            audioSource.PlayOneShot(shotSound);

        if (muzzleFlash != null)
            muzzleFlash.Play();

        Ray ray = new Ray(shootingPoint.position + shootingPoint.forward * 0.01f, shootingPoint.forward);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDistance);
        Vector3 endPoint;

        if (hasHit)
        {
            endPoint = hit.point;

            Zombie zombie = hit.transform.GetComponentInParent<Zombie>();

            if (zombie)
            {
                bool isHeadshot = hit.transform.name.Equals("Z_Head", System.StringComparison.OrdinalIgnoreCase);

                zombie.TakeDamage(1, isHeadshot);
            }
            else
            {
                Quaternion gunImpactRotation = Quaternion.LookRotation(-hit.normal);

                GameObject gunImpact = Instantiate(gunImpactPrefab, hit.point, gunImpactRotation);
                Destroy(gunImpact, 1);
            }
        }
        else
        {
            endPoint = shootingPoint.position + shootingPoint.forward * maxLineDistance;
        }

        if (laserLineInstance != null)
        {
            laserLineInstance.SetPosition(0, shootingPoint.position);
            laserLineInstance.SetPosition(1, endPoint);
        }

        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
            rb.linearVelocity = shootingPoint.forward * bulletSpeed;

        Destroy(bullet, 6f);

        OVRInput.SetControllerVibration(1f, 0.7f, handController);
        StartCoroutine(StopHaptics(handController));
    }

    IEnumerator StopHaptics(OVRInput.Controller hand)
    {
        yield return new WaitForSeconds(0.1f);
        OVRInput.SetControllerVibration(0f, 0f, hand);
    }
}