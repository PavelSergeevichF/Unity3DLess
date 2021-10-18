using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Ragdoll : MonoBehaviour
{
    private Rigidbody[] Rbs;
    private Collider[] Colls;

    public float killForce = 5f;

    private Animator anim;
    private NavMeshAgent AI;
    private AICharacterControl _char;
    void Start()
    {
        anim = GetComponent<Animator>();
        Rbs = GetComponentsInChildren<Rigidbody>();
        Colls = GetComponentsInChildren<Collider>();
        AI = GetComponent<NavMeshAgent>();
        _char = GetComponent<AICharacterControl>();
        Revive();
    }

    private void Kill()
    {
        SetRagDoll(true);
        SetMain(false);
    }
    private void Revive()
    {
        SetRagDoll(false);
        SetMain(true);
    }
    void SetRagDoll(bool active)
    { 
        for(int i=0; i<Rbs.Length;i++)
        {
            Rbs[i].isKinematic = !active;
            if(active)
            {
                Rbs[i].AddForce(Vector3.forward * killForce, ForceMode.Impulse);
            }
        }
        for(int i=0; i<Colls.Length; i++)
        {
            Colls[i].enabled = active;
        }
    }
    void SetMain(bool active)
    {
        anim.enabled = active;
        _char.enabled = active;
        AI.enabled = active;
        Rbs[0].isKinematic = !active;
        Colls[0].enabled = active;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Kill();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Revive();
        }
    }
}
