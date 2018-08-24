/*
 * Chapter 3.8 Classes
 */

class Classes
{
    public int MyInt;
    /*
     * The MyInt becomes a member
     * of this class.
     * 
     * The different data members
     * usually appear at the top of
     * the class when it's written.
     * 
     *  Time day = today; ←① Gather your data
     *  
     *  if ( day == Friday ) ←② Use the data
     *  {
     *      PartyTonight = true; ←③ Act on the data
     *  }
     *  
     */

    public void MyFunction()
    {
    }

    /*
     * The MyFunction()
     * is also a member of
     * the Classes class object
     */
}

/*
 * Section 3.8.1 Objects
 */

class Objects
{
    /*
     * Table is an nested class inside of the Objects
     * class
     */
    class Table
    {
        //Assembly Instructions
        void Instructions()
        {
            //TODO:
            //write instructions on 
            //how to build a table.
        }
    }

    Table someTable;
    void BuildTables()
    {
        someTable = new Table();
    }

    enum AmmoType
    {
        Solid,
        FullMetalJacket,
        ArmorPiercing,
        HollowPoint,
        Explosive
    }
    /*
     * Here we show an ammo class
     * where we store a type of
     * ammunition along with
     * how many are stored in this
     * particular instance.
     */
    class Ammunition
    {
        AmmoType ammoType;
        int ammoCount = 10;
    }
}
