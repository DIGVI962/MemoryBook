namespace MemoryBook.Main.Utils;

public partial class NodeView : ContentView
{
	public NodeView()
	{
		InitializeComponent();
	}

    public string NodeData
    {
        get => NodeLabel.Text;
        set => NodeLabel.Text = value;
    }
}