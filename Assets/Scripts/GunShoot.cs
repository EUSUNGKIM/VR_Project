using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletjakugprepap;
    public Transform bulletSpawnPoint;
    public float bulletRange = 100f;
    public AudioSource gunAudioSound;

    public XRGrabInteractable grabInteractable;

    public void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(Shoot);
    }

    public void Shoot(ActivateEventArgs args)
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawnPoint.position, bulletSpawnPoint.forward, out hit, bulletRange))
        {
            if (bulletjakugprepap != null)
            {
                Instantiate(bulletjakugprepap, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        if (gunAudioSound != null)
        {
            gunAudioSound.Play();
        }
    }

    void OnDestroy()
    {
        grabInteractable.activated.RemoveListener(Shoot);
    }
}
