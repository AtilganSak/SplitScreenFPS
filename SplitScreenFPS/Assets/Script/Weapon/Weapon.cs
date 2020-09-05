using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    bool readyForFire;

    public bool mobile;
    public bool autoReload;
    public bool applyForce;
    public float applyForceAmount;

    public int ammoCount = 54;//Have 3 ammo(18 * 3)
    public int ammoCapacity = 18;
    public int ammo = 18;

    public float shootingDistance;

    public float damageAmount;

    public GameObject dummyBulletPrefab;
    public Transform dummyBulletPlace;
    public Transform gunBarrel;

    public ParticleSystem muzzleEffect;

    public LayerMask enemyLayers;

    public TMP_Text ammoCountText;
    public TMP_Text ammoText;
    public AudioClip shotSound;

    Canvas weaponInformationCanvas;
    RaycastHit raycastHit;
    bool canShoot;
    AudioSource audioSource;
    bool reloading;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (ammo > ammoCapacity)
            ammo = ammoCapacity;
        if (ammo < 0)
            ammo = 0;

        weaponInformationCanvas = ammoText.GetComponentInParent<Canvas>();

        UpdateUI();
    }
    private void Update()
    {
        if (readyForFire)
        {
            if (!mobile)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Fire();
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
    }
    private void FixedUpdate()
    {
        if (readyForFire)
        {
            Debug.DrawRay(gunBarrel.position, gunBarrel.forward * shootingDistance, Color.green);
            if (Physics.Raycast(gunBarrel.position, gunBarrel.forward, out raycastHit, shootingDistance))
            {
                canShoot = true;
            }
        }
    }
    public void Fire()
    {
        if (reloading) return;

        muzzleEffect.Play();

        audioSource.PlayOneShot(shotSound);

        ammo--;

        UpdateUI();

        TakeDamage();

        SpawnDummyBullet();

        SpawnImpactParticle();

        ApplyForce();

        if (ammo <= 0)
        {
            if (autoReload)
            {
                bool enoughAmmo = ammoCount > 0;
                if (!enoughAmmo)
                    return;
                else
                {
                    StartCoroutine(Reload());
                }
            }
            else
            {
                Debug.LogError("It's over ammo, reload your weapon!");
                return;
            }
        }
    }
    public void SetReadyForFire(bool _state)
    {
        if (_state)
        {
            readyForFire = true;
            weaponInformationCanvas.gameObject.SetActive(true);
        }
        else
        {
            readyForFire = false;
            weaponInformationCanvas.gameObject.SetActive(false);
        }
    }

    public void GetAmmo(int _amount)
    {
        if (_amount < 0)
        {
            _amount = 0;
        }
        ammoCount += _amount;

        UpdateUI();
    }

    void TakeDamage()
    {
        Damagable damagable = raycastHit.collider?.GetComponent<Damagable>();
        if (damagable != null)
        {
            Transform enemyTransform = raycastHit.collider.gameObject.transform;
            damagable.GiveDamage(damageAmount);
        }
    }
    void SpawnDummyBullet()
    {
        GameObject bullet = Instantiate(dummyBulletPrefab);
        bullet.transform.position = dummyBulletPlace.position;
        bullet.transform.rotation = dummyBulletPlace.rotation;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 300);
        Destroy(bullet, 5);
    }
    void SpawnImpactParticle()
    {
        ImpactHolders impactHolders = raycastHit.collider?.GetComponent<ImpactHolders>();
        if (impactHolders != null)
        {
            GameObject impactEffect = impactHolders.specialEffect;
            Quaternion rot = Quaternion.FromToRotation(impactEffect.transform.forward, raycastHit.normal) * impactEffect.transform.rotation;
            Vector3 pos = raycastHit.point;
            Instantiate(impactEffect, pos, rot);
        }
    }

    void ApplyForce()
    {
        if (applyForce)
        {
            Rigidbody rigidbody = raycastHit.collider.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddForceAtPosition((rigidbody.transform.position - raycastHit.point) * applyForceAmount, raycastHit.point);
            }
        }
    }

    IEnumerator Reload()
    {
        reloading = true;

        yield return new WaitForSeconds(3);

        int diff = ammoCapacity - ammo;
        if (diff <= ammoCount)
        {
            ammo += diff;
            ammoCount -= diff;
        }
        else
        {
            ammo += ammoCount;
            ammoCount = 0;
        }

        UpdateUI();

        reloading = false;
    }

    void UpdateUI()
    {
        if (!ammoText.enabled)
            ammoText.enabled = true;

        ammoText.text = ammo.ToString();
        ammoCountText.text = ammoCount.ToString();
    }
}
