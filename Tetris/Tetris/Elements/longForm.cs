

namespace Tetris.Elements;

public class longForm
{
    public string? ElementForm { get; set; }
	public longForm()
	{
        int rand = Random.Shared.Next(0, 2);
      //  if (rand == 0)
      //  {
		    //this.ElementForm = "-----";

      //  }
        this.ElementForm = "-----";

    }

    public override string ToString()
    {
        return this.ElementForm!;
    }
}
