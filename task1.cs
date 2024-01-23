const int FACING_BACKWARDS = 2;
int turnCount = 0;
while(true)
{
    if(AtGoal())
    {
        break;
    }

    if(Peek() && turnCount != FACING_BACKWARDS)
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

#region Basic functions
// These functions are just her to make your intelisense work. 
// They only have a conceptual function.

void Move()
{
    // Moves the car 1 cell in the direction it is heading. 
}

void Turn()
{
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