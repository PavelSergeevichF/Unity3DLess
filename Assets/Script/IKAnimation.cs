using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnimation : MonoBehaviour
{
    [SerializeField] private Transform handObjL;
    [SerializeField] private Transform handObjR;
    [SerializeField] private Transform LookObject;
    [SerializeField] private Animator animGo;
    [SerializeField] private float rightHandWeight;
    [SerializeField] private float leftHandWeight;

    void Start()
    {
        animGo = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animGo.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandWeight);
        animGo.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandWeight);
        animGo.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        animGo.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
        animGo.SetLookAtWeight(1);

        if(handObjL)
        {
            animGo.SetIKPosition(AvatarIKGoal.LeftHand, handObjL.position);
            animGo.SetIKRotation(AvatarIKGoal.LeftHand, handObjL.rotation);
        }
        if (handObjR)
        {
            animGo.SetIKPosition(AvatarIKGoal.RightHand, handObjR.position);
            animGo.SetIKRotation(AvatarIKGoal.RightHand, handObjR.rotation);
        }
        if (LookObject)
        {
            animGo.SetLookAtPosition(LookObject.position);
        }
    }
}
