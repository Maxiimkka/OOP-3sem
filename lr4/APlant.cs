using lr4;
using System.Xml.Linq;

namespace lr4;
sealed class Bush : APlant, IPlant
{
    #region Properties
    public override DateTime WillBeRipen
    {
        get => this.WasPlanted.AddSeconds(6);
    }

    #endregion

    #region Constrs

    public Bush(string Name) : base(Name)
    {
        this.Type = TypePlant.BUSH;
        this.Name = Name;
    }

    #endregion

    #region Methods

    void IPlant.Plant()
    {
        this.WasPlanted = DateTime.Now;
        Console.WriteLine($"Plant {Name} was planted");
    }

    public override void Plant()
    {
        this.WasPlanted = DateTime.Now;
        Console.WriteLine($"Plant {Name} was planted at {WasPlanted}");
    }

    public bool IsGrow()
    {
        if (DateTime.Now > WillBeRipen)
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
        if (this.IsGrow())
        {
            Console.WriteLine($"Plant {Name} is ripen");
        }
        else
        {
            Console.WriteLine($"Plant {Name} is not ripen");
        }
    }
    #endregion

    #region Override Methods

    public override string ToString()
    {
        return $"{Type}: {Name}";
    }

    #endregion
}