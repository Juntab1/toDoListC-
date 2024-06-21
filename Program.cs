using System.Collections;
using System.Text;

public class toDoList
{
    // name of the toDoList
    private string? name;
    // keep track of what tasks are in the toDoList
    private ArrayList currList = new ArrayList();
    private Dictionary<int,string> taskToInd = new Dictionary<int, string>();

    // don't need a constructor here it is better to use a get and setter.
    // make sure it is capital "N" even when the variable is lowercase.
    public string Name
    {
        get{
            if (name is null){
                return "Currently there is no name for list";
            }
            return name;
        }
        set {name = value;}
    }

    public void add(String task)
    {
        currList.Add(task);
        taskToInd[currList.Count - 1] = task;
    }

    // user puts in 1-currList.Count.
    // Do not want the user to think it is 0 index
    public void remove(int ind)
    {
        // get real index
        int realInd = ind - 1;
        if (realInd < currList.Count && realInd >= 0){
            // get the value of the element at the end of the arraylist
            var currVal = taskToInd[currList.Count - 1];
            // change the value of the arraylist to the value at the end of the arraylist
            currList[realInd] = currVal;
            // have to remove the variable at the end of the currList in the dictionary
            taskToInd.Remove(currList.Count - 1);
            // remove the last variable in the list
            currList.RemoveAt(currList.Count - 1);
        }
    }

    public void read()
    {
        if (currList.Count == 0){
            Console.WriteLine("Please add something into your list");
        }
        else{
            var ans = new StringBuilder();
            ans.Append("ToDo List: ");
            foreach (string i in currList)
            {
                ans.Append(i + ", ");
            }
            Console.WriteLine(ans.ToString().Substring(0, ans.Length - 2));
        }
    }

}

class Program 
{
    static void Main(string[] args){
        var toDo = new toDoList();
        Console.WriteLine(toDo.Name);
        toDo.Name = "Jun ToDo list";
        Console.WriteLine(toDo.Name);
        toDo.add("go shower");
        toDo.add("go workout");
        toDo.add("go work");
        toDo.read();
        toDo.remove(1);
        toDo.read();
    }
}


/*
Later put into a ReadMe:
GOAL: Create a O(1) toDoList
1. create a simple toDoList where we can take in name of the list and use an arraylist to keep track of variables
    - function: set/get, add task, and read 
2. Create a remove task that is O(1), did this by using a hashmap to keep track of what value is at what index.
    - maybe need to find a way to print at a certain way since right now it is taking the last element and 
    moving it forward.






Resource: 
 - talking about creating own hash table: https://stackoverflow.com/questions/72591504/data-structure-that-performs-set-get-setall-in-o1
*/
