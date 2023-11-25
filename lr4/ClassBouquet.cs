using lr4;

namespace lr4;
class ClassBouquet
{
    #region Fileds

    private AFlower[] Flowers;

    private uint CurrentCount = 0;

    #endregion

    #region Properties

    public uint MaxCount { get; } = 10;
    public AFlower[] AllFlowerIn
    {
        get
        {
            var Tmp = new AFlower[CurrentCount];
            Array.Copy(Flowers, Tmp, CurrentCount);
            return Tmp;
        }
    }

    #endregion

    #region Methods

    public bool AddFlower(AFlower Flower)
    {
        if (this.CurrentCount != this.MaxCount && ((IPlant)Flower).IsGrow())
        {
            this.Flowers[this.CurrentCount++] = Flower;
        }

        return false;
    }

    #endregion

    #region Constructors

    public ClassBouquet() =>
        Flowers = new AFlower[MaxCount];


    #endregion

    #region Override Methods

    public override string ToString()
    {
        string Text = "Букет состоит из: \n";
        foreach (var item in Flowers)
        {
            Text += $"{item.ToString()}\n";
        }
        return Text;
    }

    #endregion
}