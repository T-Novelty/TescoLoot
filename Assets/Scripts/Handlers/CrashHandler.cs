using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Core;

namespace Assets.Scripts.Handlers
{
    class CrashHandler : MonoBehaviour
    {
        void OnTriggerEnter(Collider collider)
        {
            Debug.Log("Collision Detected :" + collider.gameObject.name);

            Game.getGame().setState(Resource.State.Stopped);
        }
    }
}
