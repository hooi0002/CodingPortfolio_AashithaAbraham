import turtle
import random

turtle.shape("turtle")
turtle.Screen().colormode(255)
turtle.Screen().bgcolor("#c7f0d2")
turtle.speed("fastest")
turtle.hideturtle()

x_loc = -400
y_loc = 380

num_row = int(input("Number of rows: "))
num_col = int(input("Number of columns: "))

def PickRandomColors():
    # Pick a random color
    r = random.randint(0, 255)
    g = random.randint(0, 255)
    b = random.randint(0, 255)
    turtle.color(r, g, b)

def DrawSquare():
    # Draw and fill a square
    turtle.begin_fill()
    for i in range(10, 18, 2):
        turtle.forward(50)
        turtle.right(90)
    turtle.end_fill()

def draw_triangle():
    for i in range(3):
        turtle.forward(50)
        turtle.left(120)


for step_y in range(num_row):
    # Draw 1 ROW
    for step_x in range(num_col):
        # Move to a new location
        turtle.penup()
        turtle.goto(x_loc, y_loc)
        turtle.pendown()

        PickRandomColors()

        # Make random choices
        choice = random.randint(1, 2)
        if choice == 1:
            #draw_triangle()
            DrawSquare()
        else:
            DrawSquare()


        # Update x location
        x_loc = x_loc + 50

    # Relocate the pen to the starting point of another row
    x_loc = -400
    y_loc = y_loc - 50



turtle.mainloop()