# 2016 - 2017 Midterm

Total points: 110

## Question 1 (20 pts)

In [visitor.txt](./visitor.txt), there is a  list of people who visit a restaurant. In [customer.txt](./customer.txt), there is a list of people who have ordered food. By comparing these lists (you can use LINQ), on a daily basis, print

* How many people enter the restaurant
* How many people eat and the percentage
* How many people leave without eating and the percentage

(This question is focused on file operations. Using classes is not mandatory.)

---

## Question 2 (30 pts)

In this question, we will develop a phonebook app.

* Contacts will be saved to a file
* Information such as name, surname, home address, notes, and phone number will be kept.
* This information will be input optionally, but at least one field must be filled.
* The application will have options to add new contact, delete a contact, and update a contact.
* The application must have search functionality and the given text must be searched in the contacts' name, surname or phone number fields.
    * 100% match is not required.
    * In case "name" is written, contacts who have "...name..." in their names or "...name..." in their surnames.
    * In case "212 555" is written, phone numbers such as "<ins>212555</ins>1122", or "0<ins>212 55 5</ins>1 133" should match.
    * In search results, the contacts should have the format (name surname).
    * After these contacts are listed, the contact to be examined in detail will be asked to the user and the information on that contact will be printed to the screen.

---

## Question 3 (60 pts)

```c#
// return value in meters
private static Distance(Point point1, Point point2)
{
    double R = 6371000;
    double dlon = (point1.Longitude - point2.Longitude) * Math.PI / 180;
    double dlat = (point1.Latitude - point2.Latitude) * Math.PI / 180;
    double a = Math.Pow(Math.Sin((dlat / 2)), 2) + Math.Cos(point1.Latitude * Math.PI / 180) * Math.Cos(point2.Latitude * Math.PI / 180) * Math.Pow(Math.Sin((dlon / 2)), 2);
    double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
    double distance = R * c;
    return distance;
}
```

You are given a method that calculates the distance between two points above.

You are also given a file that has a few points and the name of these points, as well as a file that has IDs of people and the points that they have been to.

1. Design a class that represents a point.
2. Make a list that holds objects of this point class (places.txt).
3. Design a class that represents a person. 
4. Make a list that holds the people (personList.txt).

Your applications must be able to perform the following operations:

### Operations
1. Create a new person (a new ID value will be given automatically and current location will be asked).
2. For a person, add a new coordinate (Person will be identified by the ID number and the location will be added to their places list).
3. Add/remove locations in the places.txt file.
4. If a person is closer than 100m to a location, that person will be considered in that address and the address will be printed.

Make sure before you exit that:
1. The newly added locations must be added to the places.txt file
2. For people, when new locations added or removed, personList.txt file must be updated.
