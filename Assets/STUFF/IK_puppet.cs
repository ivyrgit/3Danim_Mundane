using UnityEngine;

public class IK_puppet : MonoBehaviour
{
    Animator anim;

    [Header("Default Hand Targets")]
    public Transform Right_handTarget;
    public Transform Left_handTarget;

    [Header("Special Override Targets")]
    public Transform SlapTarget;

    [Header("IK Weights")]
    [Range(0, 1)] public float rightWeight = 0f;
    [Range(0, 1)] public float leftWeight = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (!anim) return;

        // -------------------------
        // RIGHT HAND
        // -------------------------

        // Start with the normal target
        Transform currentRightTarget = Right_handTarget;

        // If slap target exists AND is active, override normal target
        if (SlapTarget && SlapTarget.gameObject.activeInHierarchy)
        {
            currentRightTarget = SlapTarget;
        }

        // Apply IK if a target exists
        if (currentRightTarget)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightWeight);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightWeight);

            anim.SetIKPosition(AvatarIKGoal.RightHand, currentRightTarget.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, currentRightTarget.rotation);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
        }

        // -------------------------
        // LEFT HAND
        // -------------------------

        if (Left_handTarget)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftWeight);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftWeight);

            anim.SetIKPosition(AvatarIKGoal.LeftHand, Left_handTarget.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, Left_handTarget.rotation);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
        }
    }
}