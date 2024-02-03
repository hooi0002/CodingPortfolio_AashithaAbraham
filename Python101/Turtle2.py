import turtle
import random

turtle.shape("turtle")
turtle.Screen().colormode(255)
turtle.Screen().bgcolor("#c7f0d2")
turtle.speed("fastest")
turtle.hideturtle()

for j in range(0, 4000, 1):
    # Pick a random color
    r = random.randint(0, 255)
    g = random.randint(0, 255)
    b = random.randint(0, 255)
    turtle.color(r, g, b)

    # Draw and fill a square
    turtle.begin_fill()
    for i in range(10, 18, 2):
        turtle.forward(100)
        turtle.right(90)
    turtle.end_fill()

