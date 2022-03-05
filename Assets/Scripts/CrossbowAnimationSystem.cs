using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowAnimationSystem : MonoBehaviour
{
    Animator myAnimator = null;
    CrossbowShooting myShootingSystem = null;

    const string TRIGGER_SHOOT_NAME = "Shoot";
    const string TRIGGER_RELOAD_NAME = "Reload";

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myShootingSystem = GetComponent<CrossbowShooting>();
    }

    public IEnumerator Shoot(float time)
    {
        myAnimator.SetTrigger(TRIGGER_SHOOT_NAME);
        yield return Helpers.GetWaitInSeconds(time);
        // myAnimator.ResetTrigger(TRIGGER_SHOOT_NAME);
        myAnimator.SetTrigger(TRIGGER_RELOAD_NAME);
    }
}
