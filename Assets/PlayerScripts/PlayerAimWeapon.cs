using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    //private Animator aimAnimator;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        //aimAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        handleAiming();
    }

    private void handleAiming()
    {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0f, 0f, angle);
    }

}