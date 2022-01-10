using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Underwater : MonoBehaviour
{
    public GameObject boundingBox, player;
    public Volume post;
    public Color underwaterColor;
    public bool underwater;

    // Effects
    private Vignette VG;
    private DepthOfField DOF;
    private ColorAdjustments CA;

    private void Start()
    {
        post.profile.TryGet(out DOF);
        post.profile.TryGet(out CA);
        post.profile.TryGet(out VG);
    }

    private void FixedUpdate()
    {
        if (boundingBox.GetComponent<BoxCollider>().bounds.Contains(player.transform.position))
            underwater = false;
        else
            underwater = true;

        if (!underwater)
        {
            VG.intensity.value = 0.35f;
            DOF.focusDistance.value = 0.1f;
            CA.colorFilter.value = underwaterColor;
        }
        else
        {
            VG.intensity.value = 0.292f;
            DOF.focusDistance.value = 3f;
            CA.colorFilter.value = Color.white;
        }
    }

}
