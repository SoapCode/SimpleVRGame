using UnityEngine;
using System.Collections;
using System;

namespace LookAtCubes
{

    public class CubePool : ObjectPool
    {

        public override GameObject AddToPool(GameObject prefab)
        {
            CheckIfNull(prefab);

            GameObject instance = Instantiate(prefab);

            instance.transform.parent = transform;
            instance.SetActive(false);

            Pool.Add(instance);

            return instance; 
        }

        void CheckIfNull(GameObject go)
        {
            if (go == null)
                throw new ArgumentNullException("GameObject argument can't be null");
        }

        public GameObject GetGOFromPoolByIndex(int indexInPool)
        {
            if (indexInPool < 0)
                throw new ArgumentOutOfRangeException("indexInPool must be >= 0");

            if (Pool.Count == 0)
            {
                Debug.Log("Pool is empty");
                return null;
            }

            return GetGOFromPool(Pool[indexInPool]);
        }

        public override GameObject GetGOFromPool(GameObject go)
        {
            CheckIfNull(go);

            if (CheckIfCanGetGoFromPool(go))
            {
                Pool.Remove(go);

                go.SetActive(true);

                return go;
            }

            return null;
        }

        bool CheckIfCanGetGoFromPool(GameObject go)
        {
            if (Pool.Count == 0 || !Pool.Contains(go))
            {
                Debug.LogError("Trying to get non existent in pool GameObject or from empty pool");
                return false;
            }
            return true;
        }

        public override void ReturnGOToPool(GameObject go)
        {
            CheckIfNull(go);
            
            Pool.Add(go);

            go.SetActive(false);
        }
    }
}