using lr4;

namespace lr4;
class ClassPaper
{
    #region Fields

    private StringBuilder _Context = new();

    #endregion

    #region Props

    public Tree MadeFrom { get; set; }
    public TypePaper Type { get; set; }
    private StringBuilder Context
    {
        get => _Context;
        set => _Context = value;
    }

    #endregion

    #region Constrs

    public ClassPaper(Tree MadeFrom, TypePaper Type)
    {
        this.MadeFrom = MadeFrom;
        this.Type = Type;
    }

    #endregion

    #region Methods

    public void Write(string record) =>
        Context.Append(record);

    public override string ToString() =>
        Context.ToString();

    #endregion
}

enum TypePaper
{
    INCAGE,
    INRULER
}