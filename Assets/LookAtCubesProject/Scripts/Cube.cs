using UnityEngine;
using System.Collections;

namespace LookAtCubes
{

    [RequireComponent(typeof(Collider))]
    public class Cube : MonoBehaviour, IGvrGazeResponder
    {
        
        public void OnGazeEnter()
        {
            EventManager.Instance.QueueEvent(new CubeWasGazedUponEvent(gameObject));
        }

        public void OnGazeExit()
        {
        }

        public void OnGazeTrigger()
        {
            
        }
    }
}