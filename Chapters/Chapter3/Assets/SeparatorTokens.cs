//Chapter 3.3.2 Separator Tokens

class SeparatorTokens
{
    /*
     * Curly Braces are { and }
     */
     void Separators()
    {
        /* code needs to be separated into small chunks
         * to help separate code into usable parts we
         * use separator tokens.
         */
        int a = 0;
        /*
         * the ; indicates the end of a statement.
         */

        int b = 1; int c = 2;
        /*
         * multiple statements can appear on the same line
         * but it's not common practice to do so.
         */

        {
            int d = 1;
        }
        /* the curly braces isolate int d = 1; by separating
         * it from the rest of the code in the Separators()
         * function. more on this in a later chapter on scope
         * in chapter 4.8
         */
    }
}
