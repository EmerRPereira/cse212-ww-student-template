/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
{
    var key = (_currX, _currY);
    if (_mazeMap.ContainsKey(key) && _mazeMap[key][0]) // índice 0 = left
    {
        _currX--;
    }
    else
    {
        throw new InvalidOperationException("Can't go that way!");
    }
}

public void MoveRight()
{
    var key = (_currX, _currY);
    if (_mazeMap.ContainsKey(key) && _mazeMap[key][1]) // índice 1 = right
    {
        _currX++;
    }
    else
    {
        throw new InvalidOperationException("Can't go that way!");
    }
}

public void MoveUp()
{
    var key = (_currX, _currY);
    if (_mazeMap.ContainsKey(key) && _mazeMap[key][2]) // índice 2 = up
    {
        _currY--;
    }
    else
    {
        throw new InvalidOperationException("Can't go that way!");
    }
}

public void MoveDown()
{
    var key = (_currX, _currY);
    if (_mazeMap.ContainsKey(key) && _mazeMap[key][3]) // índice 3 = down
    {
        _currY++;
    }
    else
    {
        throw new InvalidOperationException("Can't go that way!");
    }
}

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}