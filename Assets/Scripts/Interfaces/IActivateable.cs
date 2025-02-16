namespace Brackeys.Interfaces
{
    public interface IActivateable
    {
        public bool CanActivate { get; }
        public bool CanDeactivate { get; }
        public void OnActivate();
        public virtual void OnDeactivate() { }
    }
}