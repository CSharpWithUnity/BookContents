/* 
 * Chapter 3.7 Code Blocks
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

class CodeBlocks
{
    /*
     * Section 3.7 Code Blocks
     */

    void SimpleStatements()
    {
        // im outside of the block of code below
        if (true)
        {
            // code goes here
            // im also in this block of code
        }
        // im outside of the block of code above
        
        /* the statement below is less
         * easy to interpret
         */

        int i = 7;
        int j = 13;
        if (i < j){
        j = 7;}

        /* the statement below is more
         * easy to interpret
         */

        int k = 8;
        int l = 9;

        if (k < l)
        {
            l = 8;
        }

        /* indents are important to help understand
         * how parts of logic are divided
         */

        if (true)
        {
            //code here
            if (true)
            {
                //another block of code.
            }
        }

        /* the code below is rather
         * difficult to understand
         */

        if (true)
        {//code here
        if (true)
        {//another block of code.
        }
        }

        /*
         * or just as confusing...
         */

        if (true){//code here
        if (true){//another block of code.
        }
        }
    }
}
