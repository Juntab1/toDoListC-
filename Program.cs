using System.Collections;
using System.Text;

public class toDoList
{
    // name of the toDoList
    private string? name;
    // keep track of what tasks are in the toDoList
    private ArrayList currList = new ArrayList();

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
    }
}
