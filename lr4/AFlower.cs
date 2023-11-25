using lr4;

namespace lr4;
abstract class AFlower : APlant
{
    public abstract override DateTime WillBeRipen { get; }
    public abstract override void Plant();
    public AFlower(string Name) : base(Name) =>
        this.Name = Name;
}
