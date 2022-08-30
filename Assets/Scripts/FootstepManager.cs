using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] floorSteps;
    [SerializeField] AudioClip[] grassSteps;
    [SerializeField] AudioClip[] metalSteps;
    [SerializeField] AudioClip[] woodSteps;

    [SerializeField] Animator anim;
    [SerializeField] FirstPersonController plController;
    [SerializeField] StarterAssetsInputs inputs;

    private void OnEnable()
    {
        //StartCoroutine(CastRay());
        Debug.Log("OnEnable()");
    }

    //private IEnumerator CastRay()
    //{
    //    int counter = 0;

    //    while(counter < 10000)
    //    {
    //        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.3f);

    //        if(hit.collider != null)
    //        {
    //            Debug.Log(hit.collider.tag);

    //            if (hit.collider.CompareTag("Concrete"))
    //            {
    //                PlayFloorStep();
    //            }

    //            if (hit.collider.CompareTag("Ground"))
    //            {
    //                PlayGrassStep();
    //            }

    //            if (hit.collider.CompareTag("Metal"))
    //            {
    //                PlayMetalStep();
    //            }

    //            if (hit.collider.CompareTag("Wood"))
    //            {
    //                PlayWoodStep();
    //            }
    //        }

    //        yield return new WaitForSeconds(0.6f);

    //        counter++;
    //    }
    //}

    private void Update()
    {
        bool isMoving = inputs.move.x != 0 || inputs.move.y != 0;

        if(isMoving)
        {
            if(inputs.sprint == true)
            {
                anim.SetBool("Running", true);
            }
            else
            {
                anim.SetBool("Walking", true);
            }
        }
        else
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
        }
    }

    public void CastRay()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.3f);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.tag);

            if (hit.collider.CompareTag("Concrete"))
            {
                PlayFloorStep();
            }

            if (hit.collider.CompareTag("Ground"))
            {
                PlayGrassStep();
            }

            if (hit.collider.CompareTag("Metal"))
            {
                PlayMetalStep();
            }

            if (hit.collider.CompareTag("Wood"))
            {
                PlayWoodStep();
            }
        }
    }

    private void PlayFloorStep()
    {
        int soundIndex = Random.Range(0, floorSteps.Length);
        audioSource.PlayOneShot(floorSteps[soundIndex]);
    }

    private void PlayGrassStep()
    {
        int soundIndex = Random.Range(0, grassSteps.Length);
        audioSource.PlayOneShot(grassSteps[soundIndex]);
    }
    private void PlayMetalStep()
    {
        int soundIndex = Random.Range(0, metalSteps.Length);
        audioSource.PlayOneShot(metalSteps[soundIndex]);
    }

    private void PlayWoodStep()
    {
        int soundIndex = Random.Range(0, woodSteps.Length);
        audioSource.PlayOneShot(woodSteps[soundIndex]);
    }
}
