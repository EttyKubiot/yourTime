using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneShotBehaviour2 : StateMachineBehaviour
{
    public float volume = 1f;
    public AudioClip soundToPlay;
    public bool playOnEnter = true, playOnExit = false, playAfterDelay = false;
    private bool hasDelayedSoundPlay = false;
    public float playDelay = 0.25f;
    private float timeSinceEnter = 0;
  
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnEnter)
        {
          
            AudioSource.PlayClipAtPoint(soundToPlay, new Vector3(0, 0, 0), volume);
          
            timeSinceEnter = 0f;
            hasDelayedSoundPlay = false;
        }
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playAfterDelay && !hasDelayedSoundPlay)
        {
            if (playOnEnter)
            {
                AudioSource.PlayClipAtPoint(soundToPlay, new Vector3(0, 0, 0), volume);
                hasDelayedSoundPlay = true;
            }
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnExit)
        {
            AudioSource.PlayClipAtPoint(soundToPlay, animator.gameObject.transform.position, volume);
        }
    }


    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }


    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
