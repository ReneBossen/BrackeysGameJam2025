using UnityEngine;

namespace Brackeys.SO
{
    public class AWeaponInfo : ScriptableObject
    {
        public float ReloadTime;

        [Header("Particles")]
        [Tooltip("Object to spawn (usually particle effect) on hit (null if none)")] public GameObject SpawnOnImpact;
        [Tooltip("How much time before the SpawnOnImpact object spawned should be deleted")] public float DurationBeforeDelete;

        [Header("Explosion")]
        public bool DoesExplode;
        public float ExplosionRadius;
    }
}