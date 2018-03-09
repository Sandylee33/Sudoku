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
    
    private Unit[,] wholeGrid;

    public Grid(int dimension)
    {
        int result = dimension*dimension;
        wholeGrid = new Unit[result,result];
    }

    public void SetGridValue(int rowNum,int columNum, int num)
    {
        wholeGrid[rowNum,columNum].SetUnit(num);
    }

	public bool Check()
    {
		return CheckRow () && CheckColum() && CheckSquare ();
    }

    public bool CheckRow()
    {   
        bool b = true;
        int result = SudokuGame.dimension*SudokuGame.dimension;
        for (int i = 0;i < result;i++)
        {
            Row row = new Row(SudokuGame.dimension);
            Unit[] units = new Unit[result];
            for (int j = 0;j < result; j++)
            {
                units[j] = wholeGrid[i,j];
            }
            row.SetNumbers(units);
            b = b && row.IsValid();
        }

        return b;
    }
    public bool CheckColum()
    {
        bool b = true;
        int result = SudokuGame.dimension*SudokuGame.dimension;
        for (int i = 0;i < result;i++)
        {
            Colum colum = new Colum(SudokuGame.dimension);
            Unit[] units = new Unit[result];
            for (int j = 0;j < result; j++)
            {
                units[j] = wholeGrid[j,i];
            }
            colum.SetNumbers(units);
            b = b && colum.IsValid();
        }

        return b;
    }


    public bool CheckSquare()
    {
        bool b = true;
        int result = SudokuGame.dimension*SudokuGame.dimension;
       
        Square square = new Square(SudokuGame.dimension);
        Unit[] units = new Unit[result];
       
		for (int i = 0; i < result; i = i + SudokuGame.dimension) 
		{
			for (int j = 0; j < result; j = j + SudokuGame.dimension) 
			{
				for (int p = i; p < SudokuGame.dimension; p++) 
				{
					for (int q = j; q < SudokuGame.dimension; q++) 
					{
						units [p%SudokuGame.dimension + q%SudokuGame.dimension * SudokuGame.dimension] = wholeGrid[p, q];
						square.SetNumbers (units);
						b = b && square.IsValid ();
					}
				}
			}
		}
        return b;
    }

}

public class Group
{
    Unit[] numbers;


    public Group(int dimension)
    {
        numbers = new Unit[dimension*dimension];
    }

    public Unit[] GetNumbers()
    {
        return numbers;
    }

    public void SetNumbers(Unit[] units)
    {
        numbers = units;
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