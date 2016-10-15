using UnityEngine;
using System.Collections;

namespace LookAtCubes
{
    public class CubeWasGazedUponEvent : GameEvent
    {
        public GameObject Cube;

        public CubeWasGazedUponEvent(GameObject cube)
        {
            Cube = cube;
        }
    }
}