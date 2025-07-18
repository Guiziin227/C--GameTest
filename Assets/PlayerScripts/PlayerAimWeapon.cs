using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    private Animator aimAnimator;

    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private float muzzleFlashDuration = 0.05f;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        if (aimTransform == null)
        {
            Debug.LogError("Aim object not found! Make sure there is a child object named 'Aim'.");
        }

        aimAnimator = GetComponent<Animator>();
        if (muzzleFlash != null)
            muzzleFlash.SetActive(false);
    }

    private void Update()
    {
        handleAiming();
        handleShooting();
    }

    private void handleAiming()
    {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void handleShooting()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (aimAnimator != null)
                aimAnimator.SetTrigger("Shoot");

            if (muzzleFlash != null)
                StartCoroutine(ShowMuzzleFlash());
        }
    }

    private IEnumerator ShowMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(muzzleFlashDuration);
        muzzleFlash.SetActive(false);
    }
}