//
// Rain Maker (c) 2015 Digital Ruby, LLC
// http://www.digitalruby.com
//

using UnityEngine;
using System.Collections;

namespace DigitalRuby.RainMaker
{
    public class RainScript : BaseRainScript
    {
        [Tooltip("The height above the camera that the rain will start falling from")]
        public float RainHeight = 25.0f;

        [Tooltip("How far the rain particle system is ahead of the player")]
        public float RainForwardOffset = -7.0f;

        [Tooltip("The top y value of the mist particles")]
        public float RainMistHeight = 3.0f;

        [Tooltip("Should the rain follow a camera? If false, stays fixed in the scene.")]
        public bool FollowCamera = false;

        [Tooltip("Optional: Manually assign a camera. If left empty, will NOT auto-assign.")]
        public Camera TargetCamera;

        private void UpdateRain()
        {
            if (RainFallParticleSystem != null)
            {
                if (FollowCamera && TargetCamera != null)
                {
                    var s = RainFallParticleSystem.shape;
                    s.shapeType = ParticleSystemShapeType.ConeVolume;

                    RainFallParticleSystem.transform.position = TargetCamera.transform.position;
                    RainFallParticleSystem.transform.Translate(0.0f, RainHeight, RainForwardOffset);
                    RainFallParticleSystem.transform.rotation = Quaternion.Euler(0.0f, TargetCamera.transform.rotation.eulerAngles.y, 0.0f);

                    if (RainMistParticleSystem != null)
                    {
                        var s2 = RainMistParticleSystem.shape;
                        s2.shapeType = ParticleSystemShapeType.Hemisphere;
                        Vector3 pos = TargetCamera.transform.position;
                        pos.y += RainMistHeight;
                        RainMistParticleSystem.transform.position = pos;
                    }
                }
                else
                {
                    var s = RainFallParticleSystem.shape;
                    s.shapeType = ParticleSystemShapeType.Box;

                    if (RainMistParticleSystem != null)
                    {
                        var s2 = RainMistParticleSystem.shape;
                        s2.shapeType = ParticleSystemShapeType.Box;
                        Vector3 pos = RainFallParticleSystem.transform.position;
                        pos.y += RainMistHeight;
                        pos.y -= RainHeight;
                        RainMistParticleSystem.transform.position = pos;
                    }
                }
            }
        }

        protected override void Start()
        {
            base.Start();

            // prevent auto-assign unless you want it
            if (FollowCamera && TargetCamera == null)
            {
                Debug.LogWarning("RainScript: FollowCamera is enabled but no TargetCamera is assigned!");
            }
        }

        protected override void Update()
        {
            base.Update();
            UpdateRain();
        }
    }
}
