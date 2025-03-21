using System;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace TinyBoat
{
    public class Floaters : MonoBehaviour
    {
        public Rigidbody _rb;

        public float depthBefSub;
        public float displacementAnt;
        public int floaters;
        public float waterDrag;
        public float waterAngularDrag;
        public WaterSurface waterSurface;
        
        WaterSearchParameters waterSearchParameters;
        WaterSearchResult waterSearchResult;

        private void Awake()
        {
           // _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rb.AddForceAtPosition(Physics.gravity/floaters, transform.position, ForceMode.Acceleration);
            waterSearchParameters.startPositionWS = transform.position;
            waterSurface.ProjectPointOnWaterSurface(waterSearchParameters, out waterSearchResult);

            if (transform.position.y < waterSearchResult.projectedPositionWS.y)
            {
                float displacementMulti =
                    Mathf.Clamp01((waterSearchResult.projectedPositionWS.y - transform.position.y) / depthBefSub) *
                    displacementAnt;
                _rb.AddForceAtPosition(new  Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMulti, 0f), transform.position, ForceMode.Acceleration);
                _rb.AddForce(displacementMulti * -_rb.linearVelocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
                _rb.AddTorque(displacementMulti * -_rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }
    }
}