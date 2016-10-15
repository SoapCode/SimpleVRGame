using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace LookAtCubes
{

    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject _cubePrefab;

        [SerializeField]
        int _poolCapacity;

        CubePool _cPool;

        void Awake()
        {
            _cPool = GetComponent<CubePool>();
        }

        public void LoadCubePool()
        {
            if(_poolCapacity < 1)
            {
                Debug.LogError("Can't have less then 1 cubesQuantity");
                return;
            }

            GameObject temp;

            for(int i = 0;i < _poolCapacity;i++)
            {
                temp = _cPool.AddToPool(_cubePrefab);
            }
        }

        public void SpawnRandomCube(Vector3 position)
        {
            GameObject newCube;

            if (!(_cPool.Pool.Count == 0))
            {
                newCube = _cPool.GetGOFromPoolByIndex(UnityEngine.Random.Range(0, _cPool.Pool.Count));
                newCube.transform.position = position;
            }
        }

        void OnEnable()
        {
            if(EventManager.Instance != null)
                EventManager.Instance.AddListener<CubeWasGazedUponEvent>(OnCubeWasGazedUpon);
        }

        void OnDisable()
        {
            if (EventManager.Instance != null)
                EventManager.Instance.RemoveListener<CubeWasGazedUponEvent>(OnCubeWasGazedUpon);
        }

        public void OnCubeWasGazedUpon(CubeWasGazedUponEvent cEv)
        {
            _cPool.ReturnGOToPool(cEv.Cube);
        }
    }
}