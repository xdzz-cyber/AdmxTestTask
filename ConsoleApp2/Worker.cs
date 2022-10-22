namespace ConsoleApp2;

public static class Worker
{
    private const int DimensionsSize = 9;

    private const int RandomNumberMax = 4;

    private const int CountOfElementsToBeRemoved = 3;

    private static List<List<int>>? _list;

    static Worker()
    {
        InitializeMatrix();
    }

    public static void MainFunction()
{
    Console.WriteLine("After initialization");
    
    while(CheckIfRowOrColumnHasSameValueCountEqualConstant())
    {

        for (var i = 0; i < _list!.Count; i++)
        {
            var columns = new List<int>(DimensionsSize);
            columns.AddRange(_list.Select(t => t[i]));

            var findElement = -1;

            if (_list[i].Any(x =>
                {
                    if (CountOfElementInList(_list[i], x, CountOfElementsToBeRemoved).Count <= CountOfElementsToBeRemoved - 1) return false;
                    findElement = x;
                    return true;
                })) 
            {

                var j = i; // 3
                
                var indexes = CountOfElementInList(_list[j], findElement, CountOfElementsToBeRemoved);

                while (j != 0)
                {
                    foreach (var index in indexes)
                    {
                        (_list[j][index], _list[j - 1][index]) = (_list[j - 1][index], _list[j][index]);
                    }
                    j--;
                }
                
                foreach (var index in indexes)
                {
                    _list[0][index] = new Random().Next(0, RandomNumberMax);
                }
            }

            if (!columns.Any(x =>
                {
                    if (CountOfElementInList(columns, x, CountOfElementsToBeRemoved).Count
                        <= CountOfElementsToBeRemoved - 1) return false;
                    findElement = x;
                    return true;
                })) continue;
            {
                var indexes = CountOfElementInList(columns, findElement, CountOfElementsToBeRemoved);
               
                var oldColumnsCount = columns.Count;
                
                columns.RemoveRange(indexes[0], indexes.Count);
                
                while (columns.Count != oldColumnsCount)
                {
                    columns.Insert(0, new Random().Next(0, RandomNumberMax));
                }
                
                for (var j = 0; j < _list.Count; j++)
                {
                    _list[j][i] = columns[j];
                }
            }
        }
        
        PrintValues();
    }

    Console.WriteLine("Finish");
}

    private static bool CheckIfRowOrColumnHasSameValueCountEqualConstant()
    {
        for (var i = 0; i < _list!.Count; i++)
        {
            if (_list[i].Any(x => CountOfElementInList(_list[i], x, CountOfElementsToBeRemoved).Count 
                                  >= CountOfElementsToBeRemoved))
            {
                return true;
            }

            var columns = new List<int>(DimensionsSize);
            columns.AddRange(_list.Select(t => t[i]));

            if (columns.Any(x => CountOfElementInList(columns, x, CountOfElementsToBeRemoved).Count 
                                 >= CountOfElementsToBeRemoved ))
            {
                return true;
            }
        }

        return false;
    }
    
    public static void InitializeMatrix()
    {
        _list = new List<List<int>>();
        
        for (var i = 0; i < DimensionsSize; i++)
        {
            var tmp = new List<int>();
    
            for (var j = 0; j < DimensionsSize; j++) tmp.Add(new Random().Next(0, RandomNumberMax));
    
            _list.Add(tmp);
        }
    }
    
    public static void PrintValues()
    {
        foreach (var t in _list!)
        {
            foreach (var x in t) Console.Write($"{x}\t");

            Console.WriteLine();
        }

        Console.WriteLine("-------------------------------------");
    }

    private static List<int> CountOfElementInList(IReadOnlyList<int> list, int find, int count)
    {

        for (var i = 0; i < list.Count; i++)
        {
            var j = i;
            var indexes = new List<int>{j};
        
            while (j + 1 < list.Count && (list[j] == find && list[j + 1] == find) && list[j] == list[j+1])
            {
                j++;
                indexes.Add(j);
            }

            if (indexes.Count >= count)
            {
                return indexes;
            }
        }

        return new List<int>();
    }
}