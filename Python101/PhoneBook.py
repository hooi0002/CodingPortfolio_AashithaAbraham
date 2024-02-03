"""
Write a program to input your friend's name and contact number
Store the info in a dictionary as key-value pair

1. The program is capable of performing these operations:
a) Display the name and phone number of a contact
b) Add/Delete a certain contact
c) Update a contact
d) Check if a contact is present
e) Display all contacts in a sorted order
"""

contacts = {}

def DisplayMenu():
    print("---------- My Phonebook App -----------")
    print("1. Add a new contact")
    print("2. Display all contacts")
    print("3. Delete a contact")
    print("4. Modify/Change phone number")
    print("5. Check if a contact exist")
    print("6. Display in sorted order of names")
    print("7. Exit")


# Program Loop
while True:
    DisplayMenu()
    choice = int(input("Enter your choice: "))
    if choice == 1:
        nm = input("Enter name: ")
        ph = input("Enter phone number: ")
        contacts[nm] = ph

    elif choice == 2:
        for i in contacts: # i represents each key in dictionary
            print("Name: ", i)
            print("Contact number: ", contacts[i])

    elif choice == 3:
        toDelete = input("Enter the contact(name) to be deleted: ")
        if toDelete in contacts:
            del contacts[toDelete]
            print("Contact deleted")
        else:
            print("No record found")

    elif choice == 4:
        toUpdate = input("Enter the contact(name) to modify their phone number: ")
        if toUpdate in contacts:
            newnm = input("Enter a new number: ")
            contacts[toUpdate] = newnm # re-assign newnm as the new value of the key(toUpdate)
            print("Record modified")
        else:
            print("No record found")

    elif choice == 5:
        toCheck = input("Enter a name to search: ")
        if toCheck in contacts:
            print("Record found")
        else:
            print("No record found")

    elif choice == 6:
        for i in sorted(contacts.keys()):
            print(i)

    elif choice == 7:
        break

    else:
        print("Please enter a value between 1 - 7: ")






















