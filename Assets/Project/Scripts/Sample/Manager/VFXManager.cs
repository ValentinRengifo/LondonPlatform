using UnityEngine;

namespace LondonPlatform.Core
{
    public class VFXManager : MonoBehaviour
    {
        public static void VFX(ParticleSystem vfx, Vector3 position, float delayAfterDestroyVfx)
        {
            ParticleSystem vfxToSpawn = Instantiate(vfx, position, Quaternion.identity);

            if (vfxToSpawn != null)
            {
                vfxToSpawn.Play();
                Destroy(vfxToSpawn.gameObject, delayAfterDestroyVfx);
            }
        }
    }
}