using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // --- STEP-BY-STEP PLAN ---
        // Step 1: Create a new array of doubles called 'multiples' with a size equal to 'length'.
        // Step 2: Use a loop (for loop) that iterates from index 0 up to 'length - 1'.
        // Step 3: Inside the loop, calculate the value for each position using the formula: number * (index + 1).
        //         This ensures the first element (index 0) is number * 1, the second is number * 2, etc.
        // Step 4: Store each calculated value into the corresponding slot of the 'multiples' array.
        // Step 5: After the loop finishes, return the completed 'multiples' array.

        // Step 1: Initialize the array
        double[] multiples = new double[length];

        // Step 2 & 3 & 4: Loop and populate the array with calculations
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Step 5: Return the populated array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // --- STEP-BY-STEP PLAN ---
        // Step 1: Check if the list is empty or if the rotation amount is 0. If so, return immediately.
        // Step 2: Calculate the effective rotation using the modulo operator (amount % data.Count).
        //         This prevents issues if the amount is larger than the actual list size.
        // Step 3: Find the starting point of the segment to move: starting index is 'data.Count - effectiveAmount'.
        // Step 4: Extract that rear section of the list using GetRange() and store it in a temporary list.
        // Step 5: Remove that same rear section from the original 'data' list using RemoveRange().
        // Step 6: Insert the extracted temporary list back at the very beginning (index 0) using InsertRange().

        // Step 1: Base validation
        if (data == null || data.Count <= 1 || amount <= 0)
        {
            return;
        }

        // Step 2: Handle edge cases where amount is larger than list count
        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0)
        {
            return;
        }

        // Step 3 & 4: Get the temporary segment from the back
        int splitIndex = data.Count - effectiveAmount;
        List<int> shiftingSegment = data.GetRange(splitIndex, effectiveAmount);

        // Step 5: Remove the segment from the back
        data.RemoveRange(splitIndex, effectiveAmount);

        // Step 6: Insert the segment at the front
        data.InsertRange(0, shiftingSegment);
    }
}
