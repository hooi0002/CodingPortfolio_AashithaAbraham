numList = []
for i in range(1, 101, 1):
    numList.append(i)


testList = [*range(1, 101, 1)]

# For loop approach
def SumAll_ForLoop(anyList):
    sum = 0
    for everyItem in anyList:
        sum = sum + everyItem
    print(sum)


# While loop approach
def SumAll_WhileLoop(anyList):
    sum = 0
    itemNum = 0
    while itemNum < len(anyList):
        sum = sum + anyList[itemNum]
        itemNum = itemNum + 1
    print(sum, itemNum)


"""
Question 2: Sum up the adjacent numbers in a given list
and store the result in a new list
e.g.
testList = [1, 2, 3, 4, 5]
resultList = [3, 5, 7, 9]
"""
testList2 = [1, 2, 3, 4, 5]
resultList = []


def SumAdj(anyList):
    for i in range(0, len(anyList) - 1, 1):
        resultList.append(anyList[i] + anyList[i + 1])
    print(resultList)

SumAdj(testList2)