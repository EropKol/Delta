using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelScript : MonoBehaviour
{
    public List<GameObject> Tunnels = new List<GameObject>();

    private void FixedUpdate()
    {
        

        foreach(GameObject Tunnel in Tunnels)
        {
            Tunnel.transform.position -= new Vector3(0, 0, 1);

            if (Tunnel.transform.position.z <= -138)
            {
                Tunnel.transform.position += new Vector3 (0, 0, 138 * Tunnels.Count);
            }
        }
    }
}
