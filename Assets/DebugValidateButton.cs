using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugValidateButton : MonoBehaviour
{
    public GameObject toActivate;

    private void Start()
    {
        StartCoroutine(WaitToActivateGameobject());
    }

    IEnumerator WaitToActivateGameobject()
    {
        yield return new WaitForSeconds(1f);
        toActivate.SetActive(true);
    }
}
