using UnityEngine;

namespace Brackeys.SO
{
    public class AWeaponInfo : ScriptableObject
    {
        public float ReloadTime;
        public GameObject WeaponModel;

        [Header("Metadata")]
        public string NameKey;
        public string DescriptionKey;

        [Header("Multiple shoot")]
        [Tooltip("If >0, shoot an additional amount of projectiles")] public int MultShootIncr;
        public float AdditiveAngle;

        [Header("Ammos")]
        [Tooltip("Does this weapon need an external source of ammo to shoot, 0 to disable")] public int RequiresExternalAmmosCount;
        [Tooltip("If not null, the ammo will be ejected fromthe gun on every shoot")] public GameObject EjectAmmoGameObject;

        [Header("Particles")]
        [Tooltip("Object to spawn (usually particle effect) on hit (null if none)")] public GameObject SpawnOnImpact;
        [Tooltip("How much time before the SpawnOnImpact object spawned should be deleted")] public float DurationBeforeDelete;

        [Header("Stun")]
        public float StunDuration;
        public float ForceThrowback;

        [Header("Explosion")]
        public bool DoesExplode;
        public float ExplosionRadius;
    }
}