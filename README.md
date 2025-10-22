# 051 Test Stubs
## Lecture

[![# Test Stubs (Part 1)](https://img.youtube.com/vi/HVdE13ZQ6qg/0.jpg)](https://www.youtube.com/watch?v=HVdE13ZQ6qg)
[![# Test Stubs (Part 2)](https://img.youtube.com/vi/Q7vFGa12zmA/0.jpg)](https://www.youtube.com/watch?v=Q7vFGa12zmA)

## Instructions

In this lesson you will be testing the method contained in `HomeEnergyApi/Services/MathService.cs`. You will need to change the file at `HomeEnergyApi.Tests/Lesson49Tests/Math.Tests.cs`. You should NOT change any test files inside of the `HomeEnergyApi.Tests/GradingTests`, these are used to grade your assignment.

- In `HomeEnergyApi/Services/MathService.cs`
    - Modify `ConvertToRomanNumeral()`
        -Should throw a new `ArgumentOutOfRangeException` with the following arguments passed, rather than returning `""` when `number` is less than zero or greater than 3,999
            - `nameof(number)`
            - `"Input must be in the range 1-3999"`
- In `HomeEnergyApi.Tests/Lesson50Tests/Math.Tests.cs`
    - Modify the test `ShouldReturnEmptyStringWhenIntegerIsOutOfRange()`
        - Rename the test to `ShouldThrowArgumentOutOfRangeExceptionWhenIntegerIsOutOfRange()`
        - Modify the logic of the test to pass if `mathService` throws an `ArgumentOutOfRangeException` when passed the int `-1`

## Additional Information

- Do not remove or modify anything in `HomeEnergyApi.Tests`
- Some Models may have changed for this lesson from the last, as always all code in the lesson repository is available to view
- Along with `using` statements being added, any packages needed for the assignment have been pre-installed for you, however in the future you may need to add these yourself

## Building toward CSTA Standards:

## Resources
- https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/

Copyright &copy; 2025 Knight Moves. All Rights Reserved.
