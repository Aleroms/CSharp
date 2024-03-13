/*The goal of this exercise is to finish the implementation of the Order class. It represents a simple Order made in a store, and it needs to have two properties:

Item(string), which should not be settable at all

Date (DateTime), which should be both gettable and settable. Its setter should validate if the given value has the same year as the current year. If not, the value of the Date property should not be changed.

Your job is only to add the definitions of those two properties. If needed, you can add backing fields as well.*/

public class Order
{
    private DateTime _date;
    public string Item { get; }
    public DateTime Date
    {
        get { return _date; }
        set
        {
            if (value.Year == DateTime.Now.Year) _date = value;
        }
    }

    public Order(string item, DateTime date)
    {
        Item = item;
        Date = date;
    }
}