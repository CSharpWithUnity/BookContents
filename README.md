# BookContents
Public repo of the Learning C# with Unity 3D book contents

## What's included?
The contents of this Git Repo are usable for anyone who may or may not have a copy of the _Learning C# with Unity 3D_ book. Of I'd appreciate it if you bought a copy I'll have a link to the Second Edition on Amazon or B&N soon, I understand that it's not something that everyone can afford.

The contents are arranged by chapter. [Example Code](https://github.com/CSharpWithUnity/BookContents/blob/7ec2e3d28f7da22cacb7c640791e57d5731970cc/Chapters/Chapter2/Assets/Example.cs#L5) is provided for everything shown in the book.

A Chapter Outline will be coming soon as soon as I'm done re-arranging and re-writing all of the content.
The second edition is a major update to the previous book. In a practical sense, it's a completely new book, so much of the content is new and re-written that it hardly resembles the previous version.

A lof of work went into comments like [these](https://github.com/CSharpWithUnity/BookContents/blob/7ec2e3d28f7da22cacb7c640791e57d5731970cc/Chapters/Chapter8/Assets/Linq.cs#L46-L58). The comments here help illustrate where the data is coming from and where it's going to. Each step of the process is numbered to help see what's going on.

``` CSharp 
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            /*      └──────────────❶─────┐ numbers is an array    */
            /*                  ┌──❷──┐  ↓ n is each object in    */
            /*                  ↓     ↑  ↓ the number array.      */
            var evenNums = from n in numbers
            /*    ↑ the result  ↓                                 */
            /*    ❺ is added to └❸┐ an operation is performed     */
            /*    │ evenNums      ↓ on each object in the array   */
            /*    │      */where (n % 2) == 0                     
            /*    │               ↓ if this operation is true     */
            /*    │               ❹ the value is added to         */
            /*    │               ↓ the result of the statement   */
            /*    └─────←*/select n;
```
This kind of stuff took a lot of work, and I hope this helps!