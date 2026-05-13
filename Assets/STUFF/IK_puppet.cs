using UnityEngine;

public class IK_puppet : MonoBehaviour
{
    Animator anim;

    [Header("default hand targets")]
    public Transform Right_handTarget;
    public Transform Left_handTarget;

    [Header("special override targets")]
    public Transform SlapTarget;

    [Header("IK weights")]
    [Range(0, 1)] public float rightWeight = 0f;
    [Range(0, 1)] public float leftWeight = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (!anim) return;
        // destroy association if target becomes inactive
        if (Right_handTarget && !Right_handTarget.gameObject.activeInHierarchy)
        {
            Right_handTarget = null;
        }

        if (Left_handTarget && !Left_handTarget.gameObject.activeInHierarchy)
        {
            Left_handTarget = null;
        }

        // right hand

        // start with normal target
        Transform currentRightTarget = Right_handTarget;

        // override with slap target if active
        if (SlapTarget && SlapTarget.gameObject.activeInHierarchy)
        {
            currentRightTarget = SlapTarget;
        }

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

        // left hand

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