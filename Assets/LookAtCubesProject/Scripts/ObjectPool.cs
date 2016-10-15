using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LookAtCubes
{

    public abstract class ObjectPool : MonoBehaviour
    {

        public List<GameObject> Pool { get; private set; }

        public ObjectPool() { Pool = new List<GameObject>(); }

        public abstract GameObject AddToPool(GameObject go);

        public abstract GameObject GetGOFromPool(GameObject go);

        public abstract void ReturnGOToPool(GameObject go);
    }
}