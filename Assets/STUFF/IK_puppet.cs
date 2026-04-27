using UnityEngine;

public class IK_puppet : MonoBehaviour
{
    Animator anim;

    public Transform handTarget;
    [Range(0, 1)] public float IK_weight = 1.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (!anim || !handTarget) return;

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IK_weight);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, IK_weight);

        anim.SetIKPosition(AvatarIKGoal.RightHand, handTarget.position);
        anim.SetIKRotation(AvatarIKGoal.RightHand, handTarget.rotation);
    }
}