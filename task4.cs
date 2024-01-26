static void Main()
{
    Pathfinder pathfinder = new Pathfinder();
    pathfinder.Run();
}


public class Pathfinder
{
    const int FACING_BACKWARDS = 2;
    int turnCount = 0;
    int orientation = 0;
    Stack<Crossroad> crossRStack = new Stack<Crossroad>();

    public void Run()
    {

        while(true)
        {
            if(AtGoal())
            {
                break;
            }

            if(AtCrossroad())
            {
                try
                {
                    Crossroad previousCrossroad = crossRStack.Pop();
                    if(GetPosition() == previousCrossroad.coordinates)
                    {
                        bool isExplored = ChoosePath(previousCrossroad);
                        if(orientation == (int)Orientation.Left)
                        {
                            previousCrossroad.exploredLeft = true;
                        }
                        else if(orientation == (int)Orientation.Right)
                        {
                            previousCrossroad.exploredRight = true;
                        }
                        else if(orientation == (int)Orientation.Up)
                        {
                            previousCrossroad.exploredUp = true;
                        }
                        else if(orientation == (int)Orientation.Down)
                        {
                            previousCrossroad.exploredDown = true;
                        }
                        if(!isExplored)
                        {
                            crossRStack.Push(previousCrossroad);
                        }
                        Move();
                            
                    }
                    else
                    {
                        crossRStack.Push(previousCrossroad);
                        NewCrossroad();
                    }

                }
                catch(InvalidOperationException)
                {
                    NewCrossroad();
                }
            }
            else if(Peek() && turnCount != FACING_BACKWARDS)
            {
                Move();
                turnCount = 0;
            }
            else
            {
                Turn();
                turnCount++;
            }
        }
    }    

    #region Basic functions
    // These functions are just her to make your intelisense work. 
    // They only have a conceptual function.

    static void Move()
    {
        // Moves the car 1 cell in the direction it is heading. 
    }

    void Turn()
    {
        if(orientation == 270)
        {
            orientation = 0;
        }
        else
        {
            orientation += 90;
        }
        // Turns the car 90 deg clockwise.
    }

    bool Peek()
    {
        // Returns true if the next cell is open, otherwise false.
        return true; // Just a placeholder value. 
    }

    bool AtGoal()
    {
        // Returns true if the current cell is the goal cell.
        return true; // just a placholder
    }

    #endregion

    int[] GetPosition()
    {
        int[] position = new int[2];
        //Gets the current position of the car
        return position;
    }

    bool AtCrossroad()
    {
        int pathsAmount = 0;
        for(int i = 0; i < 4; i++)
        {
            if(Peek())
            {
                pathsAmount++;
            }
            Turn();
        }
        if(pathsAmount > 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool ChoosePath(Crossroad previousCrossroad)
    {
        if(previousCrossroad.exploredLeft
        && previousCrossroad.exploredRight
        && previousCrossroad.exploredDown
        && previousCrossroad.exploredUp)
        {
            Align(previousCrossroad.origin);
            return true;
        }
        else if(!previousCrossroad.exploredLeft)
        {
            Align((int)Orientation.Left);
            return false;
        }
        else if(!previousCrossroad.exploredRight)
        {
            Align((int)Orientation.Right);
            return false;
        }
        else if(!previousCrossroad.exploredUp)
        {
            Align((int)Orientation.Up);
            return false;
        }
        else if(!previousCrossroad.exploredDown)
        {
            Align((int)Orientation.Down);
            return false;
        }
        else
        {
            return false;
        }
    }

    void Align(int direction)
    {
        while(orientation != direction)
        {
            Turn();
        }
    }

    void NewCrossroad()
    {
        Crossroad crossroad = new Crossroad()
        {
            coordinates = GetPosition()
        };
        switch (orientation)
        {
            case (int)Orientation.Left:
                crossroad.origin = (int)Orientation.Left;
                crossroad.exploredRight = true;
                break;
            case (int)Orientation.Up:
                crossroad.origin = (int)Orientation.Up;
                crossroad.exploredDown = true;
                break;
            case (int)Orientation.Right:
                crossroad.origin = (int)Orientation.Right;
                crossroad.exploredLeft = true;
                break;
            case (int)Orientation.Down:
                crossroad.origin = (int)Orientation.Down;
                crossroad.exploredUp = true;
                break;
            default:break;
        }
        crossRStack.Push(crossroad);
    }

    
}
public enum Orientation
{
    Left = 0,
    Right = 180,
    Up = 90,
    Down = 270
}
public class Crossroad
{
    public int[] coordinates {get; set;}
    public bool exploredLeft {get;set;}
    public bool exploredRight {get;set;}
    public bool exploredUp {get;set;}
    public bool exploredDown {get;set;}
    public int origin {get;set;}
}

