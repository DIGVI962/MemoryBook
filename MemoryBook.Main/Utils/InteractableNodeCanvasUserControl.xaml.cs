using MemoryBook.Main.Models;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;

namespace MemoryBook.Main.Utils;

public partial class InteractableNodeCanvasUserControl : ContentView
{
    private bool isDragging;
    private Point initialTouchPoint;
    private Rect initialBounds;
    private int currNodeNo = 1;
    private Dictionary<string, NodeView> nodes = new Dictionary<string, NodeView>();

    public InteractableNodeCanvasUserControl()
    {
        InitializeComponent();
    }

    private void AddNodeButton_Clicked(object sender, EventArgs e)
    {
        AddNodes($"Node {currNodeNo++}");
    }

    private void AddNodes(string label)
    {
        var node = new NodeView();
        nodes.Add(label, node);
        node.NodeData = label;

        Canvas.SetLayoutBounds(node, new Rect(30, 30, -1, -1));
        Canvas.SetLayoutFlags(node, AbsoluteLayoutFlags.None);
        Canvas.Children.Add(node);

        var touchGesture = new PanGestureRecognizer();
        touchGesture.PanUpdated += OnTouchDown;
        node.GestureRecognizers.Add(touchGesture);
    }

    private void OnTouchDown(object sender, PanUpdatedEventArgs e)
    {
        var node = sender as NodeView;
        if (node == null) return;

        switch (e.StatusType)
        {
            case GestureStatus.Started:
                isDragging = true;
                initialTouchPoint = new Point(e.TotalX, e.TotalY);
                initialBounds = Canvas.GetLayoutBounds(node);
                break;

            case GestureStatus.Running:
                if (isDragging)
                {
                    double deltaX = e.TotalX - initialTouchPoint.X;
                    double deltaY = e.TotalY - initialTouchPoint.Y;

                    double newX = initialBounds.X + deltaX;
                    double newY = initialBounds.Y + deltaY;

                    double maxWidth = Canvas.Width;
                    double maxHeight = Canvas.Height;

                    if (newX < 0)
                    {
                        newX = 0;
                    }
                    if ((newX + node.Width) > maxWidth)
                    {
                        newX = (maxWidth - node.Width);
                    }
                    if (newY < 0)
                    {
                        newY = 0;
                    }
                    if (newY > maxHeight)
                    {
                        newY = maxHeight;
                    }

                    Canvas.SetLayoutBounds(node, new Rect(newX, newY, -1, -1));
                }
                break;

            case GestureStatus.Completed:
            case GestureStatus.Canceled:
                isDragging = false;
                break;
        }
    }

    private void AddConnection(Connection connection)
    {
        var connectionLine = new Line();
        connection.StartNode!.ZIndex = connectionLine.ZIndex + 1;
        connection.EndNode!.ZIndex = connectionLine.ZIndex + 1;

        connectionLine.Stroke = Brush.Purple;
        connectionLine.StrokeThickness = 2;
        connectionLine.X1 = connection.StartNode.X;
        connectionLine.Y1 = connection.StartNode.Y;
        connectionLine.X2 = connection.EndNode.X;
        connectionLine.Y2 = connection.EndNode.Y;
    }
}