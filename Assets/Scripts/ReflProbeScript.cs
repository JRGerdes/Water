using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflProbeScript : MonoBehaviour
{
    ReflectionProbe probe;

    private void Awake()
    {
        probe = this.GetComponent<ReflectionProbe>();
    }

    // Update is called once per frame
    void Update()
    {
        probe.transform.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y * -1,
            Camera.main.transform.position.z);

        probe.RenderProbe();
    }
}
