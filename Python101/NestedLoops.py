# Pyramid pattern of stars

def upwardPyramid():
    # number of rows
    rows = 5
    for j in range(rows):

        # inner for loop - used to draw 1 row
        for i in range(j + 1):
            # print star
            print("*", end=" ")

        # new line after each row
        print("\r")


def invertedPyramid():
    # number of rows
    rows = 5
    for j in range(rows, 0, -1):

        # inner for loop - used to draw 1 row
        for i in range(j):
            # print star
            print("*", end=" ")

        # new line after each row
        print("\r")


def pascalTriangle(rows):
    for j in range(rows):
        for i in range(j + 1):
            print("*", end=" ")
        print("\r")


    for j in range(rows, 0, -1):
        for i in range(j - 1):
            print("*", end=" ")
        print("\r")



# 5 lines or below
def Tri_13579():
    rows = 5
    for i in range(1, rows + 1):
        for j in range(0, i):
            print(i * 2 - 1, end=" ")
        print("\r")

Tri_13579()








