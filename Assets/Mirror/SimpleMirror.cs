using UnityEngine;

public class SimpleMirror : MonoBehaviour
{
    public Camera playerCamera;
    public Camera mirrorCamera;

    void LateUpdate()
    {
        Vector3 normal = transform.forward;

        Vector3 cameraDirection =
            playerCamera.transform.position - transform.position;

        Vector3 reflectedPosition =
            playerCamera.transform.position -
            2f * Vector3.Dot(cameraDirection, normal) * normal;

        mirrorCamera.transform.position = reflectedPosition;

        Vector3 reflectedForward =
            Vector3.Reflect(playerCamera.transform.forward, normal);

        Vector3 reflectedUp =
            Vector3.Reflect(playerCamera.transform.up, normal);

        mirrorCamera.transform.rotation =
            Quaternion.LookRotation(reflectedForward, reflectedUp);
    }
}