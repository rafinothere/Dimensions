/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourManager : MonoBehaviour
{
    public List<MonoBehaviour> FollowBehaviors;
    public List<MonoBehaviour> RangeBehaviors;
    public List<MonoBehaviour> HordeBehaviors;
    public List<MonoBehaviour> HealthManagerBehaviors;

    // Call this method to activate all behaviors
    public void ActivateBehaviors()
    {
        StartCoroutine(ActivateAllBehaviors());
    }

    private IEnumerator ActivateAllBehaviors()
    {
        foreach (var behavior in FollowBehaviors)
        {
            if (behavior is IBehavior)
            {
                ((IBehavior)behavior).Activate();
                yield return new WaitForSeconds(1); // wait for 1 second before the next activation
            }
        }

        foreach (var behavior in RangeBehaviors)
        {
            if (behavior is IBehavior)
            {
                ((IBehavior)behavior).Activate();
                yield return new WaitForSeconds(1);
            }
        }

        foreach (var behavior in HordeBehaviors)
        {
            if (behavior is IBehavior)
            {
                ((IBehavior)behavior).Activate();
                yield return new WaitForSeconds(1);
            }
        }

        foreach (var behavior in HealthManagerBehaviors)
        {
            if (behavior is IBehavior)
            {
                ((IBehavior)behavior).Activate();
                yield return new WaitForSeconds(1);
            }
        }
    }
}
*/