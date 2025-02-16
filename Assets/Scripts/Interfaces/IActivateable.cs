namespace Brackeys.Interfaces
{
    public interface IActivateable
    {
        public bool CanActivate { get; }
        public void OnActivate();
    }
}