// Chapter 3.6 White Space

class WhiteSpace {

    /*
     * Section 3.6 White Space
     * The function below has normal white space added
     */
    void MyFunction()
    {
        int i = 0;
        while (i < 10)
        {
            System.Console.Write(i);
            i++;
        }
    }

    /*
     * Section 3.6 White Space
     * The function below has minimal white space added
     * the only place white space is required is after a
     * keyword is used to name a variable.
     * for instance after void and after int
     * the function works, it's just a bit difficult to read.
     */
    void MyOtherFunction(){int i=0;while(i<10){System.Console.Write(i);i++;}}

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
