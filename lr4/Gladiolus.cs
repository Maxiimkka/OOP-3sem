using lr4;
using System.Xml.Linq;

namespace lr4;
class Gladiolus : AFlower, IPlant
{
    #region Properties
    public override DateTime WillBeRipen
    {
        get => WasPlanted.AddSeconds(5);
    }

    #endregion

    #region Constrs

    public Gladiolus(string Name) : base(Name) =>
        this.Name = Name;

    #endregion

    #region Methods

    public override void Plant()
    {
        WasPlanted = DateTime.Now;
        Console.WriteLine("Gladioluscs was planted");
    }
    public bool IsGrow()
    {
        if (DateTime.Now >= WillBeRipen)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetFruits()
    {
        if (IsGrow())
        {
            Console.WriteLine("Gladioluscs is picken");
        }
        else
        {
            Console.WriteLine("Gladioluscs is not picken, because it is not grow");
        }
    }

    #endregion

    #region Override Methods

    public override string ToString() => $"{Type}: {Name}";

    #endregion
}