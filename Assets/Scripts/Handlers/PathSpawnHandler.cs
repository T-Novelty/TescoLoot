using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Handlers
{
    class PathSpawnHandler : MonoBehaviour
    {
        public GameObject path;
        public GameObject cart;
        public GameObject coin;
        public GameObject product;
        public Transform[] pathSpawnPoints;
        public Transform[] obstacleSpawnPoints;
        public Transform[] coinSpawnPoints;
        public Transform[] productSpawnPoints;

        void OnTriggerEnter(Collider collider)
        {
            Debug.Log("Collison detected with : " + collider.gameObject.name);

            for (int i = 0; i < pathSpawnPoints.Length; i++)
                Instantiate(path, pathSpawnPoints[i].position, pathSpawnPoints[i].rotation);

            for (int i = 0; i < obstacleSpawnPoints.Length; i++)
                Instantiate(cart, obstacleSpawnPoints[i].position, obstacleSpawnPoints[i].rotation);

            for (int i = 0; i < coinSpawnPoints.Length; i++)
            {
                Instantiate(coin, coinSpawnPoints[i].position, coinSpawnPoints[i].rotation);
                Vector3 pos_1 = coinSpawnPoints[i].position;
                pos_1.z += 0.5f;
                Instantiate(coin, pos_1, coinSpawnPoints[i].rotation);
                pos_1.z += 0.5f;
                Instantiate(coin, pos_1, coinSpawnPoints[i].rotation);
            }

            for (int i = 0; i < productSpawnPoints.Length; i++)
            {
                Instantiate(product, productSpawnPoints[i].position, productSpawnPoints[i].rotation);
            }
        }
    }
}
