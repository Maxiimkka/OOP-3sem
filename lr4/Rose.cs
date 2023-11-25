using System.Xml.Linq;
using System;

namespace lr4;
class Rose : AFlower, IPlant
{
    #region Properties

    public override DateTime WillBeRipen
    {
        get => WasPlanted.AddSeconds(2);
    }

    #endregion

    #region Constrs

    public Rose(string Name) : base(Name) =>
        this.Name = Name;

    #endregion

    #region Methods

    public override void Plant()
    {
        WasPlanted = DateTime.Now;
        Console.WriteLine("Rose was planted");
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
            Console.WriteLine("Rose is picken");
        }
        else
        {
            Console.WriteLine("Rose is not picken, because it is not grow");
        }
    }

    #endregion

    #region Override Methods

    public override string ToString() => $"{Type}: {Name}";

    #endregion
}
