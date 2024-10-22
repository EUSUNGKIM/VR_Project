using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletForce = 20f;

    public XRGrabInteractable grabInteractable;

    public void Start()
    {
        // XRGrabInteractable 컴포넌트 가져오기
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Activated 이벤트 등록 (트리거 버튼을 누를 때 발생)
        grabInteractable.activated.AddListener(Shoot);
    }

    public void Shoot(ActivateEventArgs args)
    {
        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // 총알에 힘을 가해 발사
        rb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);
    }

    public void OnDestroy()
    {
        grabInteractable.activated.RemoveListener(Shoot);
    }
}