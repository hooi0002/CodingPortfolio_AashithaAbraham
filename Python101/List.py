# Python List

gameList = ["Valorant", "BrawlStars", "CallOfDuty", "Roblox", "Minecraft", "Fortnite"]
mixList = ["Kotlin", 1000, True, [2, 3]]

# Accessing elements in a list
# Iteration through a list (A python list is iterable)
for i in range(0, len(gameList), 1):
    print(gameList[i])

# A python list is mutable
# We can update/add/remove items from the list
foodList = ["Sushi", "BBT", "Laksa", "Pizza", "CR"]
print(foodList[::-1])
print(foodList)

foodList[0] = "FS"
print(foodList)

foodList.append("Bibimbap")
print(foodList)

foodList.insert(3, "HKM")
print(foodList)

# Item removal
foodList.remove("CR")
print(foodList)

del foodList[len(foodList) - 1]
print(foodList)


# Another variation of for loop
for i in foodList:
    print(i)