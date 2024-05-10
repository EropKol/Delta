using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWall : MonoBehaviour
{
    public TrainToTunnel Train;

    private void Update()
    {
        if(Train.GoingOut2 == true)
        {
            Destroy(gameObject);
        }
    }
}
