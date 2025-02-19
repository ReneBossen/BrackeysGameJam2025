using System.Collections.Generic;
using UnityEngine;

namespace Brackeys.Manager
{
    public class DebugManager : MonoBehaviour
    {
        private static DebugManager _instance;
        public static DebugManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("DebugManager", typeof(DebugManager));
                    DontDestroyOnLoad(go);
                    _instance = go.GetComponent<DebugManager>();
                }
                return _instance;
            }
        }

        private readonly List<AShapeDebug> _shapes = new();

        public void AddSphere(float radius, Color color, float time, Vector3 pos)
        {
            _shapes.Add(new SphereDebug(radius, color, time, pos));
        }

        private void Update()
        {
            foreach (var s in _shapes)
            {
                s.ConsumeTime();
            }
            _shapes.RemoveAll(x => x.IsExpired);
        }

        private void OnDrawGizmos()
        {
            foreach (var s in _shapes)
            {
                s.Draw();
            }
        }
    }

    public abstract class AShapeDebug
    {
        protected AShapeDebug(Color color, float timer, Vector3 pos)
        {
            (_color, _timer, _pos) = (color, timer, pos);
        }

        protected Color _color;
        private float _timer;
        protected Vector3 _pos;

        public virtual void Draw()
        {
            Gizmos.color = _color;
        }

        public void ConsumeTime()
        {
            _timer -= Time.deltaTime;
        }

        public bool IsExpired => _timer <= 0f;
    }

    public class SphereDebug : AShapeDebug
    {
        public SphereDebug(float radius, Color color, float timer, Vector3 pos) : base(color, timer, pos)
        {
            _radius = radius;
        }

        private float _radius;

        public override void Draw()
        {
            base.Draw();

            Gizmos.DrawWireSphere(_pos, _radius);
        }
    }
}