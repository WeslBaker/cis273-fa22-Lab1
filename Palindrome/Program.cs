using System.Collections.Generic;

namespace Palindrome;
public class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> doublyLinkedList = new LinkedList<int>();
        for (int i = -15; i < 16; i++)
        {
            doublyLinkedList.AddLast(Math.Abs(i));
        }
        var first = doublyLinkedList.First.Value;

        var last = doublyLinkedList.Last.Value;
        Console.WriteLine(IsPalindrome(doublyLinkedList));
    }

    public static bool IsPalindrome<T>(LinkedList<T> linkedList)
    {
        // if so, move recursively toward the middle
        // If false, return false

        //Base case: Length less than 2
        if (linkedList.Count < 2)
        {
            return true;
        }
        else
        // Check if the first and last nodes are the same
        { 
            if(linkedList.First.Value.Equals(linkedList.Last.Value))
            {
                linkedList.RemoveFirst();
                linkedList.RemoveLast();
                IsPalindrome(linkedList);
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}

