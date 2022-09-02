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

    [SerializeField] AudioClip[] floorJumps;
    [SerializeField] AudioClip[] grassJumps;
    [SerializeField] AudioClip[] metalJumps;
    [SerializeField] AudioClip[] woodJumps; 
    
    [SerializeField] AudioClip[] floorLands;
    [SerializeField] AudioClip[] grassLands;
    [SerializeField] AudioClip[] metalLands;
    [SerializeField] AudioClip[] woodLands;

    bool falling;
    private void OnEnable()
    {
        //StartCoroutine(CastRay());
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
        if(!falling)
        {
            if (plController.Grounded)
            {
                if(inputs.jump)
                {
                    ResetAnimParams();
                    anim.SetBool("jump", true);
                    falling = true;
                    return;
                }

                bool isMoving = inputs.move.x != 0 || inputs.move.y != 0;

                if (isMoving)
                {
                    if (inputs.sprint == true)
                    {
                        ResetAnimParams();
                        anim.SetBool("run", true);
                    }
                    else
                    {
                        ResetAnimParams();
                        anim.SetBool("walk", true);
                    }
                }
                else
                {
                    ResetAnimParams();
                    anim.SetBool("idle", true);
                }
            }
            else
            {
                falling = true;
            }
        }
        else
        {
            if(plController.Grounded && inputs.jump == false)
            {
                ResetAnimParams();
                anim.SetBool("land", true);
                falling = false;
            }
            else
            {

            }
        }
    }

    private void ResetAnimParams()
    {
        anim.SetBool("idle", false);
        anim.SetBool("walk", false);
        anim.SetBool("run", false);
        anim.SetBool("jump", false);
        anim.SetBool("land", false);
    }

    #region Steps
    public void Step()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.3f);

        if (hit.collider != null)
        {

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
    #endregion

    #region Jumps
    public void Jump()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2f);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Concrete"))
            {
                PlayJump(floorJumps);
            }

            if (hit.collider.CompareTag("Ground"))
            {
                PlayJump(grassJumps);
            }

            if (hit.collider.CompareTag("Metal"))
            {
                PlayJump(metalJumps);
            }

            if (hit.collider.CompareTag("Wood"))
            {
                PlayJump(woodJumps);
            }
        }
    }

    private void PlayJump(AudioClip[] audioClips)
    {
        int soundIndex = Random.Range(0, audioClips.Length);
        audioSource.PlayOneShot(audioClips[soundIndex]);
    }
    #endregion

    #region Lands
    public void Land()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2f);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Concrete"))
            {
                PlayLand(floorLands);
            }

            if (hit.collider.CompareTag("Ground"))
            {
                PlayLand(grassLands);
            }

            if (hit.collider.CompareTag("Metal"))
            {
                PlayLand(metalLands);
            }

            if (hit.collider.CompareTag("Wood"))
            {
                PlayLand(woodLands);
            }
        }
    }

    private void PlayLand(AudioClip[] audioClips)
    {
        int soundIndex = Random.Range(0, audioClips.Length);
        audioSource.PlayOneShot(audioClips[soundIndex]);
    }
    #endregion

}
