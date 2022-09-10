namespace Eventyr.EndlessRunner.Scripts.Interfaces
{
    public interface IPickable
    {
        public delegate void Pickup();
        public Pickup PickedUp { get; set; }

        public void Use();
    }
}
