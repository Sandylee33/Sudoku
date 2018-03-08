using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGame{

    public static int dimension;
    private Grid grid = new Grid(dimension);
    bool win = false;

}

public class Grid
{
    private Row[] rows;
    private Colum[] colums;
    private Square[] squares;
    private Unit[,] wholeGrid;

    public Grid(int dimension)
    {
        int result = dimension*dimension;

        rows = new Row[result];


        colums = new Colum[result];
       

        squares = new Square[result];
       
        for (int i =0;i < result;i++)
        {
            rows[i] = new Row(dimension);
            colums[i] = new Colum(dimension);
            squares[i] = new Square(dimension);
        }

        wholeGrid = new Unit[result,result];
    }

    public void InitGrid()
    {
        for (int i = 0; i < SudokuGame.dimension; i++)
        {
            Unit[] units = rows[i].GetNumbers();
            for (int j = 0; j< SudokuGame.dimension; j++)
            {
                units[j] = wholeGrid[i,j];
            }
        }
    }

}

public class Group
{
    Unit[] numbers;

    public Unit[] GetNumbers()
    {
        return numbers;
    }

    public Group(int dimension)
    {
        numbers = new Unit[dimension*dimension];
    }

    public bool IsValid()
    {
        bool b = false;

        b = CheckDuplicate()&&CheckUnValidInputs();

        return b;
    }

    private bool CheckDuplicate()
    {
        bool b = true;
        for (int i = 0;i < numbers.Length-1; i++)
        {
            for (int j = i+1; j < numbers.Length; j++)
            {
                if (numbers[i].GetUnit() == numbers[j].GetUnit())
                {
                    b = false;
                    return b;
                }
            }
        }
        return b;
    }

    private bool CheckUnValidInputs()
    {
        bool b = false;
        foreach (var num in numbers)
        {
            if (num.GetUnit() > 0 && num.GetUnit() <= numbers.Length)
            {
                b = true;
                return b;
            }
        }
        return b;
    }

}

public class Row : Group
{
    public Row(int dimension):base(dimension)
    {
        
    }
}

public class Colum : Group
{
    public Colum(int dimension):base(dimension)
    {

    }
}

public class Square : Group
{
    public Square(int dimension):base(dimension)
    {

    }
}

public class Unit
{
    int number;

    public Unit(int num)
    {
        number = num;
    }

    public void SetUnit(int num)
    {
        number = num;
    }

    public int GetUnit()
    {
        return number;
    }
}